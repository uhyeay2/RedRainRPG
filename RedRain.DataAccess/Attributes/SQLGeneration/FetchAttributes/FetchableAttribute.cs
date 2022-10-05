namespace RedRain.DataAccess.Attributes.SQLGeneration.FetchAttributes
{
    public class FetchableAttribute : SqlPropertyIdentiferAttribute
    {
        public FetchableAttribute()
        {
        }

        public FetchableAttribute(string specifiedDatabaseName) : base(specifiedDatabaseName)
        {
        }
    }
}
