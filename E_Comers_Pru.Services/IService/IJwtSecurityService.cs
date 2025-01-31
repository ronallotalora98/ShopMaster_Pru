using E_Comers_Pru.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.IService
{
    public interface IJwtSecurityService
    {
        string GenerateTokenJwt(UserDto dto);

        int? ValidateCurrentToken(string token);
    }
}
