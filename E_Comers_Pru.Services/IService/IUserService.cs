using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.IService
{
    public interface IUserService
    {
        Task<ResponseVM> GetUsers();
        Task<ResponseVM> Create(UserDto dto);
        Task<ResponseVM> Update(UserDto dto);
    }
}
