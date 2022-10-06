using RedRainRPG.Domain.Constants.Routes;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;
using RedRainRPG.Domain.Models.BaseModels.BaseResponses;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

namespace RedRainRPG.API.Endpoints.PlayerEndpoints
{
    public class GetPlayerByEmail : Endpoint<GetPlayerByEmailRequest, BaseResponse>
    {
        private readonly IPlayerRepository _playerRepo;

        public GetPlayerByEmail(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public override void Configure()
        {
            Post(PlayerRoutes.GetByEmail);
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(GetPlayerByEmailRequest request, CancellationToken c = default)
        {
            if (request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return await _playerRepo.GetPlayerByEmail(request.Email);
        }
    }
}
