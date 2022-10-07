using RedRain.DataAccess.Attributes.SQLGeneration.FetchAttributes;
using RedRainRPG.Domain.Models;

namespace RedRain.DataAccess.DataTransferObjects
{
    [FetchQuery("Player", "EmailAddress = @Email")]
    internal class PlayerDTO
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string AccountName { get; set; } = null!;

        public Guid Guid { get; set; }

        public Player ToPlayer() => new(EmailAddress, AccountName, Guid);
    }
}
