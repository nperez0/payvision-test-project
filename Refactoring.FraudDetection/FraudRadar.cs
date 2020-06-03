// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Refactoring.FraudDetection.Handlers.CheckFraudHandlers;
    using Refactoring.FraudDetection.Handlers.NormalizeHandlers;
    using Refactoring.FraudDetection.Models;

    public partial class FraudRadar
    {
        readonly CheckFraudHandler _checkFraudHandler;
        readonly NormalizeHandler _normalizeHandler;

        public FraudRadar(CheckFraudHandler checkFraudHandler, NormalizeHandler normalizeHandler)
        {
            _checkFraudHandler = checkFraudHandler;
            _normalizeHandler = normalizeHandler;
        }

        public IEnumerable<FraudResult> Check(IEnumerable<Order> orders)
        {
            return orders
                .Select(Normalize)
                .SelectMany(CheckFraud(orders));
        }

        Order Normalize(Order order) 
            => _normalizeHandler.Handle(order);

        Func<Order, int, IEnumerable<FraudResult>> CheckFraud(IEnumerable<Order> orders) 
            => (current, index) => CheckFraud(current, index, orders);

        IEnumerable<FraudResult> CheckFraud(Order current, int index, IEnumerable<Order> orders)
            => _checkFraudHandler.Handle(current, orders.Skip(index + 1));
    }
}