namespace RedRainRPG.Domain.Models.BaseModels.BaseResponses
{
    public class ExecutionResponse : BaseResponse
    {
        public int RowsAffected { get; set; }

        public ExecutionResponse(int rowsAffected) : base()
        {
            RowsAffected = rowsAffected;
        }

        public ExecutionResponse(int statusCode, string message = "") : base(statusCode, message)
        {
        }
    }
}
