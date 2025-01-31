using E_Comers_Pru.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories.IRepositoy
{
    public interface IUserRepository
    {
        Task<UserEntity> SearchByEmail(string? email);
        Task<UserEntity> GetUserById(int id);
    }
}
