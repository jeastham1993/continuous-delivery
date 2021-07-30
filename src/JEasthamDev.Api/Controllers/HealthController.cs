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
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Health()
        {
            return this.Ok();
        }
    }
}