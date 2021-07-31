// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;

namespace JEasthamDev.Core.Events
{
	public abstract class OrderEvent
	{
		public OrderEvent()
		{
			this.EventId = Guid.NewGuid().ToString();
			this.EventDate = DateTime.Now;
		}
		
		public abstract string EventName { get; }
		
		public string EventId { get; set; }
		
		public DateTime EventDate { get; set; }
		
		public string OrderNumber { get; set; }
	}
}