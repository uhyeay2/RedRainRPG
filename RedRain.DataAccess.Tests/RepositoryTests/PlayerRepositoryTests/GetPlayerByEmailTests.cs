using RedRainRPG.Domain.Constants;

namespace RedRain.DataAccess.Tests.RepositoryTests.PlayerRepositoryTests
{
    public class GetPlayerByEmailTests : BasePlayerTest
    {
        [TestCase(null!)]
        [TestCase("")]
        [TestCase("   ")]
        public void GetPlayerByEmail_Given_NullEmptyOrWhiteSpace_ShouldReturn_BadRequest400(string invalidInput) =>
            Assert.Multiple(async () =>
            {
                var result = await _repo.GetPlayerByEmail(invalidInput);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.BadRequest_400));

                Assert.That(result.Message, Is.EqualTo("Email cannot be null empty or whitespace."));
            });

        [Test]
        public void GetPlayerByEmail_Given_PlayerDoesNotExist_ShouldReturn_NotFound404() => 
            Assert.Multiple(async () =>
            {
                var email = "EmailNotFound";

                var result = await _repo.GetPlayerByEmail(email);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.NotFound_404));
                
                Assert.That(result.Message, Is.EqualTo($"No Player found with the email: {email}"));
            });

        [Test]
        public void GetPlayerByEmail_Given_PlayerExists_ShouldReturn_Success200() => 
            Assert.Multiple(async () =>
            {
                var email = "EmailNotFound";

                var result = await _repo.GetPlayerByEmail(email);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.NotFound_404));

                Assert.That(result.Message, Is.EqualTo($"No Player found with the email: {email}"));
            });
    }
}
