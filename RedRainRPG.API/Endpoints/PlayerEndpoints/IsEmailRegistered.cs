namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class IsEmailRegistered : Endpoint<EmailBasedRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public IsEmailRegistered(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post("player/isEmailRegistered");
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(EmailBasedRequest request, CancellationToken c = default)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return new(await _playerRepo.IsEmailRegistered(request.Email));
        }
    }
}
