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
    public class ShopRepository(ApplicationDbContext context) : IShopRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<OrdenEntity> CreateOrder(OrdenEntity data)
        {
            try
            {
                _context.Orden.Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task CreateDetailOrder(List<DetailOrderEntity> data)
        {
            try
            {
                _context.DetailOrder.AddRange(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<OrdenEntity>> GetOrdersByUse(int userId)
        {
            try
            {
                return await _context.Orden
                        .Include(x => x.DetailOrders)
                        .Where(x => x.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<OrdenEntity>> GetAllOrders()
        {
            try
            {
                return await _context.Orden
                        .Include(x => x.DetailOrders)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
