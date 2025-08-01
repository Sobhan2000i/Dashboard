using Dashboard.Application.DTOs.Auth;
using Dashboard.Application.Interfaces;
using Dashboard.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Commands.Users
{
    public sealed class RegisterUserCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, Result<AccessTokenDto>>

    {
        public async Task<Result<AccessTokenDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await userRepository.RegisterUserAsync(request.Dto);

            return result;
        }
    }
}
