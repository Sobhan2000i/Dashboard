using Dashboard.Application.DTOs.Auth;
using Dashboard.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Commands.Users
{
    public sealed record RegisterUserCommand(RegisterUserDto Dto) : IRequest<Result<AccessTokenDto>>;
}
