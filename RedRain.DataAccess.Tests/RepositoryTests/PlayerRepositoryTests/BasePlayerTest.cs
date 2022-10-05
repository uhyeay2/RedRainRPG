
using RedRain.DataAccess.Repositories;
using RedRainRPG.Domain.Interfaces.Repositories;

namespace RedRain.DataAccess.Tests.RepositoryTests.PlayerRepositoryTests
{
    [TestFixture]
    public class BasePlayerTest : BaseRepositoryTest
    {
        protected IPlayerRepository _repo;

        public BasePlayerTest()
        {
            _repo = new PlayerRepository(_mockedConfig.Object);
        }
    }
}
