namespace RedRain.DataAccess.Attributes.SQLGeneration
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class SqlPropertyIdentiferAttribute : Attribute
    {
        /// <summary>
        /// SpecifiedColumnName is be to used when getting DTOProperties for Sql Procedures. If SpecifiedColumnName is left null then the PropertyName will be used.
        /// </summary>
        public string? SpecifiedDatabaseName { get; set; } = null;

        public SqlPropertyIdentiferAttribute()
        {

        }

        protected SqlPropertyIdentiferAttribute(string specifiedDatabaseName)
        {
            SpecifiedDatabaseName = specifiedDatabaseName;
        }

        public string SpecifiedDatabaseNameOr(string otherName) => string.IsNullOrWhiteSpace(SpecifiedDatabaseName) ? otherName : SpecifiedDatabaseName;
    }
}
