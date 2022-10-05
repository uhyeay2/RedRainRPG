using RedRainRPG.Domain.Constants;
using RedRainRPG.Domain.Models.PlayerModels.PlayerResponses;

namespace RedRain.DataAccess.Tests.RepositoryTests.PlayerRepositoryTests
{
    public class IsEmailRegisteredTests : BasePlayerTest
    {
        [TestCase(null!)]
        [TestCase("")]
        [TestCase("   ")]
        public void IsEmailRegistered_Given_NullEmptyOrWhiteSpace_ShouldReturn_BadRequest400(string invalidInput) =>
            Assert.Multiple(async () =>
            {
                var result = await _repo.IsEmailRegistered(invalidInput);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.BadRequest_400));
                
                Assert.That(result.Message, Is.EqualTo("Email cannot be null empty or whitespace."));
            });

        [Test]
        public void IsEmailRegistered_Given_EmailIsRegistered_ShouldReturn_True() =>
            Assert.Multiple(async () =>
            {
                var email = "EmailRegistered";

                await InsertRecord(table: "Player", columns: "EmailAddress, AccountName", values: $"'{email}', 'AccountRegistered'");

                var result = await _repo.IsEmailRegistered(email);

                Assert.That(result, Is.Not.Null);
                
                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success_200));
                
                Assert.That(result.Message, Is.Empty);
                
                Assert.That(result is IsEmailRegisteredResponse response && response.IsRegistered);
            });

        [Test]
        public void IsEmailRegistered_Given_EmailNotRegistered_ShouldReturn_False() =>
            Assert.Multiple(async () =>
            {
                var result = await _repo.IsEmailRegistered("NoEmailRegistered");

                Assert.That(result, Is.Not.Null);
                
                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success_200));
                
                Assert.That(result.Message, Is.Empty);
                
                Assert.That(result is IsEmailRegisteredResponse response && !response.IsRegistered);
            });
    }
}
