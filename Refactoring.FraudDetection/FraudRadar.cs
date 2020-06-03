// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Refactoring.FraudDetection.Models;
    using Refactoring.FraudDetection.Services;

    public partial class FraudRadar
    {
        readonly CheckFraudService _checkFraudService;

        public FraudRadar(CheckFraudService checkFraudService)
        {
            _checkFraudService = checkFraudService;
        }

        public IEnumerable<FraudResult> Check(IEnumerable<Order> orders)
        {
            return orders
                .SelectMany(CheckFraud(orders));
        }

        Func<Order, int, IEnumerable<FraudResult>> CheckFraud(IEnumerable<Order> orders) 
            => (current, index) => CheckFraud(current, index, orders);

        IEnumerable<FraudResult> CheckFraud(Order current, int index, IEnumerable<Order> orders)
            => _checkFraudService.CheckFraud(current, orders.Skip(index + 1));
    }
}