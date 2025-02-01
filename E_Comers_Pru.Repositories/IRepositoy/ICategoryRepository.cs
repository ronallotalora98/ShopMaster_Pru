using E_Comers_Pru.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Repositories.IRepositoy
{
    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> GetCategories();
        Task<List<CategoryEntity>> GetCategoryByName(string Name);
        Task<CategoryEntity> Create(CategoryEntity data);
        Task<CategoryEntity> Update(CategoryEntity data);
        Task Delete(int id);
    }
}
