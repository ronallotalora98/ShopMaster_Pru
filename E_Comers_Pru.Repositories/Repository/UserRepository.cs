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

        public async Task<List<UserEntity>> GeUsers()
        {
            try
            {
                return await _context.User.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<UserEntity>> GetUserByName(string Name)
        {
            try
            {
                return await _context.User.Where(x => x.Name.ToUpper() == Name.ToUpper()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<UserEntity> Create(UserEntity data)
        {
            try
            {
                _context.User.Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<UserEntity> Update(UserEntity data)
        {
            try
            {
                _context.User.Update(data);
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
                UserEntity data = await _context.User.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.User.RemoveRange(data);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
