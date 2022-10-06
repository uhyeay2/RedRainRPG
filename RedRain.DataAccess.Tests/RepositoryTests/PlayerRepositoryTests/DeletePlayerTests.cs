using RedRainRPG.Domain.Constants;
using RedRainRPG.Domain.Models.BaseModels.BaseResponses;

namespace RedRain.DataAccess.Tests.RepositoryTests.PlayerRepositoryTests
{
    public class DeletePlayerTests : BasePlayerTest
    {
        public static readonly object[] NullAndEmptyGuids = new object[] { Guid.Empty, null! };

        [TestCaseSource(nameof(NullAndEmptyGuids))]
        public void DeletePlayer_Given_InvalidGuid_ShouldReturn_BadRequest400(Guid invalidGuid) =>
            Assert.Multiple(async () =>
            {
                var invalidGuid = Guid.NewGuid();

                var result = await _repo.DeletePlayerByGuid(invalidGuid);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.NotFound_404));

                Assert.That(result.Message, Is.EqualTo($"There was no Player found with the guid: {invalidGuid}"));
            });

        [Test]
        public void DeletePlayer_Given_NoPlayerExists_ShouldReturn_NotFound404() =>
            Assert.Multiple(async () =>
            {
                var guid = Guid.NewGuid();

                var result = await _repo.DeletePlayerByGuid(guid);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.NotFound_404));

                Assert.That(result.Message, Is.EqualTo($"There was no Player found with the guid: {guid}"));
            });

        [Test]
        public void DeletePlayer_Given_PlayerExists_ShouldReturn_Success200() =>
            Assert.Multiple(async () =>
            {
                var guid = Guid.NewGuid();

                await InsertRecord(table: "Player", columns: "EmailAddress, AccountName, Guid", values: $"'Email', 'AccountName', N'{guid}'");

                var result = await _repo.DeletePlayerByGuid(guid);

                Assert.That(result, Is.Not.Null);

                Assert.That(result.StatusCode, Is.EqualTo(StatusCode.Success_200));

                Assert.That(result.Message, Is.Empty);

                Assert.That(result is ExecutionResponse response && response.RowsAffected == 1);
            });
    }
}
