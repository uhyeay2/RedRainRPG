using RedRain.DataAccess.Repositories;
using RedRainRPG.Domain.Interfaces.Repositories;

namespace RedRain.DataAccess.Tests.RepositoryTests
{
    [TestFixture]
    public class PlayerRepositoryTests : BaseRepositoryTest
    {
        private readonly IPlayerRepository _repo;

        public PlayerRepositoryTests()
        {
            _repo = new PlayerRepository(_mockedConfig.Object);
        }

        #region DeletePlayer

        [Test]
        public async Task DeletePlayer_Given_PlayerDeleted_ShouldReturn_One()
        {
            var guid = Guid.NewGuid();

            await InsertRecord("Player", "EmailAddress, AccountName, Guid", $"'Email', 'AccountName', '{guid}'");

            Assert.That(await _repo.DeletePlayerByGuid(guid), Is.EqualTo(1));
        }

        [Test]
        public async Task DeletePlayer_Given_PlayerNotDeleted_ShouldReturn_Zero() =>            
            Assert.That(await _repo.DeletePlayerByGuid(Guid.NewGuid()), Is.EqualTo(0));


        #endregion

        #region GetPlayerByEmail

        [Test]
        public async Task GetPlayerByEmail_Given_AccountIsRegistered_ShouldReturn_PlayerWithEmailProvided()
        {
            var email = "EmailRegistered";
            var account = "AccountRegistered";

            await InsertRecord("Player", "EmailAddress, AccountName", $"'{email}', '{account}'");

            var player = await _repo.GetPlayerByEmail(email);

            Assert.That(player, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(player.Guid, Is.Not.Empty);
                Assert.That(player.AccountName, Is.EqualTo(account));
                Assert.That(player.EmailAddress, Is.EqualTo(email));
            });
        }

        [Test]
        public async Task GetPlayerByEmail_Given_NoAccountIsFound_ShouldReturn_Null() =>
            Assert.That(await _repo.GetPlayerByEmail("NoAccountFound"), Is.Null);

        #endregion

        #region IsEmailRegistered

        [Test]
        public async Task IsEmailRegistered_Given_EmailNotRegistered_ShouldReturn_False() =>
            Assert.That(await _repo.IsEmailRegistered("NoAccountFound"), Is.False);

        [Test]
        public async Task IsEmailRegistered_Given_EmailIsRegistered_ShouldReturn_True()
        {
            var email = "EmailRegistered";

            await InsertRecord("Player", "EmailAddress, AccountName", $"'{email}', 'Account'");
            Assert.That(await _repo.IsEmailRegistered(email), Is.True);
        }

        #endregion

        #region RegisterPlayer

        [Test]
        public async Task RegisterPlayer_Given_EmailIsAlreadyRegistered_ShouldReturn_NegativeOne()
        {
            var email = "EmailAlreadyRegistered";

            await InsertRecord("Player", "EmailAddress, AccountName", $"'{email}', 'AccountName'");

            Assert.That(await _repo.RegisterPlayerAsync(email, "NewAccountName"), Is.EqualTo(-1));
        }

        [Test]
        public async Task RegisterPlayer_Given_AccountIsAlreadyRegistered_ShouldReturn_NegativeOne()
        {
            var account = "AccountAlreadyRegistered";

            await InsertRecord("Player", "EmailAddress, AccountName", $"'email', '{account}'");

            Assert.That(await _repo.RegisterPlayerAsync("NewEmail", account), Is.EqualTo(-1));
        }

        [Test]
        public async Task RegisterPlayer_Given_NewAccountAndEmail_ShouldReturn_One() =>
            Assert.That(await _repo.RegisterPlayerAsync("NewEmail", "NewAccount"), Is.EqualTo(1));

        #endregion
    }
}
