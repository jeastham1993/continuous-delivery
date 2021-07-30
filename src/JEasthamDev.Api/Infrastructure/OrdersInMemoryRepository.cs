// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JEasthamDev.Api.Domain.Entity;

namespace JEasthamDev.Api.Infrastructure
{
	public class OrdersInMemoryRepository : Orders
	{
		private List<Order> _orders;
		
		/// <inheritdoc />
		public Task Store(Order order)
		{
			this._orders ??= new List<Order>();

			this._orders.Add(order);

			return Task.CompletedTask;
		}

		public Task<List<Order>> GetCustomerOrders(string emailAddress) =>
			Task.FromResult(this._orders.Where(p => p.CustomerId.Equals(emailAddress)).ToList());
	}
}