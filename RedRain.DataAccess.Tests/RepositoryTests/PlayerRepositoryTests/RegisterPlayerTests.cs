using RedRainRPG.Domain.Constants;
using RedRainRPG.Domain.Models.BaseModels;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

namespace RedRain.DataAccess.Tests.RepositoryTests.PlayerRepositoryTests
{
    [TestFixture]
    public class RegisterPlayerTests : BasePlayerTest
    {
        private readonly RegisterPlayerRequest _testRequest = new("TestEmail", "TestAccount");

        [Test]
        public void RegisterPlayer_Given_RequestIsValid_ShouldReturn_Success200() => 
            Assert.Multiple(async () =>
            {
                var result = await _repo.RegisterPlayerAsync(_testRequest);
                
                Assert.That(result, Is.Not.Null);
                
                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success_200));
                
                Assert.That(result.Message, Is.Empty);

                Assert.That(result is ExecutionResponse executionResponse && executionResponse.RowsAffected.Equals(1));
            });

        [Test]
        public void RegisterPlayer_Given_EmailAlreadyRegistered_ShouldReturn_BadRequest400() =>
            Assert.Multiple(async () =>
            {
                await _repo.RegisterPlayerAsync(_testRequest);

                var emailAlreadyTakenRequest = new RegisterPlayerRequest(_testRequest.EmailAddress!, $"NEW{_testRequest.AccountName}");

                var result = await _repo.RegisterPlayerAsync(emailAlreadyTakenRequest);

                Assert.That(result, Is.Not.Null);
                
                Assert.That(result.StatusCode, Is.EqualTo(400));
                
                Assert.That(result.Message, Is.EqualTo("An account is already registered with this email or account name."));
            });

        [Test]
        public void RegisterPlayer_Given_AccountAlreadyRegistered_ShouldReturn_BadRequest400() =>
            Assert.Multiple(async () =>
            {
                await _repo.RegisterPlayerAsync(_testRequest);

                var emailAlreadyTakenRequest = new RegisterPlayerRequest($"NEW{_testRequest.EmailAddress!}", _testRequest.AccountName!);

                var result = await _repo.RegisterPlayerAsync(emailAlreadyTakenRequest);

                Assert.That(result, Is.Not.Null);
                
                Assert.That(result.StatusCode, Is.EqualTo(400));
                
                Assert.That(result.Message, Is.EqualTo("An account is already registered with this email or account name."));
            });
    }
}
