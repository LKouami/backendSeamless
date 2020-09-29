using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.User;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.User;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDxos _userDxos;
        private readonly IMediator _mediator;

        public UpdateUserHandler(IUserRepository userRepository,
            IMediator mediator,
            IUserDxos userDxos)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _userDxos = userDxos ?? throw new ArgumentNullException(nameof(userDxos));
        }


        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userDxos.MapUpdateRequesttoUser(request);

            _userRepository.Update(user);

            if (await _userRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new UserUpdatedEvent(user.Id), cancellationToken);

            var userDto = _userDxos.MapUserDto(user);

            return userDto;
        }
    }
}