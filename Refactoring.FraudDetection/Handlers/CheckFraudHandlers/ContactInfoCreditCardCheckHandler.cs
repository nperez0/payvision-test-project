using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.CheckFraudHandlers
{
    public class ContactInfoCreditCardCheckHandler : BaseCheckHandler
    {
        protected override bool CheckFraud(Order current, Order other)
            => current.DealId == other.DealId
                    && current.Address.Equals(other.Address)
                    && current.CreditCard != other.CreditCard;
    }
}
