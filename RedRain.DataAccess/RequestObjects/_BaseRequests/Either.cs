namespace RedRain.DataAccess.RequestObjects._BaseRequests
{
    internal abstract class Either<TLeft, TRight>
    {
        public readonly TLeft? Left;
        public readonly TRight? Right;
        public readonly bool IsLeft;

        public Either(TLeft? left)
        {
            Left = left;
            IsLeft = true;
        }

        public Either(TRight? right)
        {
            Right = right;
            IsLeft = false;
        }
    }
}
