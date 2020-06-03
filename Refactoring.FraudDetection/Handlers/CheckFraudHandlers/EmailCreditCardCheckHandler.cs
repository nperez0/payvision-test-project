using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.CheckFraudHandlers
{
    public class EmailCreditCardCheckHandler : BaseCheckHandler
    {
        protected override bool CheckFraud(Order current, Order other)
            => current.DealId == other.DealId
                    && current.Email.Equals(other.Email)
                    && current.CreditCard != other.CreditCard;
    }
}
