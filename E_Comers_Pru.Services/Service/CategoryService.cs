using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Repositories.IRepositoy;
using E_Comers_Pru.Repositories.Repository;
using E_Comers_Pru.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class CategoryService: ICategoryService
    {
        protected readonly IMapper Mapper;
        protected readonly ICategoryRepository CategoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            Mapper = mapper;
            CategoryRepository = categoryRepository;
        }

        public async Task<ResponseVM> GetCategories()
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<CategoryEntity> data = await CategoryRepository.GetCategories();
                result.Element = Mapper.Map<IEnumerable<CategoryDto>>(data);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Create(CategoryDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<CategoryEntity> entitiesByName = await CategoryRepository.GetCategoryByName(dto.Name);
                if (entitiesByName.Any())
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                CategoryEntity data = Mapper.Map<CategoryEntity>(dto);
                data = await CategoryRepository.Create(data);
                result.Element = Mapper.Map<CategoryDto>(data);

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Update(CategoryDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<CategoryEntity> entitiesByCode = await CategoryRepository.GetCategoryByName(dto.Name);
                if (entitiesByCode.Any(x => x.Id != dto.Id))
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                CategoryEntity data = Mapper.Map<CategoryEntity>(dto);
                await CategoryRepository.Update(data);

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

    }
}
