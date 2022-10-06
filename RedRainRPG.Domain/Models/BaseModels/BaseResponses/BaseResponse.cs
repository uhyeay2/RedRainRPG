namespace RedRainRPG.Domain.Models.BaseModels.BaseResponses
{
    /// <summary>
    /// Base Response by default is StatusCode 200 and IsException False
    /// </summary>
    public class BaseResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        #region Constructors

        public BaseResponse(int statusCode, string message = "")
        {
            StatusCode = statusCode;
            Message = message;
        }

        /// <summary>
        /// Default Constructor will create a BaseResponse with StatusCode 200
        /// </summary>
        public BaseResponse() : this(statusCode: 200, message: string.Empty)
        {
        }

        #endregion
    }
}
