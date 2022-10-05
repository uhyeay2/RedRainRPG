using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    public abstract class LongIdBasedRequest : IRequestObject
    {
        public long Id { get; set; }

        public LongIdBasedRequest(long id)
        {
            Id = id;
        }

        public LongIdBasedRequest() { }

        public object? GenerateParameters() => new { Id };

        public abstract string GenerateSql();
    }
}
