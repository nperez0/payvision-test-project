// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection.Models
{
    public class FraudResult
    {
        public int OrderId { get; }

        public bool IsFraudulent { get; }

        public bool IsNotFraudulent => !IsFraudulent;

        public static FraudResult NonFraud = new FraudResult(-1, false);

        private FraudResult(int orderId, bool isFraudulent)
        {
            OrderId = orderId;
            IsFraudulent = isFraudulent;
        }

        public static FraudResult NewFraud(int orderId)
            => new FraudResult(orderId, true);
    }
}