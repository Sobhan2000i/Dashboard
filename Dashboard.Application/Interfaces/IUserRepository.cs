using Dashboard.Application.DTOs.Auth;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<AccessTokenDto>> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<Result<AccessTokenDto>> LoginUser(LoginUserDto loginUserDto);
    }
}
