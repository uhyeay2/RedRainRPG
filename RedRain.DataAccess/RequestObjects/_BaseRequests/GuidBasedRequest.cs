using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    public abstract class GuidBasedRequest : IRequestObject
    {
        public virtual Guid? Guid { get; set; }

        public GuidBasedRequest() { }

        public GuidBasedRequest(string guid)
        {
            Guid = System.Guid.TryParse(guid, out var g) ? g : System.Guid.Empty;
        }

        public GuidBasedRequest(Guid? guid)
        {
            Guid = guid;
        }

        public virtual object? GenerateParameters() => new { Guid };

        public abstract string GenerateSql();
    }
}
