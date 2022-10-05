using RedRain.DataAccess.Interfaces;

namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    internal abstract class EitherByIntOrGuid : Either<int?, Guid?>, IRequestObject
    {

        public EitherByIntOrGuid(int? left) : base(left)
        {
        }

        public EitherByIntOrGuid(Guid? right) : base(right)
        {
        }

        public EitherByIntOrGuid(string right) : base(Guid.TryParse(right, out var guid) ? guid : Guid.Empty)
        {
        }

        public object? GenerateParameters() => new { Left, Right };

        public abstract string GenerateSql();
    }
}
