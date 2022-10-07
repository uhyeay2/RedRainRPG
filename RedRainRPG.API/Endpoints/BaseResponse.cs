namespace RedRainRPG.API.Endpoints
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(int statusCode, string message, object? content = null)
        {
            StatusCode = statusCode;
            Message = message;
            Content = content;
        }

        public BaseResponse(object content, int statusCode = StatusCodes.Status200OK, string message = "Success") : this(statusCode, message, content)
        {
            
        }

        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public object? Content { get; set; }

        public static BaseResponse Successful => new(StatusCodes.Status200OK, "Success");

        /// <summary>
        /// Returns BaseResponse.Successful if rowsAffected == expectedCountOfRowsAffected. Else returns responseIfCountDoesNotMatch
        /// </summary>
        /// <param name="rowsAffected"></param>
        /// <param name="responseIfCountDoesNotMatch"></param>
        /// <param name="expectedCountOfRowsAffected"></param>
        /// <returns></returns>
        public static BaseResponse ExecutionResponse(int rowsAffected, BaseResponse responseIfCountDoesNotMatch, int expectedCountOfRowsAffected = 1) =>
            rowsAffected == expectedCountOfRowsAffected ? Successful : responseIfCountDoesNotMatch;
    }
}
