﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Refactoring.FraudDetection.Handlers.NormalizeHandlers;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Builders;

namespace Refactoring.FraudDetection
{
    public class OrdersReader
    {
        readonly NormalizeHandler _normalizeHandler;

        public OrdersReader(NormalizeHandler normalizeHandler)
        {
            _normalizeHandler = normalizeHandler;
        }

        public IEnumerable<Order> GetOrders(string filePath)
            => GetLines(filePath)
                .Select(CreateOrder)
                .Select(Normalize);

        Order Normalize(Order order)
            => _normalizeHandler.Handle(order);

        static Order CreateOrder(string line)
            => CreateOrder(line.SplitBySemicolon());

        static Order CreateOrder(string[] items)
            => OrderBuilder.New()
                    .AddOrderId(int.Parse(items[0]))
                    .AddDealId(int.Parse(items[1]))
                    .AddEmail(Email.NewEmail(items[2].ToLower()))
                    .AddAddress(Address.NewAddress(
                        items[3].ToLower(),
                        items[4].ToLower(),
                        items[5].ToLower(),
                        items[6]
                        ))
                    .AddCreditCard(items[7])
                    .Build();

        static string[] GetLines(string filePath)
            => File.ReadAllLines(filePath);
    }
}
