// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace JEasthamDev.Core.Entity
{
	public interface Orders
	{
		Task Store(Order order);

		Task<Order> GetOrder(string orderNumber);

		Task<List<Order>> GetCustomerOrders(string emailAddress);
	}
}