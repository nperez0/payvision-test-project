using System;
using System.Linq;
using Refactoring.FraudDetection.Models;

namespace Refactoring.FraudDetection.Handlers.NormalizeHandlers
{
    public class NormalizeHandler
    {
        readonly IHandler<Order>[] _handlers;

        public NormalizeHandler(params IHandler<Order>[] handlers)
        {
            _handlers = handlers;
        }

        public Order Handle(Order order) 
            => _handlers
                .Select(SelectHandler(order))
                .ToList()
                .First();

        static Func<IHandler<Order>, Order> SelectHandler(Order order)
            => handler => order = ContinueWith(order, handler);

        static Chain<Order> ContinueWith(Chain<Order> order, IHandler<Order> handler)
            => order.ContinueWith(Normalize(order, handler));

        static Func<Order> Normalize(Chain<Order> order, IHandler<Order> handler)
            => () => handler.Handle(order);
    }
}
