namespace RedRain.DataAccess.Attributes.SQLGeneration.InsertAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InsertQuery : SqlScriptAttribute
    {
        public InsertQuery(string table) : base(table)
        {
        }

        public InsertQuery(string table, string from, string where) : base(table, where)
        {
            From = from;
        }


        public InsertQuery(string table, string ifNotExists) : base(table)
        {
            IfNotExists = ifNotExists;
        }

        public string IfNotExists { get; set; } = string.Empty;

        public bool IsInsertSelectRequest => !string.IsNullOrWhiteSpace(From);

        public string From { get; set; } = string.Empty;

        public string Join { get; set; } = string.Empty;

        public string GetValuesToInsert(string values) => IsInsertSelectRequest ? $"SELECT {values} FROM {From} {Join} {Where} " : $"VALUES ( {values} )";
    }
}
