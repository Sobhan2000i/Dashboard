using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.DTOs.Auth
{
    public sealed record TokenRequest(string UserId, string UserName);

}
