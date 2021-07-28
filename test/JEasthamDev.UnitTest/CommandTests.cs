// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Threading.Tasks;
using JEasthamDev.Api.Domain.Commands.CreateOrder;
using JEasthamDev.Api.Domain.Entity;
using Moq;
using Xunit;

namespace JEasthamDev.UnitTest
{
	public class CommandTests
	{
		[Fact]
		public async Task OnCreateOrderCommand_ShouldStoreOrder()
		{
			var mockOrders = new Mock<Orders>();
			mockOrders.Setup(p => p.Store(It.IsAny<Order>()))
				.Verifiable();

			var handler = new CreateOrderCommandHandler(mockOrders.Object);

			await handler.Handle(new CreateOrderCommand()
			{
				CustomerId = TestConstants.EmailAddress,
			}, default);
			
			mockOrders.Verify(p => p.Store(It.IsAny<Order>()), Times.Once);
		}
	}
}