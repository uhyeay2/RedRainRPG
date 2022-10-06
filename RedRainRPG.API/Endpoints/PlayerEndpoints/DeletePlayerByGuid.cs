using RedRainRPG.Domain.Constants.Routes;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;
using RedRainRPG.Domain.Models.BaseModels.BaseResponses;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class DeletePlayerByGuid : Endpoint<DeletePlayerByGuidRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public DeletePlayerByGuid(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post(PlayerRoutes.DeleteByGuid);
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(DeletePlayerByGuidRequest request, CancellationToken c = default)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return await _playerRepo.DeletePlayerByGuid(request.Guid!.Value);
        }
    }
}
