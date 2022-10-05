using RedRainRPG.Domain.Interfaces;

namespace RedRainRPG.API.Config
{
    public class RedRainRPGConfig : IConfig
    {
        public string GetConnectionString(string connectionStringName) => GetIConfigurationRoot()[Domain.Constants.ConfigKeyNames.RedRainRPGDatabase];

        public static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder().AddJsonFile(Domain.Constants.ConfigKeyNames.AppSettings).Build();
    }
}
