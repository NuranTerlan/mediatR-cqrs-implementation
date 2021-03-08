using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MediatRExample.Services.Cars.Commands;
using MediatRExample.Services.Models;
using MediatRExample.Services.Wrappers;

namespace MediatRExample.Services.Cars.Handlers
{
    public class CreateCarCommandHandler : IHandlerWrapper<CreateCarCommand, Car>
    {
        public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            // fail condition should be here
            if (false)
            {
                return Task.FromResult(Response.Fail<Car>("Already exist"));
            }

            return Task.FromResult(Response.Ok<Car>(new Car { Name = "BMW" }, "Car is successfully created"));
        }
    }
}