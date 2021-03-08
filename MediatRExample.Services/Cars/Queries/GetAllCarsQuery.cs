using System.Collections.Generic;
using MediatRExample.Services.Models;
using MediatRExample.Services.Wrappers;

namespace MediatRExample.Services.Cars.Queries
{
    public class GetAllCarsQuery : BaseRequest, IRequestWrapper<IEnumerable<Car>>
    {
        
    }
}