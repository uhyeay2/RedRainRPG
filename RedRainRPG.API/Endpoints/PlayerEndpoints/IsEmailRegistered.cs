using RedRainRPG.Domain.Constants.Routes;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;
using RedRainRPG.Domain.Models.BaseModels.BaseResponses;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class IsEmailRegistered : Endpoint<IsEmailRegisteredRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public IsEmailRegistered(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post(PlayerRoutes.IsEmailRegistered);
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(IsEmailRegisteredRequest request, CancellationToken c = default)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return await _playerRepo.IsEmailRegistered(request.Email);
        }
    }
}
