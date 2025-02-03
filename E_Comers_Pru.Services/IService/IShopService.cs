using E_Comers_Pru.Common.ViewModel.Request;
using E_Comers_Pru.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.IService
{
    public interface IShopService
    {
        Task<ResponseVM> CreateOrder(InvoiceRequestVM dto);
        Task<ResponseVM> GetOrdersByUser(int userId);
        Task<ResponseVM> GetAllOrders();

    }
}
