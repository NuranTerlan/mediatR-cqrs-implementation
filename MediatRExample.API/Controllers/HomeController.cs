using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRExample.Services;
using MediatRExample.Services.Cars.Commands;
using MediatRExample.Services.Cars.Queries;
using MediatRExample.Services.Models;

namespace MediatRExample.API.Controllers
{
    [ApiController]
    [Route("cars")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<Response<IEnumerable<Car>>> Index()
        {
            return _mediator.Send(new GetAllCarsQuery());
        }

        [HttpPost]
        public Task<Response<Car>> Index([FromBody] CreateCarCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
