using RedRain.DataAccess.Attributes.SQLGeneration.FetchAttributes;
using RedRain.DataAccess.Attributes.SQLGeneration.InsertAttributes;
using RedRain.DataAccess.Attributes.SQLGeneration.UpdateAttributes;
using RedRain.DataAccess.Extensions;

namespace RedRain.DataAccess
{
    public static class SqlGenerator
    {
        public static string Fetch(Type dto, string? whereOverride = null)
        {
            var propertyAttributes = dto.GetSqlProperties<FetchableAttribute>();

            var itemsToSelect = !propertyAttributes.Any() ? "*" : propertyAttributes.Select(p =>
                    $"{p.Attribute.SpecifiedDatabaseNameOr(p.PropertyName)} as {p.PropertyName}").AggregateWithCommaNewLine();

            if (Attribute.GetCustomAttribute(dto, typeof(FetchQuery)) is not FetchQuery queryDetails)
            {
                throw new ApplicationException($"{dto} Must Contain The FetchQuery Attribute For SQL Generation.");
            }

            var where = !string.IsNullOrWhiteSpace(whereOverride) ? "WHERE " + whereOverride : queryDetails.Where;

            return $"SELECT {itemsToSelect} FROM {queryDetails.Table} {queryDetails.Joins} {where} {queryDetails.OrderBy}";
        }

        public static string Insert(Type requestObject)
        {
            var propertyAttributes = requestObject.GetSqlProperties<InsertableAttribute>();

            if (!propertyAttributes.Any())
            {
                throw new ApplicationException($"Request Object {requestObject} Must contain properties with the Insertable attribute.");
            }

            if (Attribute.GetCustomAttributes(requestObject, typeof(InsertQuery)) is not InsertQuery[] requests || !requests.Any())
            {
                throw new ApplicationException($"{requestObject} Must Contain The InsertQuery Attribute For SQL Generation.");
            }

            var inserts = requests.Select(r =>
            {
                IEnumerable<(string ColumnName, string ValueName)> items = propertyAttributes.Where(p => p.Attribute.TableName == r.Table)
                    .Select(x => (x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName), x.Attribute.ColumnNameToFetchOr(x.PropertyName)));

                var declareAndSetScopedIdentity = string.Empty;

                if (propertyAttributes.Any(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity))
                {
                    var scopedProperty = propertyAttributes.FirstOrDefault(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity);

                    declareAndSetScopedIdentity = $"DECLARE @{scopedProperty.PropertyName} {scopedProperty.Attribute.SqlTypeName} = SCOPE_IDENTITY() ";
                }

                var insertIntoTableColumns = $"INSERT INTO \n {r.Table} \n ( \n {items.Select(x => x.ColumnName).AggregateWithCommaNewLine()} \n ) ";

                var valuesToInsert = r.GetValuesToInsert(items.Select(v => v.ValueName).AggregateWithCommaNewLine());

                var beginInsertIfNotExists = string.IsNullOrWhiteSpace(r.IfNotExists) ? string.Empty : $"\n IF NOT EXISTS \n ( {r.IfNotExists} ) \n BEGIN \n";
                var endInsertIfNotExists = string.IsNullOrWhiteSpace(r.IfNotExists) ? string.Empty : "\n END ";

                return $"{declareAndSetScopedIdentity} \n {beginInsertIfNotExists} {insertIntoTableColumns} {valuesToInsert} {endInsertIfNotExists}";

            }).Aggregate((a, b) => $"{a} \n \n {b}");

            return propertyAttributes.Any(x => x.Attribute.UseScopedIdentity) ? $"BEGIN TRANSACTION \n {inserts} \n COMMIT TRANSACTION" : inserts;
        }

        public static string Update(Type requestObject)
        {
            var propertyAttributes = requestObject.GetSqlProperties<UpdatableAttribute>();

            if (!propertyAttributes.Any())
            {
                throw new ApplicationException($"Request Object {requestObject} Must contain properties with an Updatable attribute.");
            }

            if (Attribute.GetCustomAttribute(requestObject, typeof(UpdateQuery)) is not UpdateQuery request)
            {
                throw new ApplicationException($"{requestObject} Must Contain The UpdateQuery Attribute For SQL Generation.");
            }

            var items = propertyAttributes.Select(x => x.Attribute.IsCoalesceUpdate ?
                $"{x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName)} = COALESCE ( @{x.PropertyName} , {x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName)} ) "
                : $"{x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName)} = ${x.PropertyName}"
                ).AggregateWithCommaNewLine();

            return $"UPDATE \n {request.Table} \n SET \n {items} \n {request.Where}";
        }

        public static string Delete(string table, string where) => $"DELETE FROM {table} WHERE {where}";

        public static string SelectExists(string table, string condition, string column = "*") => $"SELECT CASE WHEN EXISTS(SELECT {column} FROM {table} WHERE {condition}) THEN 1 ELSE 0 END";
    }

}
