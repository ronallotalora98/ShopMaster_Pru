using E_Comers_Pru.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories.IRepositoy
{
    public interface IShopRepository
    {
        Task<OrdenEntity> CreateOrder(OrdenEntity data);
        Task CreateDetailOrder(List<DetailOrderEntity> data);
        Task<List<OrdenEntity>> GetOrdersByUse(int userId);
        Task<List<OrdenEntity>> GetAllOrders();
    }
}
