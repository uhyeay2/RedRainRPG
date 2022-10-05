using Dapper;
using RedRain.DataAccess.Interfaces;
using RedRainRPG.Domain.Constants;
using RedRainRPG.Domain.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RedRain.DataAccess.Tests")]
[assembly: InternalsVisibleTo("RedRainRPG.API")]
namespace RedRain.DataAccess
{
    internal class RepositoryBase : IRepository
    {
        private readonly IConfig _config;

        private readonly string _configKeyName;

        #region Constructors

        internal RepositoryBase(IConfig config, string configKeyName)
        {
            _config = config;
            _configKeyName = configKeyName;
        }

        internal RepositoryBase(IConfig config) : this(config, ConfigKeyNames.RedRainRPGDatabase) { }

        #endregion

        #region Fetch

        public async Task<TOutput?> FetchAsync<TInput, TOutput>(TInput request) where TInput : IRequestObject =>
            (await FetchListAsync<TInput, TOutput>(request)).FirstOrDefault();

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TOutput>(TInput request) where TInput : IRequestObject
        {
            using var connection = GetNewConnection();

            connection.Open();

            return await connection.QueryAsync<TOutput>(request.GenerateSql(), request.GenerateParameters());
        }

        #endregion

        #region Execute

        public async Task<int> ExecuteAsync<TInput>(TInput request) where TInput : IRequestObject
        {
            using var connection = GetNewConnection();

            connection.Open();

            return await connection.ExecuteAsync(request.GenerateSql(), request.GenerateParameters());
        }

        #endregion

        #region Fetch With Split On

        public async Task<IEnumerable<TOutput>> FetchListAsync<TInput, TFirst, TSecond, TOutput>(TInput request, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id") where TInput : IRequestObject
        {
            using var connection = GetNewConnection();

            connection.Open();

            return await connection.QueryAsync(request.GenerateSql(), objectMapSettings, request.GenerateParameters(), splitOn: splitOn);
        }

        public async Task<TOutput?> FetchAsync<TInput, TFirst, TSecond, TOutput>(TInput request, Func<TFirst, TSecond, TOutput> objectMapSettings, string splitOn = "Id") where TInput : IRequestObject =>
            (await FetchListAsync(request, objectMapSettings, splitOn)).FirstOrDefault();

        #endregion

        private System.Data.SqlClient.SqlConnection GetNewConnection() => new(_config.GetConnectionString(_configKeyName));
    }
}
