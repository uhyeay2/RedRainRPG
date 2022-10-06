using RedRainRPG.Domain.Extensions;

namespace RedRainRPG.Domain.Tests.ExtensionTests
{
    [TestFixture]
    public class ValidationExtensionTests
    {
        public static readonly object[] ValidEmails = new[] { "a@a.com", "Example@Anywhere.eu", "another@email.co" };

        [TestCaseSource(nameof(ValidEmails))]
        public void IsValidEmailFormat_Given_ValidEmail_Should_ReturnTrue(string email) => Assert.That(email.IsValidEmailFormat(), Is.True);
    }
}
