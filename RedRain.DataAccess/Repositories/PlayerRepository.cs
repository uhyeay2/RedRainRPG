using RedRain.DataAccess.DataTransferObjects;
using RedRain.DataAccess.RequestObjects.PlayerRequests;
using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Interfaces.Repositories;
using RedRainRPG.Domain.Models;

namespace RedRain.DataAccess.Repositories
{
    internal class PlayerRepository : RepositoryBase, IPlayerRepository
    {
        public PlayerRepository(IConfig config) : base(config) { }

        public async Task<int> DeletePlayerByGuid(Guid guid) => await ExecuteAsync(new DeletePlayerByGuid(guid));

        public async Task<Player?> GetPlayerByEmail(string email) => (await FetchAsync<GetPlayerByEmail, PlayerDTO>(new(email)))?.ToPlayer();
       
        public async Task<bool> IsEmailRegistered(string email) => await FetchAsync<IsEmailRegistered, bool>(new(email));
  
        public async Task<int> RegisterPlayerAsync(string emailAddress, string accountName) => await ExecuteAsync(new RegisterPlayer(emailAddress, accountName));
    }
}
