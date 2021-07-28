// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using JEasthamDev.Api.Domain.Entity;
using MediatR;

namespace JEasthamDev.Api.Domain.Commands.CreateOrder
{
	public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
	{
		private readonly Orders _orders;

		public CreateOrderCommandHandler(Orders orders)
		{
			this._orders = orders;
		}
		
		/// <inheritdoc />
		public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var order = Order.CreateNew(request.CustomerId);

			await this._orders.Store(order).ConfigureAwait(false);

			return Unit.Value;
		}
	}
}