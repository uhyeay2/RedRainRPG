namespace RedRain.DataAccess.Attributes.SQLGeneration
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class SqlScriptAttribute : Attribute
    {
        public string Table { get; set; }

        private readonly string? _where;

        public string Where => string.IsNullOrWhiteSpace(_where) ? string.Empty : "WHERE " + _where;

        public SqlScriptAttribute(string table)
        {
            Table = table;
        }

        public SqlScriptAttribute(string table, string where) : this(table)
        {
            _where = where;
        }
    }
}
