namespace RedRain.DataAccess.Attributes.SQLGeneration.InsertAttributes
{
    public class InsertableAttribute : SqlPropertyIdentiferAttribute
    {
        public InsertableAttribute(string tableName)
        {
            TableName = tableName;
        }

        public InsertableAttribute(string tableName, bool useScopedIdentity, string sqlTypeName = "INT") : this(tableName)
        {
            UseScopedIdentity = useScopedIdentity;
            SqlTypeName = sqlTypeName;
        }

        public InsertableAttribute(string tableName, string specifiedDatabaseName) : this(tableName)
        {
            SpecifiedDatabaseName = specifiedDatabaseName;
        }

        public InsertableAttribute(string tableName, string specifiedDatabaseName, string columnNameToFetch) : this(tableName, specifiedDatabaseName)
        {
            ColumnNameToFetch = columnNameToFetch;
        }

        public bool UseScopedIdentity;

        public string? SqlTypeName { get; set; }

        public string TableName { get; set; }

        public string ColumnNameToFetchOr(string propertyName) => string.IsNullOrWhiteSpace(ColumnNameToFetch) ? $"@{propertyName}" : ColumnNameToFetch;

        public string ColumnNameToFetch { get; set; } = string.Empty;

        public string DeclareAndSetScopedIdentity(string parameterName) => UseScopedIdentity ? $"DECLARE @{parameterName} {SqlTypeName} = SCOPE_IDENTITY() " : string.Empty;
    }
}
