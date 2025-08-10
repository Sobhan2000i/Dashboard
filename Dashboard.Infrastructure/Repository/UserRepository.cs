using Azure.Core;
using Dashboard.Application.DTOs.Auth;
using Dashboard.Application.Interfaces;
using Dashboard.Application.Mappings.Users;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Shared;
using Dashboard.Infrastructure.Persistence;
using Dashboard.Infrastructure.Services.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dashboard.Infrastructure.Repository
{
    public class UserRepository(UserManager<IdentityUser> userManager
    , ApplicationDbContext applicationDbContext
    , ApplicationIdentityDbContext applicationIdentityDbContext
    , ITokenProvider tokenProvider
    , IOptions<JwtAuthOptions> options) : IUserRepository
    {
        public async Task<Result<AccessTokenDto>> LoginUser(LoginUserDto loginUserDto)
        {
            IdentityUser? identityUser = await userManager.FindByNameAsync(loginUserDto.UserName);

            if (identityUser is null || !await userManager.CheckPasswordAsync(identityUser, loginUserDto.Password))
            {
                var errors = new Dictionary<string, string[]>
                {
                    { "Login", new[] { "Invalid username or password." } }
                };

                return Result<AccessTokenDto>.Failure(errors);

            }

            var tokenRequest = new TokenRequest(identityUser.Id, identityUser.UserName!);
            AccessTokenDto accessToken = tokenProvider.Create(tokenRequest);

            return Result<AccessTokenDto>.Success(new List<AccessTokenDto> { accessToken });
        }

        public async Task<Result<AccessTokenDto>> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            using IDbContextTransaction transaction = await applicationIdentityDbContext.Database.BeginTransactionAsync();

            applicationDbContext.Database.SetDbConnection(applicationIdentityDbContext.Database.GetDbConnection());
            await applicationDbContext.Database.UseTransactionAsync(transaction.GetDbTransaction());

            var identityUser = new IdentityUser
            {
                UserName = registerUserDto.UserName
            };

            IdentityResult identityResult = await userManager.CreateAsync(identityUser, registerUserDto.Password);

            if (!identityResult.Succeeded)
            {
                var errors = identityResult.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.Description).ToArray()
                    );

                return Result<AccessTokenDto>.Failure(errors);
            }

            User user = registerUserDto.ToEntity();
            user.SetIdentityId(identityUser.Id);

            applicationDbContext.Users.Add(user);
            await applicationDbContext.SaveChangesAsync();

            var tokenReuest = new TokenRequest(identityUser.Id, identityUser.UserName);
            var accessTokens = tokenProvider.Create(tokenReuest);


            await applicationDbContext.SaveChangesAsync();

            await transaction.CommitAsync();


            return Result<AccessTokenDto>.Success(new List<AccessTokenDto> { accessTokens }); 
        }
    }
}
