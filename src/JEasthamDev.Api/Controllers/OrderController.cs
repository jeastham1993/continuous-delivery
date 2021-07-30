using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JEasthamDev.Api.Domain.Commands.CreateOrder;
using JEasthamDev.Api.Domain.Entity;
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

        public OrderController(ILogger<OrderController> logger, IMediator mediator, Orders order)
        {
            _logger = logger;
            this._mediator = mediator;
            _order = order;
        }
        
        [HttpGet("{emailAddress}")]
        public async Task<IActionResult> GetCustomerOrders(string emailAddress)
        {
            var orders = await this._order.GetCustomerOrders(emailAddress);

            return this.Ok(orders);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            this._logger.LogInformation("Received create order request");
            
            await this._mediator.Send(command).ConfigureAwait(false);

            return this.Ok();
        }
    }
}