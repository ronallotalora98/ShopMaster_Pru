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
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<UserEntity> SearchByEmail(string? email)
        {
            try
            {
                string? emailUser = email?.ToUpper();
                UserEntity? data = await _context.User.Include(x => x.Rol).FirstOrDefaultAsync(x => x.Email == emailUser);

                return data ?? new();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<UserEntity> GetUserById(int id)
        {
            try
            {
                UserEntity? data = await _context.User.Include(x => x.Rol).FirstOrDefaultAsync(x => x.Id == id);

                return data ?? new();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
