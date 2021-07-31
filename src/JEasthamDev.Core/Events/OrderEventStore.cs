// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Threading.Tasks;
using JEasthamDev.Core.Entity;

namespace JEasthamDev.Core.Events
{
	public interface OrderEventStore
	{
		Task Store(OrderEvent evt);
		
		Task<Order> Get(string orderNumber);
	}
}