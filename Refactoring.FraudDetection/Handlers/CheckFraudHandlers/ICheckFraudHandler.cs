using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.CheckFraudHandlers
{
    public interface ICheckFraudHandler : IHandler<CheckFraudRequest, FraudResult>
    {
    }
}
