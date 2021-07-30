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

		Task<List<Order>> GetCustomerOrders(string emailAddress);
	}
}