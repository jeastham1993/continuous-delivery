using System;
using FluentAssertions;
using JEasthamDev.Api.Controllers;
using JEasthamDev.Api.Domain.Commands.CreateOrder;
using JEasthamDev.Api.Domain.Entity;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace JEasthamDev.UnitTest
{
    public class ControllerTests
    {
        [Fact]
        public void CanGetOrdersWithOrderController_ShouldComplete()
        {
            var orderController = new OrderController(new Mock<ILogger<OrderController>>().Object, new Mock<IMediator>().Object, new Mock<Orders>().Object);

            orderController.GetOrder(TestConstants.EmailAddress, "ORDER");
        }
        
        [Fact]
        public void CanGetCustomerOrdersWithOrderController_ShouldComplete()
        {
            var orderController = new OrderController(new Mock<ILogger<OrderController>>().Object, new Mock<IMediator>().Object, new Mock<Orders>().Object);

            orderController.GetCustomerOrders(TestConstants.EmailAddress);
        }
        
        [Fact]
        public void CanCreateOrdersWithOrderController_ShouldComplete()
        {
            var orderController = new OrderController(new Mock<ILogger<OrderController>>().Object, new Mock<IMediator>().Object, new Mock<Orders>().Object);

            orderController.CreateOrder(new CreateOrderCommand()
            {
                CustomerId = TestConstants.EmailAddress
            });
        }
        
        [Fact]
        public void HealthCheckTests()
        {
            var orderController = new HealthController();

            orderController.Health();
        }
    }
}