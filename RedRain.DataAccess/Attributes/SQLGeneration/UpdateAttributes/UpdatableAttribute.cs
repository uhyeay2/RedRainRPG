namespace RedRain.DataAccess.Attributes.SQLGeneration.UpdateAttributes
{
    public class UpdatableAttribute : SqlPropertyIdentiferAttribute
    {

        public UpdatableAttribute(bool isCoalesceUpdate)
        {
            IsCoalesceUpdate = isCoalesceUpdate;
        }

        public UpdatableAttribute(bool isCoalesceUpdate, string specifiedDatabaseName) : base(specifiedDatabaseName)
        {
            IsCoalesceUpdate = isCoalesceUpdate;
        }

        public UpdatableAttribute()
        {
        }

        public UpdatableAttribute(string specifiedDatabaseName) : base(specifiedDatabaseName)
        {
        }

        public bool IsCoalesceUpdate { get; set; }
    }
}
