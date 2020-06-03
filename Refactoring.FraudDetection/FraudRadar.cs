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

        public FraudRadar(CheckFraudHandler checkFraudHandler)
        {
            _checkFraudHandler = checkFraudHandler;
        }

        public IEnumerable<FraudResult> Check(IEnumerable<Order> orders)
        {
            return orders
                .SelectMany(CheckFraud(orders));
        }

        Func<Order, int, IEnumerable<FraudResult>> CheckFraud(IEnumerable<Order> orders) 
            => (current, index) => CheckFraud(current, index, orders);

        IEnumerable<FraudResult> CheckFraud(Order current, int index, IEnumerable<Order> orders)
            => _checkFraudHandler.Handle(current, orders.Skip(index + 1));
    }
}