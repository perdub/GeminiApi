using GeminiApi.RAG.Types;

namespace GeminiApi.RAG
{   
    public class GenerateChunks
    {
        private string apiKey = string.Empty;

        private string ApiEndpoint = "https://generativelanguage.googleapis.com/v1beta/";
        
        /// <summary>
        /// dont touch it if you dont know for what this need
        /// </summary>
        public bool needToProxyRequest{get;set;} = false;
        /// <summary>
        /// dont touch it if you dont know for what this need
        /// </summary>
        public string? ProxyUrl{get;set;} = null;

        public HttpClient? httpClient{get;set;} = null;

        public GenerateChunks(string apiKey, string? apiEndpoint = null)
        {   
            this.apiKey = apiKey;
            if(apiEndpoint is not null){
                this.ApiEndpoint = apiEndpoint;
            }
        }

        public Chunk[] SplitTextToChunks(string text, int chunkSize = 512, int chunkSameBorder=32){
            List<Chunk> chunks = new List<Chunk>(text.Length / (chunkSize - chunkSameBorder * 2));
            int position = 0;
            bool flag = true;
            int chunkPosition = 0;
            while(flag){
                int start = position;
                int end = Math.Min(text.Length, position+chunkSize);
                if(end == text.Length)
                    flag = false;

                string newChunkText = text.Substring(start, end-position);
                Chunk chunk = new Chunk();
                chunk.Text = newChunkText;
                chunk.ChunkPosition = chunkPosition;
                chunk.WordsBag = new WordsBag(newChunkText);
                chunk.ChunkSize = end - start;
                chunk.ChunkStartPosition = position;
                chunks.Add(chunk);

                position += (chunkSize - chunkSameBorder);
                chunkPosition++;
            }

            return chunks.ToArray();
        }

        public async Task<Chunk[]> GenerateEmbeddings(Chunk[] chunks){
            List<Chunk> tmp = new List<Chunk>(chunks.Length);
            for(int i = 0; i < chunks.Length; i+=100){
                
                int tmpArrSize = Math.Min(100, chunks.Length - (i));

                Chunk[] batch = new Chunk[tmpArrSize];
                Array.ConstrainedCopy(chunks, i, batch, 0, tmpArrSize);

                BatchEmbedContentsRequest request = new BatchEmbedContentsRequest();
                request.Requests = batch.Select((a)=>{
                    return new EmbedContentRequest{
                        Content = new GeminiApi.Types.Content{
                            Role = null,
                            Parts = new GeminiApi.Types.Part[]{
                                new GeminiApi.Types.Part{
                                    Text = a.Text
                                }
                            }
                        }
                    };
                }).ToArray();

                var response = await sendRequest(request);
                for(int j = 0; j<batch.Length; j++){
                    batch[j].Embedding = response.Embeddings[j];
                }
                tmp.AddRange(batch);
            }
            return tmp.ToArray();
        }

        private async Task<BatchEmbedContentsResponce> sendRequest(BatchEmbedContentsRequest request)
        {
            string geminiUrl = ApiEndpoint + "models/text-embedding-004:batchEmbedContents?key="+apiKey;

            HttpRequestMessage httpRequest;

            if(this.needToProxyRequest){
                httpRequest = new HttpRequestMessage(HttpMethod.Post, ProxyUrl);
                httpRequest.Headers.Add("Target-Url", geminiUrl);
            }
            else{
                httpRequest = new HttpRequestMessage(HttpMethod.Post, geminiUrl);
            }
            httpRequest.Content = new StringContent(request.Serialize(), new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

            var response = await httpClient.SendAsync(httpRequest);

            string result = await response.Content.ReadAsStringAsync();
            BatchEmbedContentsResponce resp;
            resp = JsonSerializer.Deserialize<BatchEmbedContentsResponce>(result);
            return resp;
        }

        public async Task<Vector> GetEmbedding(string text){
            string geminiUrl = ApiEndpoint + "models/text-embedding-004:embedContent?key="+apiKey;

            EmbedContentRequest embed = new EmbedContentRequest();
            
            embed.Content = new GeminiApi.Types.Content{
                            Role = null,
                            Parts = new GeminiApi.Types.Part[]{
                                new GeminiApi.Types.Part{
                                    Text = text
                                }
                            }
            };

            HttpRequestMessage httpRequest;

            if(this.needToProxyRequest){
                httpRequest = new HttpRequestMessage(HttpMethod.Post, ProxyUrl);
                httpRequest.Headers.Add("Target-Url", geminiUrl);
            }
            else{
                httpRequest = new HttpRequestMessage(HttpMethod.Post, geminiUrl);
            }
            httpRequest.Content = new StringContent(embed.Serialize(), new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

            var response = await httpClient.SendAsync(httpRequest);

            string result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EmbedContentResponse>(result).Embedding;
        }
    }
}