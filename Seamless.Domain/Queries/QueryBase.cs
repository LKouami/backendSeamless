using MediatR;

namespace Seamless.Domain.Queries
{
    public abstract class QueryBase<TResult> : IRequest<TResult> //where TResult : class
    {
        public int UserId { get; set; }

    }
}