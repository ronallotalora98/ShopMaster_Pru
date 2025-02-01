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
    public class ProductRepositoy(ApplicationDbContext context) : IProductRepositoy
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<ProductEntity>> GetProducts()
        {
            try
            {
                return await _context.Product
                        .Include(x=> x.Category).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ProductEntity>> GetProductByName(string Name)
        {
            try
            {
                return await _context.Product.Where(x => x.Name.ToUpper() == Name.ToUpper()).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ProductEntity> Create(ProductEntity data)
        {
            try
            {
                _context.Product.Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ProductEntity> Update(ProductEntity data)
        {
            try
            {
                _context.Product.Update(data);
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
                ProductEntity data = await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.Product.RemoveRange(data);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
