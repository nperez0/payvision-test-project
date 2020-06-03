using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Models.Builders
{
    public class OrderBuilder
    {
        int _orderId;
        int _deailId;
        Email _email;
        Address _address;
        StringValue _creditCard;

        public OrderBuilder AddOrderId(int orderId)
        {
            _orderId = orderId;

            return this;
        }

        public OrderBuilder AddDealId(int dealId)
        {
            _deailId = dealId;

            return this;
        }

        public OrderBuilder AddEmail(Email email)
        {
            _email = email;

            return this;
        }

        public OrderBuilder AddAddress(Address address)
        {
            _address = address;

            return this;
        }

        public OrderBuilder AddCreditCard(StringValue creditCard)
        {
            _creditCard = creditCard;

            return this;
        }

        public Order Build()
            => Order.NewOrder(
                _orderId,
                _deailId,
                _email,
                _address,
                _creditCard);

        public static OrderBuilder New()
            => new OrderBuilder();

    }
}
