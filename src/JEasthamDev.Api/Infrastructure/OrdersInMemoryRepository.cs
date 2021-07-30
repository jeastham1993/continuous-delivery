// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JEasthamDev.Api.Domain.Entity;

namespace JEasthamDev.Api.Infrastructure
{
	public class OrdersInMemoryRepository : Orders
	{
		private List<Order> _orders;

		public OrdersInMemoryRepository()
		{
			this._orders = new List<Order>();
		}
		
		/// <inheritdoc />
		public Task Store(Order order)
		{
			this._orders.Add(order);

			return Task.CompletedTask;
		}

		public Task<Order> GetOrder(string orderNumber) =>
			Task.FromResult(this._orders.FirstOrDefault(p => p.OrderNumber.Equals(orderNumber, StringComparison.OrdinalIgnoreCase)));

		public Task<List<Order>> GetCustomerOrders(string emailAddress) =>
			Task.FromResult(this._orders.Where(p => p.CustomerId.Equals(emailAddress)).ToList());
	}
}