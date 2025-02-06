using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Repositories.IRepositoy;
using E_Comers_Pru.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class ProducService: IProducService
    {
        protected readonly IMapper Mapper;
        protected readonly IProductRepositoy ProductRepositoy;

        public ProducService(IMapper mapper, IProductRepositoy productRepositoy)
        {
            Mapper = mapper;
            ProductRepositoy = productRepositoy;
        }

        public async Task<ResponseVM> GetProducts()
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<ProductEntity> data = await ProductRepositoy.GetProducts();
                result.Element = Mapper.Map<IEnumerable<ProductDto>>(data);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Create(ProductDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<ProductEntity> entitiesByName = await ProductRepositoy.GetProductByName(dto.Name);
                if (entitiesByName.Any())
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                ProductEntity data = Mapper.Map<ProductEntity>(dto);
                data = await ProductRepositoy.Create(data);
                result.Element = Mapper.Map<ProductDto>(data);

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Update(ProductDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<ProductEntity> entitiesByCode = await ProductRepositoy.GetProductByName(dto.Name);
                if (entitiesByCode.Any(x => x.Id != dto.Id))
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                ProductEntity data = Mapper.Map<ProductEntity>(dto);
                await ProductRepositoy.Update(data);

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
