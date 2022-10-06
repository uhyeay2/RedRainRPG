using System.Text.RegularExpressions;

namespace RedRainRPG.Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static bool IsValidEmailFormat(this string str) => !string.IsNullOrWhiteSpace(str) && new Regex(@".+@.+\..+").IsMatch(str);

        public static bool IsNullOrEmpty(this Guid? guid) => guid == null || guid == Guid.Empty;
    }
}
