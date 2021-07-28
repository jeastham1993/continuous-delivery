using System;
using FluentAssertions;
using JEasthamDev.Api.Domain.Entity;
using Xunit;

namespace JEasthamDev.UnitTest
{
    public class OrderTests
    {
        [Fact]
        public void CreateNewOrder_ShouldSetOrderNumber()
        {
            var order = Order.CreateNew(TestConstants.EmailAddress);

            order.CustomerId.Should().Be(TestConstants.EmailAddress);
            order.OrderNumber.Should().NotBeEmpty();
            order.OrderDate.Should().BeCloseTo(DateTime.Now);
        }
        
        [Fact]
        public void CreateOrderWithInvalidEmailAddress_ShouldError()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Order.CreateNew(string.Empty);
            });
        }
    }
}