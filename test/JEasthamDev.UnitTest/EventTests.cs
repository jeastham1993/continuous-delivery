// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;
using FluentAssertions;
using JEasthamDev.Core.Events;
using Xunit;

namespace JEasthamDev.UnitTest
{
	public class EventTests
	{
		[Fact]
		public void CreateEvent_ShouldHaveProperties()
		{
			var evt = new OrderCreatedOrderEvent()
			{
				OrderNumber = "ORDER1234"
			};

			evt.EventName.Should().Be("order-created");
			evt.EventDate.Should().BeCloseTo(DateTime.Now);
			evt.EventId.Should().NotBeNullOrEmpty();
			evt.OrderNumber.Should().Be("ORDER1234");
		}
	}
}