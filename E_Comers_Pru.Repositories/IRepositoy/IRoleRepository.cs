using E_Comers_Pru.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories.IRepositoy
{
    public interface IRoleRepository
    {
        Task<List<RolEntity>> GetRoles();
        Task<List<RolEntity>> GetRolesByName(string Name);
        Task<RolEntity> Create(RolEntity data);
        Task<RolEntity> Update(RolEntity data);
        Task Delete(int id);



    }
}
