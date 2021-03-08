using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRExample.Services;
using MediatRExample.Services.Models;
using Microsoft.AspNetCore.Http;

namespace MediatRExample.API.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private readonly HttpContext _httpContext;

        public UserIdPipe(IHttpContextAccessor accessor)
        {
            _httpContext = accessor.HttpContext;
        }

        public async Task<TOut> Handle(
            TIn request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TOut> next)
        {
            var userId = _httpContext.User.Claims
                .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))
                ?.Value;

            if (request is BaseRequest br)
            {
                // we don't have users right now. Let's generate dummy one
                br.UserId = Guid.NewGuid().ToString();
            }

            var result = await next();

            if (result is Response<Car> carResponse)
            {
                carResponse.Data.Name += " ~ CHECKED!";
            }

            return result;
        }
    }
}