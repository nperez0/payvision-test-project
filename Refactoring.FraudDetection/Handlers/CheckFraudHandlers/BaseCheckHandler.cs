using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.CheckFraudHandlers
{
    public abstract class BaseCheckHandler : ICheckFraudHandler
    {
        public FraudResult Handle(CheckFraudRequest request)
            => CheckFraud(request.Current, request.Other)
            ? NewFraud(request.Other)
            : FraudResult.NonFraud;

        protected abstract bool CheckFraud(Order current, Order other);

        static FraudResult NewFraud(Order order)
            => FraudResult.NewFraud(order.OrderId);
    }
}
