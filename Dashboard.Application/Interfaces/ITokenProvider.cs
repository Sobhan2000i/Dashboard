using Dashboard.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Interfaces
{
    public interface ITokenProvider
    {
        AccessTokenDto Create(TokenRequest tokenRequest);
    }

}
