using RedRain.DataAccess.Attributes.SQLGeneration;
using System.Reflection;

namespace RedRain.DataAccess.Extensions
{
    internal static class SqlGenerationExtensions
    {
        /// <summary>
        /// Aggregate a collection of strings with ((a, b) => $"{a},\n {b}") - This helps to increase readability for generated scripts.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static string AggregateWithCommaNewLine(this IEnumerable<string> strings) => 
            strings?.Any() ?? false ? strings.Aggregate((a, b) => $"{a},\n {b}") : string.Empty;

        /// <summary>
        /// Get the (PropertyName, Attribute) for all properties that contain the custom attribute TPropertyIdentifier from the Type provided.
        /// TPropertyIdentifier must be a SqlPropertyIdentifierAttribute.
        /// </summary>
        /// <typeparam name="TPropertyIdentifier"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<(string PropertyName, TPropertyIdentifier Attribute)> GetSqlProperties<TPropertyIdentifier>(this Type type) 
            where TPropertyIdentifier : SqlPropertyIdentiferAttribute => 
            type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(c => c.CustomAttributes.Any(a => a.AttributeType == typeof(TPropertyIdentifier)))?
                    .Select(p => (p.Name, (Attribute.GetCustomAttribute(p, typeof(TPropertyIdentifier)) as TPropertyIdentifier)!))
                        ?? Enumerable.Empty<(string, TPropertyIdentifier)>();
    }
}
