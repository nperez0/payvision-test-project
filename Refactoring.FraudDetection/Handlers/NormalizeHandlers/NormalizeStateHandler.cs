using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.NormalizeHandlers
{
    public class NormalizeStateHandler : IHandler<Order>
    {
        public Order Handle(Order request)
            => request.UpdateAddress(NormalizeState(request.Address));

        static Address NormalizeState(Address address)
            => address.UpdateState(Normalize(address.State));

        static string Normalize(string state)
            => state
                .Replace("il", "illinois")
                .Replace("ca", "california")
                .Replace("ny", "new york");
    }
}
