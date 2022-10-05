using Moq;
using RedRain.DataAccess.Interfaces;
using RedRain.DataAccess.RequestObjects._BaseRequests;
using RedRainRPG.Domain.Interfaces;

namespace RedRain.DataAccess.Tests.RepositoryTests
{
    public abstract class BaseRepositoryTest
    {
        protected readonly Mock<IConfig> _mockedConfig = new();

        readonly TestDatabaseRepository _database;

        public BaseRepositoryTest()
        {
            _mockedConfig.Setup(_ => _.GetConnectionString(It.IsAny<string>())).Returns(Hidden.TestEnvDatabaseConnectionString);
            _database = new TestDatabaseRepository(_mockedConfig.Object);
        }

        protected async Task InsertRecord(string table, string columns, string values) => await _database.Insert(table, columns, values);

        [TearDown]
        public async Task TearDownAsync()
        {
            await _database.ClearAllTables();
        }
    }

    internal class TestDatabaseRepository : RepositoryBase
    {
        internal TestDatabaseRepository(IConfig config) : base(config) { }

        public async Task ClearAllTables()
        {
            await ExecuteAsync(new ClearTable("Player"));
        }

        public async Task Insert(string table, string columns, string values) => await ExecuteAsync(new InsertRecord(table, columns, values));

        private class InsertRecord : IRequestObject
        {
            public InsertRecord(string table, string columns, string values)
            {
                Table = table;
                Columns = columns;
                Values = values;
            }

            public string Table { get; set; }
            public string Columns { get; set; }
            public string Values { get; set; }

            public object? GenerateParameters() => new { Table, Columns, Values };

            public string GenerateSql() => $"INSERT INTO {Table} ( {Columns} ) VALUES ( {Values} )";
        }

        private class ClearTable : ParameterlessRequest
        {
            public ClearTable(string table)
            {
                Table = table;
            }

            public string Table { get; set; }

            public override string GenerateSql() => $"DELETE FROM {Table}";
        }
    }
}
