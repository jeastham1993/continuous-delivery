// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using JEasthamDev.Api.Domain.Entity;

namespace JEasthamDev.Api.Infrastructure
{
	public class OrdersInMemoryRepository : Orders
	{
		private static List<Order> _orders;
		
		/// <inheritdoc />
		public Task Store(Order order)
		{
			_orders ??= new List<Order>();

			_orders.Add(order);

			return Task.CompletedTask;
		}
	}
}