namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class DeletePlayerByGuid : Endpoint<GuidBasedRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public DeletePlayerByGuid(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post("player/deleteByGuid");
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(GuidBasedRequest request, CancellationToken c = default)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new (StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return BaseResponse.ExecutionResponse(await _playerRepo.DeletePlayerByGuid(request.Guid), expectedCountOfRowsAffected: 1,
                responseIfCountDoesNotMatch: new(StatusCodes.Status404NotFound, $"No Player was found with the Guid: {request.Guid}"));
        }
    }
}
