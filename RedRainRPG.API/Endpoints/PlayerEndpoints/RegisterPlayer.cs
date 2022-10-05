using FastEndpoints;
using RedRainRPG.Domain.Constants.Routes;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;
using RedRainRPG.Domain.Models.BaseModels;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

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
            Post(PlayerRoutes.RegisterPlayer);
            AllowAnonymous();
        }

        public override async Task<BaseResponse> ExecuteAsync(RegisterPlayerRequest request, CancellationToken c)
        {
            if(request is IValidatable validatable && !validatable.IsValid(out var failedValidationMessage))
            {
                return new BaseResponse(StatusCodes.Status400BadRequest, failedValidationMessage);
            }

            return  await _playerRepo.RegisterPlayerAsync(request);
        }
    }
}
