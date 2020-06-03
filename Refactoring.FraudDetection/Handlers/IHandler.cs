namespace Refactoring.FraudDetection.Handlers
{
    public interface IHandler<TRequest>
    {
        TRequest Handle(TRequest request);
    }

    public interface IHandler<TRequest, TResult>
    {
        TResult Handle(TRequest request);
    }
}
