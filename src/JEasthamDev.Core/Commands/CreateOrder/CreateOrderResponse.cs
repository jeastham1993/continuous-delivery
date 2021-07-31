// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using MediatR;

namespace JEasthamDev.Core.Commands.CreateOrder
{
	public class CreateOrderResponse
	{
		public string OrderNumber { get; set; }
	}
}