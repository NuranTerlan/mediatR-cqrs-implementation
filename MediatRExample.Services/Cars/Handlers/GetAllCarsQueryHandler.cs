using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRExample.Services.Cars.Queries;
using MediatRExample.Services.Models;
using MediatRExample.Services.Wrappers;

namespace MediatRExample.Services.Cars.Handlers
{
    public class GetAllCarsQueryHandler : IHandlerWrapper<GetAllCarsQuery, IEnumerable<Car>>
    {
        // DI: we can inject our database or other dependencies here if needed
        public GetAllCarsQueryHandler()
        {
            
        }

        public Task<Response<IEnumerable<Car>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            // business logic

            if (false)
            {
                return Task.FromResult(Response.Fail<IEnumerable<Car>>("Error occured while fetching data"));
            }

            return Task.FromResult(Response.Ok<IEnumerable<Car>>(new[]
                {
                    new Car {Name = $"Mercedes {request.UserId}"},
                    new Car {Name = "Hyundai"}
                },
                "Cars fetched"));
        }
    }
}