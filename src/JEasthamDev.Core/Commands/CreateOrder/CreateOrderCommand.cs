// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using MediatR;

namespace JEasthamDev.Core.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest<CreateOrderResponse>
	{
		public string CustomerId { get; set; }
	}
}