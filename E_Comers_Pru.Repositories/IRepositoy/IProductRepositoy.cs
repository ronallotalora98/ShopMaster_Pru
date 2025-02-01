using E_Comers_Pru.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories.IRepositoy
{
    public interface IProductRepositoy
    {
        Task<List<ProductEntity>> GetProducts();
        Task<List<ProductEntity>> GetProductByName(string Name);
        Task<ProductEntity> Create(ProductEntity data);
        Task<ProductEntity> Update(ProductEntity data);
        Task Delete(int id);
    }
}
