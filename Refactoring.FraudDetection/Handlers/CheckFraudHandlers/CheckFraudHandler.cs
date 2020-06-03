using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.CheckFraudHandlers
{
    public class CheckFraudHandler
    {
        readonly IHandler<CheckFraudRequest, FraudResult>[] _handlers;

        public CheckFraudHandler(params IHandler<CheckFraudRequest, FraudResult>[] handlers)
        {
            _handlers = handlers;
        }

        public IEnumerable<FraudResult> Handle(Order current, IEnumerable<Order> orders)
            => orders
                .Select(CheckFraud(current))
                .Where(OnlyFraud);

        Func<Order, FraudResult> CheckFraud(Order current)
            => other => CheckFraud(CheckFraudRequest.NewRequest(current, other));

        FraudResult CheckFraud(CheckFraudRequest request)
            => _handlers
                .Select(SelectHandler(request, FraudResult.NonFraud))
                .ToList()
                .First();

        static Func<IHandler<CheckFraudRequest, FraudResult>, FraudResult> SelectHandler(CheckFraudRequest request, Chain<FraudResult> result)
            => handler => result = ContinueIf(request, result, handler);

        static Chain<FraudResult> ContinueIf(CheckFraudRequest request, Chain<FraudResult> result, IHandler<CheckFraudRequest, FraudResult> handler)
            => result.ContinueIf(CheckFraud(request, handler), IsNotFraudulent);

        static Func<FraudResult> CheckFraud(CheckFraudRequest request, IHandler<CheckFraudRequest, FraudResult> handler)
            => () => handler.Handle(request);

        static bool IsNotFraudulent(FraudResult result)
            => result.IsNotFraudulent;

        static bool OnlyFraud(FraudResult result)
            => result.IsFraudulent;
    }
}
