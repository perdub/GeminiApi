namespace GeminiApi
{
    public class Response
    {
        public string TextResponse { get; set; } = string.Empty;

        public bool IsSussesful { get; set; } = true;

        public string ErrorInfo { get; set; } = null;

        public string ModelInfo { get; set; } = "gemini-unknown";

        public DateTime ResponceTime { get; set; } = DateTime.Now;

        public ResultType Result { get; set; } = ResultType.Ok;
    }

    public enum ResultType
    {
        Ok,
        PromptBlocked,
        FallToDeserialize,
        InternalError
    }
}