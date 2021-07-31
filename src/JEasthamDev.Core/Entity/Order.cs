// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;
using JEasthamDev.Core.Events;

namespace JEasthamDev.Core.Entity
{
    public class Order
    {
        public string CustomerId { get; private set; }

        public string OrderNumber { get; private set; }

        public DateTime OrderDate { get; private set; }

        public OrderStatus Status { get; private set; }

        public static Order CreateNew(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentException(
                    "Cannot create an order for an invalid email address",
                    nameof(emailAddress));
            }

            return new Order()
            {
                CustomerId = emailAddress,
                OrderDate = DateTime.Now,
                OrderNumber = $"{DateTime.Now:yyMMdd}{Guid.NewGuid().ToString().Split('-')[0]}",
                Status = OrderStatus.NEW,
            };
        }

        public void Apply(OrderCreatedOrderEvent evt)
        {
            this.CustomerId = evt.CustomerId;
            this.OrderNumber = evt.OrderNumber;
            this.OrderDate = evt.OrderDate;
            this.Status = OrderStatus.NEW;
        }
    }
}