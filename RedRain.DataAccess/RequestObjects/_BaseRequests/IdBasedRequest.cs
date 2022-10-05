using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    public abstract class IdBasedRequest : IRequestObject
    {
        public int Id { get; set; }

        public IdBasedRequest(int id)
        {
            Id = id;
        }

        public IdBasedRequest() { }

        public object? GenerateParameters() => new { Id };

        public abstract string GenerateSql();
    }
}
