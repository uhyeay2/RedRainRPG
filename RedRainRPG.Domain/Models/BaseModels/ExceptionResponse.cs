namespace RedRainRPG.Domain.Models.BaseModels
{
    public class ExceptionResponse : BaseResponse
    {
        public Exception Exception { get; set; }

        public ExceptionResponse(Exception exception, int statusCode, string message) : base(statusCode, message)
        {
            Exception = exception;
        }

        /// <summary>
        /// This constructor will default StatusCode to 500 and set the Message property using the exception provided.
        /// </summary>
        /// <param name="exception"></param>
        public ExceptionResponse(Exception exception) : this(exception, statusCode: 500, message: exception.Message)
        {
        }
    }
}
