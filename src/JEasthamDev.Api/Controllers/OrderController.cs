using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JEasthamDev.Core.Commands.CreateOrder;
using JEasthamDev.Core.Entity;
using JEasthamDev.Core.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JEasthamDev.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;
        private readonly Orders _order;
        private readonly OrderEventStore _eventStore;

        public OrderController(ILogger<OrderController> logger, IMediator mediator, Orders order, OrderEventStore eventStore)
        {
            this._logger = logger;
            this._mediator = mediator;
            this._order = order;
            this._eventStore = eventStore;
        }

        [HttpGet("{emailAddress}")]
        public async Task<IActionResult> GetCustomerOrders(string emailAddress)
        {
            var orders = await this._order.GetCustomerOrders(emailAddress);

            return this.Ok(orders);
        }

        [HttpGet("detail/{orderNumber}")]
        public async Task<IActionResult> GetOrder(string orderNumber)
        {
            var order = await this._eventStore.Get(orderNumber);

            return this.Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            this._logger.LogInformation("Received create order request");

            var response = await this._mediator.Send(command).ConfigureAwait(false);

            return this.Ok(response);
        }
    }
}