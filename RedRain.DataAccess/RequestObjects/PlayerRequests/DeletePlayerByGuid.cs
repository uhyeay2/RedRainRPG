using RedRain.DataAccess.RequestObjects._BaseRequests;

namespace RedRain.DataAccess.RequestObjects.PlayerRequests
{
    internal class DeletePlayerByGuid : GuidBasedRequest
    {        
        public DeletePlayerByGuid(string guid) : base(guid)
        {
        }

        public DeletePlayerByGuid(Guid? guid) : base(guid)
        {
        }

        public override string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Delete("Player", "Guid = @Guid");
    }
}
