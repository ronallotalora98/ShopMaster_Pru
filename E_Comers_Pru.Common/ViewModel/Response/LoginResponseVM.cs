using E_Comers_Pru.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Common.ViewModel.Response
{
    public class LoginResponseVM
    {
        public UserDto? User { get; set; }

        public RolDto? Roles { get; set; }

        public string? Token { get; set; }
    }
}
