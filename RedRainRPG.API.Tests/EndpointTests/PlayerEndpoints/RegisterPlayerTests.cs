using Microsoft.AspNetCore.Http;
using Moq;
using RedRainRPG.API.Endpoints.PlayerEndpoints;
using RedRainRPG.Domain.Interfaces.Repositories;

namespace RedRainRPG.API.Tests.EndpointTests.PlayerEndpoints
{
    [TestFixture]
    public class RegisterPlayerTests
    {
        private readonly RegisterPlayer _endpoint;

        private readonly Mock<IPlayerRepository> _mockedPlayerRepo;

        public RegisterPlayerTests()
        {
            _mockedPlayerRepo = new();

            _endpoint = new(_mockedPlayerRepo.Object);
        }

        public static readonly object[] InvalidStringInputs = new[] { string.Empty, "   ", null! };

        [TestCaseSource(nameof(InvalidStringInputs))]
        public async Task RegisterPlayer_Given_InvalidEmail_ShouldReturn_BadRequest400(string invalidEmail) => 
            Assert.That((await _endpoint.ExecuteAsync(new(invalidEmail, "Account"))).StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));


        [TestCaseSource(nameof(InvalidStringInputs))]
        public async Task RegisterPlayer_Given_InvalidAccountName_ShouldReturn_BadRequest400(string invalidAccount) =>
            Assert.That((await _endpoint.ExecuteAsync(new("Email", invalidAccount))).StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
    }
}
