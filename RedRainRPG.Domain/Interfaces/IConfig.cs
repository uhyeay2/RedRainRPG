namespace RedRainRPG.Domain.Interfaces
{
    public interface IConfig
    {
        public string GetConnectionString(string connectionStringName);
    }
}
