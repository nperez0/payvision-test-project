using System;
using System.Linq;
using Refactoring.FraudDetection.Handlers.NormalizeHandlers;
using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Services
{
    public class NormalizeService
    {
        readonly INormalizeHandler[] _handlers;

        public NormalizeService(params INormalizeHandler[] handlers)
        {
            _handlers = handlers;
        }

        public Order Normalize(Order order) 
            => _handlers
                .Select(SelectHandler(order))
                .ToList()
                .First();

        static Func<INormalizeHandler, Order> SelectHandler(Order order)
            => handler => order = ContinueWith(order, handler);

        static Chain<Order> ContinueWith(Chain<Order> order, INormalizeHandler handler)
            => order.ContinueWith(Normalize(order, handler));

        static Func<Order> Normalize(Chain<Order> order, INormalizeHandler handler)
            => () => handler.Handle(order);
    }
}
