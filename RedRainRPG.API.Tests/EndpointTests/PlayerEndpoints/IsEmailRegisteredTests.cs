using Moq;
using RedRainRPG.API.Endpoints.PlayerEndpoints;
using RedRainRPG.Domain.Constants;
using RedRainRPG.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRainRPG.API.Tests.EndpointTests.PlayerEndpoints
{
    internal class IsEmailRegisteredTests
    {
        private readonly IsEmailRegistered _endpoint;

        private readonly Mock<IPlayerRepository> _mockedPlayerRepo;

        public IsEmailRegisteredTests()
        {
            _mockedPlayerRepo = new();

            _endpoint = new(_mockedPlayerRepo.Object);
        }

        public static readonly object[] InvalidEmailInputs = new[] { string.Empty, "   ", null!, "a@a" };

        [TestCaseSource(nameof(InvalidEmailInputs))]
        public async Task RegisterPlayer_Given_InvalidEmail_ShouldReturn_BadRequest400(string invalidEmail) =>
            Assert.That((await _endpoint.ExecuteAsync(new(invalidEmail))).StatusCode, Is.EqualTo(StatusCode.BadRequest_400));
    }
}
