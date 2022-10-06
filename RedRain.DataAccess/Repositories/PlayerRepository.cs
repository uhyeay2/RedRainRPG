using RedRain.DataAccess.DataTransferObjects;
using RedRain.DataAccess.RequestObjects.PlayerRequests;
using RedRainRPG.Domain.Constants;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;
using RedRainRPG.Domain.Models.BaseModels;
using RedRainRPG.Domain.Models.BaseModels.BaseResponses;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;
using RedRainRPG.Domain.Models.PlayerModels.PlayerResponses;

namespace RedRain.DataAccess.Repositories
{
    internal class PlayerRepository : RepositoryBase, IPlayerRepository
    {
        public PlayerRepository(IConfig config) : base(config) { }

        public async Task<BaseResponse> DeletePlayerByGuid(Guid guid)
        {
            try
            {
                var rowsAffected = await ExecuteAsync(new DeletePlayerByGuid(guid));
                
                return rowsAffected == 1 ? new ExecutionResponse(rowsAffected) : new (StatusCode.NotFound_404, $"There was no Player found with the guid: {guid}");
            }
            catch (Exception e)
            {
                return new ExceptionResponse(e);
            }
        }

        public async Task<BaseResponse> GetPlayerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new(StatusCode.BadRequest_400, "Email cannot be null empty or whitespace.");
            }

            try
            {
                var dto = await FetchAsync<GetPlayerByEmail, PlayerDTO>(new(email));

                if(dto == null)
                {
                    return new (StatusCode.NotFound_404, $"No Player found with the email: {email}");
                }

                return new GetPlayerByEmailResponse(dto.ToPlayer());
            }
            catch (Exception e)
            {
                return new ExceptionResponse(e);
            }
        }

        public async Task<BaseResponse> IsEmailRegistered(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new(StatusCode.BadRequest_400, "Email cannot be null empty or whitespace.");
            }

            try
            {
                return new IsEmailRegisteredResponse(await FetchAsync<IsEmailRegistered, bool>(new(email)));
            }
            catch (Exception e)
            {
                return new ExceptionResponse(e);
            }
        }

        public async Task<BaseResponse> RegisterPlayerAsync(RegisterPlayerRequest request)
        {
            try
            {
                var rowsAffected = await ExecuteAsync(new RegisterPlayer(request));
                
                return rowsAffected == 1 ? new ExecutionResponse(rowsAffected) : new (400, "An account is already registered with this email or account name.");
            }
            catch (Exception e)
            {
                return new ExceptionResponse(e);
            }
        }
    }
}
