namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class GetPlayerByEmail : Endpoint<EmailBasedRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public GetPlayerByEmail(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post("player/getByEmail");
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(EmailBasedRequest request, CancellationToken c = default)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            var player = await _playerRepo.GetPlayerByEmail(request.Email);

            if(player == null)
            {
                return new(StatusCodes.Status404NotFound, $"No player was found with the email: {request.Email}");
            }

            return new(player);
        }
    }
}
