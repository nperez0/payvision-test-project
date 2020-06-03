using System;

namespace Refactoring.FraudDetection
{
    public struct Chain<T>
    {
        public T Value { get; }

        private Chain(T value)
        {
            Value = value;
        }

        public Chain<T> ContinueIf(Func<T> next, Func<T, bool> continueIf)
            => continueIf(Value)
                ? new Chain<T>(next())
                : new Chain<T>(Value);

        public Chain<T> ContinueWith(Func<T> next)
            => new Chain<T>(next());

        public static implicit operator Chain<T>(T value)
            => new Chain<T>(value);

        public static implicit operator T(Chain<T> chain)
            => chain.Value;
    }
}
