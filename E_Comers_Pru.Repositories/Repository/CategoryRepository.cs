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
    public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<CategoryEntity>> GetCategories()
        {
            try
            {
                return await _context.Category.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CategoryEntity>> GetCategoryByName(string Name)
        {
            try
            {
                return await _context.Category.Where(x => x.Name.ToUpper() == Name.ToUpper()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<CategoryEntity> Create(CategoryEntity data)
        {
            try
            {
                _context.Category.Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<CategoryEntity> Update(CategoryEntity data)
        {
            try
            {
                _context.Category.Update(data);
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
                CategoryEntity data = await _context.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.Category.RemoveRange(data);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

    }
}
