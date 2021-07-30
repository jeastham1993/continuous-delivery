// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;

namespace JEasthamDev.Api.Domain.Entity
{
	public interface Orders
	{
		Task Store(Order order);

		Task<Order> GetOrder(string orderNumber);

		Task<List<Order>> GetCustomerOrders(string emailAddress);
	}
}