namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class RegisterPlayer : Endpoint<RegisterPlayerRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public RegisterPlayer(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post("player/register");
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(RegisterPlayerRequest request, CancellationToken c = default)
        {
            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return BaseResponse.ExecutionResponse(await _playerRepo.RegisterPlayerAsync(request.Email, request.AccountName), expectedCountOfRowsAffected: 1,
                responseIfCountDoesNotMatch: new(StatusCodes.Status409Conflict, "Either the AccountName or Email provided is already in use."));
        }
    }

    public class RegisterPlayerRequest : EmailBasedRequest
    {
        public RegisterPlayerRequest(string accountName, string email) : base(email) => AccountName = accountName;

        public RegisterPlayerRequest() { }

        public string AccountName { get; set; } = string.Empty;

        public override bool IsValid(out string failedValidationMessage)
        {
            var isValid = base.IsValid(out failedValidationMessage);

            if (string.IsNullOrWhiteSpace(AccountName))
            {
                isValid = false;
                failedValidationMessage += "AccountName cannot be Null/Empty/Whitespace";
            }

            return isValid;
        }
    }
}
