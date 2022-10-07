using RedRainRPG.Domain.Models;

namespace RedRainRPG.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<int> RegisterPlayerAsync(string emailAddress, string accountName);

        Task<bool> IsEmailRegistered(string email);

        Task<Player?> GetPlayerByEmail(string email);

        Task<int> DeletePlayerByGuid(Guid guid);
    }
}
