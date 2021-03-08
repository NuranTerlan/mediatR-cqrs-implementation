using MediatR;

namespace MediatRExample.Services.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    {
        
    }
}