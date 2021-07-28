// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using MediatR;

namespace JEasthamDev.Api.Domain.Commands.CreateOrder
{
	public class CreateOrderCommand : IRequest
	{
		public string CustomerId { get; set; }
	}
}