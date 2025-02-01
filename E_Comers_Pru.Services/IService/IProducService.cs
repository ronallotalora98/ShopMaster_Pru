using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.IService
{
    public interface IProducService
    {
        Task<ResponseVM> GetProducts();
        Task<ResponseVM> Create(ProductDto dto);
        Task<ResponseVM> Update(ProductDto dto);
    }
}
