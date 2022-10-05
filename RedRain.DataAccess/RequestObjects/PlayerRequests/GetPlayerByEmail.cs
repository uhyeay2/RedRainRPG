using RedRain.DataAccess.DataTransferObjects;
using RedRain.DataAccess.RequestObjects._BaseRequests;

namespace RedRain.DataAccess.RequestObjects.PlayerRequests
{
    internal class GetPlayerByEmail : EmailBasedRequest
    {
        public GetPlayerByEmail(string email) : base(email)
        {
        }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Fetch(typeof(PlayerDTO));
    }
}
