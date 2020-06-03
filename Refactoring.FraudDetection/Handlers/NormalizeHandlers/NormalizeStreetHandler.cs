using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.NormalizeHandlers
{
    public class NormalizeStreetHandler : IHandler<Order>
    {
        public Order Handle(Order request)
            => request.UpdateAddress(NormalizeStreet(request.Address));

        static Address NormalizeStreet(Address address)
            => address.UpdateStreet(Normalize(address.Street));

        static string Normalize(string street)
            => street
                .Replace("st.", "street")
                .Replace("rd.", "road");
    }
}
