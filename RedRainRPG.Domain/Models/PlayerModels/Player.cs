namespace RedRainRPG.Domain.Models.PlayerModels
{
    public class Player
    {
        public Player(string emailAddress, string accountName, Guid guid)
        {
            EmailAddress = emailAddress;
            AccountName = accountName;
            Guid = guid;
        }

        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public Guid Guid { get; set; }
    }
}
