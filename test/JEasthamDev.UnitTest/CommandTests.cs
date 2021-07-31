// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System.Threading.Tasks;
using JEasthamDev.Core.Commands.CreateOrder;
using JEasthamDev.Core.Entity;
using JEasthamDev.Core.Events;
using Moq;
using Xunit;

namespace JEasthamDev.UnitTest
{
	public class CommandTests
	{
		[Fact]
		public async Task OnCreateOrderCommand_ShouldStoreOrder()
		{
			var mockEventStore = new Mock<OrderEventStore>();
			mockEventStore.Setup(p => p.Store(It.IsAny<OrderCreatedOrderEvent>()))
				.Verifiable();

			var handler = new CreateOrderCommandHandler(mockEventStore.Object);

			await handler.Handle(new CreateOrderCommand()
			{
				CustomerId = TestConstants.EmailAddress,
			}, default);
			
			mockEventStore.Verify(p => p.Store(It.IsAny<OrderCreatedOrderEvent>()), Times.Once);
		}
	}
}