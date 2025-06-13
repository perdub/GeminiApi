
using System.Buffers;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DdgAiProxy;
using GeminiApi.Types;
using Microsoft.Extensions.Logging;

namespace GeminiApi;

public class GeminiModel : DialogManager
{
    private string apiKey = string.Empty;
    public double Temperature {get;set;} = 0.8d;
    private string modelName;

    private static readonly SafetySetting[] safetySettings =  new SafetySetting[]{
            new SafetySetting{
                Category = HarmCategory.HARM_CATEGORY_HARASSMENT,
                Threshold = HarmBlockThreshold.BLOCK_NONE
            },
            new SafetySetting{
                Category = HarmCategory.HARM_CATEGORY_HATE_SPEECH,
                Threshold = HarmBlockThreshold.BLOCK_NONE
            },
            new SafetySetting{
                Category = HarmCategory.HARM_CATEGORY_SEXUALLY_EXPLICIT,
                Threshold = HarmBlockThreshold.BLOCK_NONE
            },
            new SafetySetting{
                Category = HarmCategory.HARM_CATEGORY_DANGEROUS_CONTENT,
                Threshold = HarmBlockThreshold.BLOCK_NONE
            },
            new SafetySetting{
                Category = HarmCategory.HARM_CATEGORY_CIVIC_INTEGRITY,
                Threshold = HarmBlockThreshold.BLOCK_NONE
            }
        };

    private List<Content> dialogContent;
    private Content systemInstruction;
    private GenerationConfig generationConfig;

    private ILogger<GeminiModel> logger;

    private HttpClient httpClient;

    public bool DontAutoSaveOutput { get; set; } = false;

    public GeminiModel(HttpClient customClient, ILogger<GeminiModel> logger) : base(null)
    {
        this.logger = logger;
        this.httpClient = customClient;
        dialogContent = new List<Content>();
    }
    public async Task Init(string apiKey, string systemPrompt, string geminiModel = "gemini-1.5-flash", double temperature = 1.18d, GenerationConfig? genConf = null)
    {
        payload = PayloadBuilder.BuildEmpty();
        this.apiKey = apiKey;
        this.modelName = geminiModel;
        this.Temperature = temperature;

        generationConfig = genConf ?? new GenerationConfig
        {
            Temperature = this.Temperature,
            TopK = 40,
            TopP = 0.99
        };
        systemInstruction = new Content
        {
            Role = "user",
            Parts = new Part[]{
                new Part{
                    Text = systemPrompt
                }
            }
        };
    }
    public void EditTemperatureInRun(double newTemp){
        generationConfig.Temperature = newTemp;
    }
    public override bool IsReady => !string.IsNullOrEmpty(apiKey);
    public async Task<Response> SendMessage(string message, string image_url)
    {
        logger.LogDebug("Download image..");
        var imgArr = await download(image_url);
        return await SendMessage(string.Empty, imgArr);
    }
    public async Task<Response?> SendMessage(string message, byte[] bytes, bool invokeApi = true)
    {
        logger.LogDebug("Upload image to gemini api...");
        var file = (await uploadToGemini(bytes, true));

        if(string.IsNullOrWhiteSpace(message))
            message = "Look on this image.";

        dialogContent.Add(
            new Content
            {
                Role = "user",
                Parts = new Part[]{
                    new Part{
                        FileData = new FileData(
                            file.MimeType,
                            file.Uri
                        )
                    },
                    new Part{
                        Text = message
                    }
                }
            }
        );
        if(!invokeApi)
            return null;

        return await base.SendMessage(string.Empty);
    }
    public Task<Response?> SendMessage(string message, bool invokeApi = true)
    {
        dialogContent.Add(
            new Content
            {
                Role = "user",
                Parts = new Part[]{
                    new Part{
                        Text = message
                    }
                }
            }
        );
        if(!invokeApi)
            return null;

        return base.SendMessage(string.Empty);
    }
    public override Task<Response> SendMessage(string message)
    {
        dialogContent.Add(
            new Content
            {
                Role = "user",
                Parts = new Part[]{
                    new Part{
                        Text = message
                    }
                }
            }
        );

        return base.SendMessage(string.Empty);
    }

    private HttpRequestMessage factory()
    {
        return new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/v1beta/models/{modelName}:generateContent?key={apiKey}");
    }

    public override async Task<Response> Talk()
    {

        if (!IsReady)
            throw new Exception("Api key is not set");

        dialogContent = filterList().ToList();


        var req = new GenerateContentRequest
        {
            Contents = dialogContent.ToArray(),
            SystemInstruction = systemInstruction,
            GenerationConfig = generationConfig,
            SafetySettings = safetySettings
        };

        logger.LogDebug("Created new GenerateContentRequest.");

        HttpRequestMessage httpRequestMessage = factory();
        httpRequestMessage.Content = req.PackToHttpContent();
        httpRequestMessage.Headers.Add("Target-Url", $"https://generativelanguage.googleapis.com/v1beta/models/{modelName}:generateContent");

        logger.LogDebug($"Send request to model. modelName:{modelName}");

        var resp = await httpClient.SendAsync(httpRequestMessage);

        Response response = new Response();
        response.ModelInfo = modelName;
        response.ResponseTime = DateTime.Now;

        logger.LogDebug($"HTTP Result: {resp.StatusCode}");

        if (resp.StatusCode != System.Net.HttpStatusCode.OK)
        {
            response.Status = ResultType.UpstreamError;
            var err = await resp.Content.ReadAsStringAsync();
            response.TextResponse = ($"Gemini api return {resp.StatusCode}, body: {err}");
            logger.LogError(response.TextResponse);
            return response;
        }

        var stringOut = await resp.Content.ReadAsStringAsync();
        Debug.Print(stringOut);
        GenerateContentResponse llmResult;
        try
        {
            var jso = new JsonSerializerOptions();
            
            llmResult = System.Text.Json.JsonSerializer.Deserialize<GenerateContentResponse>(stringOut, new JsonSerializerOptions
            {
                Converters = {
                    new JsonStringEnumConverter()
                }
            });

        }
        catch (System.Text.Json.JsonException exception)
        {
            logger.LogError("Error: fall to parce json message: {0}", stringOut);
            //this dosent make any sence but this is error type when we fall to parce json. I know that i need to rewrite all this shit but i am too lazy.
            response.Status = ResultType.InputLimit;
            return response;
        }

        logger.LogDebug($"Result unpacked.");
        
        logger.LogDebug(llmResult.Serialize());

        //save model output in memory for dialog history
        if (!DontAutoSaveOutput)
            dialogContent.Add(llmResult.Candidates[0].Content);
        else
            dialogContent.Add(
                new Content{
                    Role = "model"
                }
            );

        var stringResult = llmResult.Candidates[0].Content.Parts[0].Text;
        response.TextResponse = stringResult;

        logger.LogDebug($"Sussesful end.");

        response.Status = ResultType.Ok;
        return response;
    }

    private async Task<byte[]> download(string url)
    {
        return await httpClient.GetByteArrayAsync(url);
    }

    private async Task<GeminiApi.Types.File?> uploadToGemini(byte[] array, bool waitForActiveStatus = false)
    {
        try
        {
            logger?.LogDebug($"Start upload file to api");
            var req = new HttpRequestMessage(HttpMethod.Post, $"https://generativelanguage.googleapis.com/upload/v1beta/files?key={apiKey}");
            MemoryStream mem = new MemoryStream(array);
            mem.Position = 0;
            req.Content = new StreamContent(mem);
            req.Headers.Add("Target-Url", $"https://generativelanguage.googleapis.com/upload/v1beta/files");
            req.Content.Headers.ContentType = new MediaTypeHeaderValue(FormatDetector.GetFileFormat(array));

            var resp = await httpClient.SendAsync(req);
            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                string errorMessage = $"Fall to upload file: code:{resp.StatusCode} response:{await resp.Content.ReadAsStringAsync()}";
                logger?.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
            var js = await resp.Content.ReadAsStringAsync();
            var file = System.Text.Json.JsonSerializer.Deserialize<ApiResp>(js);
            logger?.LogDebug($"File uploaded! {js}");

            if(waitForActiveStatus){
                while(file.File.State == FileState.PROCESSING){
                    await Task.Delay(5000);

                    var httpMess = new HttpRequestMessage(HttpMethod.Get, $"https://generativelanguage.googleapis.com/upload/v1beta/{file.File.Name}?key={apiKey}");
                    var resp1 = await httpClient.SendAsync(httpMess);
                    js = await resp1.Content.ReadAsStringAsync();
                    file = System.Text.Json.JsonSerializer.Deserialize<ApiResp>(js);
                }
            }

            return file.File;
        }
        catch (Exception r)
        {
            logger.LogError(r.Message);
            throw;
        }
    }

    public class ApiResp
    {
        [JsonPropertyName("file")]
        public GeminiApi.Types.File File { get; set; }
    }

    public void ClearRag(string ragStartMessage = "Also, now you will get some data chunks with addition information, with you can use before responce generation."){
        var messages = dialogContent
            .Where(a=>a.Role == "user");

        foreach(var mess in messages){
            foreach(var part in mess.Parts){
                if(!string.IsNullOrWhiteSpace(part.Text)){
                    int p = part.Text.IndexOf(ragStartMessage);
                    if(p != -1){
                        part.Text = part.Text.Substring(0, p);
                    }
                }
            }
        }
    }

    public void AddModelPhrase(string modelText)
    {
        if(string.IsNullOrWhiteSpace(modelText))
            return;

        if(dialogContent.Count == 0){
            dialogContent.Add(new Content{Role = "model"});
        }
        var lastModel = dialogContent.Reverse<Content>().Where(a=>a.Role == "model").FirstOrDefault();
        lastModel.AutoAdd(
            new Part{
                Text = modelText
            }
        );
    }

    /// <summary>
    /// use when you want add message from model
    /// </summary>
    /// <param name="message"></param>
    public void AddModelMessage(string message){
        dialogContent.Add(new Content{
            Role = "model",
            Parts = new Part[]{
                new Part{
                    Text = message
                }
            }
        });
    }

    private IEnumerable<Content> filterList(){
        return dialogContent
            .Select(filterSelector)
            .Where(a => a != null);
    }

    private Content? filterSelector(Content c){
        if(c.Role == null || c.Parts == null || c.Parts.Length == 0){
            return null;
        }
        int i = 0;
        var pool = ArrayPool<Part>.Shared;
        Part[] newPartsArray = pool.Rent(c.Parts.Length);

        foreach(var part in c.Parts){
            if(part == null){
                continue;
            }
            if(string.IsNullOrWhiteSpace(part.Text) && part.InlineData == null && part.FileData == null && part.ExecutableCode == null && part.CodeExecutionResult == null){
                continue;
            }
            newPartsArray[i] = part;
            i++;
        }
        
        if(i==0)
            return null;

        Part[] constNewArr = new Part[i];

        Array.Copy(newPartsArray, 0, constNewArr, 0, i);

        c.Parts = constNewArr;

        return c;
    }

}