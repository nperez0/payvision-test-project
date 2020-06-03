// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection.Models
{
    public class Order
    {
        public int OrderId { get; }

        public int DealId { get; }

        public Email Email { get;}

        public Address Address { get; }

        public StringValue CreditCard { get; }

        private Order(
            int orderId,
            int dealId,
            Email email,
            Address address,
            StringValue creditCard)
        {
            OrderId = orderId;
            DealId = dealId;
            Email = email;
            Address = address;
            CreditCard = creditCard;
        }

        public Order UpdateEmail(Email email)
            => new Order(
                OrderId,
                DealId,
                email,
                Address,
                CreditCard);

        public Order UpdateAddress(Address address)
            => new Order(
                OrderId,
                DealId,
                Email,
                address,
                CreditCard);

        public static Order NewOrder(
            int orderId,
            int dealId,
            Email email,
            Address address,
            StringValue creditCard)
            => new Order(
                orderId,
                dealId,
                email,
                address,
                creditCard);
    }
}