using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    public abstract class ParameterlessRequest : IRequestObject
    {
        public object? GenerateParameters()
        {
            return null;
        }

        public abstract string GenerateSql();
    }
}
