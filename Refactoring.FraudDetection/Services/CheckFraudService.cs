using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.FraudDetection.Handlers.CheckFraudHandlers;
using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Services
{
    public class CheckFraudService
    {
        readonly ICheckFraudHandler[] _handlers;

        public CheckFraudService(params ICheckFraudHandler[] handlers)
        {
            _handlers = handlers;
        }

        public IEnumerable<FraudResult> CheckFraud(Order current, IEnumerable<Order> orders)
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

        static Func<ICheckFraudHandler, FraudResult> SelectHandler(CheckFraudRequest request, Chain<FraudResult> result)
            => handler => result = ContinueIf(request, result, handler);

        static Chain<FraudResult> ContinueIf(CheckFraudRequest request, Chain<FraudResult> result, ICheckFraudHandler handler)
            => result.ContinueIf(CheckFraud(request, handler), IsNotFraudulent);

        static Func<FraudResult> CheckFraud(CheckFraudRequest request, ICheckFraudHandler handler)
            => () => handler.Handle(request);

        static bool IsNotFraudulent(FraudResult result)
            => result.IsNotFraudulent;

        static bool OnlyFraud(FraudResult result)
            => result.IsFraudulent;
    }
}
