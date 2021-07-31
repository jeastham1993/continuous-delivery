// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;
using JEasthamDev.Core.Entity;

namespace JEasthamDev.Core.Events
{
	public class OrderCreatedOrderEvent : OrderEvent
	{
		public OrderCreatedOrderEvent() : base() {}

		/// <inheritdoc />
		public override string EventName => "order-created";
		
		public string CustomerId { get; set; }
		
		public DateTime OrderDate { get; set; }
	}
}