using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    internal abstract class EmailBasedRequest : IRequestObject
    {
        protected EmailBasedRequest(string email)
        {
            Email = email;
        }

        public string Email { get; set; }

        public object? GenerateParameters() => new { Email };

        public abstract string GenerateSql();
    }
}
