using RedRainRPG.Domain.Models.BaseModels;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

namespace RedRainRPG.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<BaseResponse> RegisterPlayerAsync(RegisterPlayerRequest request);

        Task<BaseResponse> IsEmailRegistered(string email);

        Task<BaseResponse> GetPlayerByEmail(string email);

        Task<BaseResponse> DeletePlayerByGuid(Guid guid);
    }
}
