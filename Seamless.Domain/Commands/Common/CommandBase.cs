using MediatR;

namespace Seamless.Domain.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {

    }
}

