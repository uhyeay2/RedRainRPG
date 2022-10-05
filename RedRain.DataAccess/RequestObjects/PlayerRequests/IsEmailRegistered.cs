using RedRain.DataAccess.RequestObjects._BaseRequests;

namespace RedRain.DataAccess.RequestObjects.PlayerRequests
{
    internal class IsEmailRegistered : EmailBasedRequest
    {
        public IsEmailRegistered(string email) : base(email)
        {
        }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.SelectExists("Player", "EmailAddress = @Email");
    }
}
