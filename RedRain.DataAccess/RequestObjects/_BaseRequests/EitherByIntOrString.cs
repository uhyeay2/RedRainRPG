using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    internal abstract class EitherByIntOrString : Either<int?, string?>, IRequestObject
    {
        public EitherByIntOrString(int? left) : base(left)
        {
        }

        public EitherByIntOrString(string? right) : base(right)
        {
        }

        public object? GenerateParameters() => new { Left, Right };

        public abstract string GenerateSql();
    }
}
