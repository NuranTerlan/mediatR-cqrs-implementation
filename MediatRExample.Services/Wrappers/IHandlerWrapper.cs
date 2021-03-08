using MediatR;

namespace MediatRExample.Services.Wrappers
{
    public interface IHandlerWrapper<in TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : IRequestWrapper<TOut>
    {
        
    }
}