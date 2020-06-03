using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.CheckFraudHandlers
{
    public struct CheckFraudRequest
    {
        public Order Current { get; }

        public Order Other { get; }

        private CheckFraudRequest(Order current, Order other)
        {
            Current = current;
            Other = other;
        }

        public static CheckFraudRequest NewRequest(Order current, Order other)
            => new CheckFraudRequest(current, other);
    }
}
