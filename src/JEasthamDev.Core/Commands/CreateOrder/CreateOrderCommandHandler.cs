// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using JEasthamDev.Core.Entity;
using JEasthamDev.Core.Events;
using MediatR;

namespace JEasthamDev.Core.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly OrderEventStore _orderEventStore;

        public CreateOrderCommandHandler(OrderEventStore orderEventStore)
        {
            this._orderEventStore = orderEventStore;
        }

        /// <inheritdoc />
        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.CreateNew(request.CustomerId);

            await this._orderEventStore.Store(new OrderCreatedOrderEvent()
            {
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId
            }).ConfigureAwait(false);

            return new CreateOrderResponse()
            {
                OrderNumber = order.OrderNumber,
            };
        }
    }
}