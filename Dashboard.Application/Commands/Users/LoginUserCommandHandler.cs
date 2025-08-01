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
    public sealed class LoginUserCommandHandler(IUserRepository userRepository) : IRequestHandler<LoginUserCommand, Result<AccessTokenDto>>
    {
        public async Task<Result<AccessTokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.LoginUser(request.Dto);
        }
    }
}
