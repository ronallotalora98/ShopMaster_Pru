using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Repositories.IRepositoy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories.Repository
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<RolEntity>> GetRoles()
        {
            try
            {
                return await _context.Rol.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<RolEntity>> GetRolesByName(string Name)
        {
            try
            {
                return await _context.Rol.Where(x => x.Description.ToUpper() == Name.ToUpper()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<RolEntity> Create(RolEntity data)
        {
            try
            {
                _context.Rol.Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<RolEntity> Update(RolEntity data)
        {
            try
            {
                _context.Rol.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                RolEntity data = await _context.Rol.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.Rol.RemoveRange(data);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
