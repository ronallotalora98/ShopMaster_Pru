using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Common.ViewModel.Request;
using E_Comers_Pru.Common.ViewModel.Response;
using E_Comers_Pru.Repositories.IRepositoy;
using E_Comers_Pru.Repositories.Repository;
using E_Comers_Pru.Services.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class ShopService: IShopService
    {
        protected readonly IMapper Mapper;
        protected readonly IShopRepository ShopRepository;
        public ShopService(IMapper mapper, IShopRepository shopRepository)
        {
            Mapper = mapper;
            ShopRepository = shopRepository;
        }

        public async Task<ResponseVM> CreateOrder(InvoiceRequestVM dto)
        {
            ResponseVM result = new();
            try
            {

                OrdenEntity orden = new OrdenEntity { 
                    UserId = dto.UserId,
                    Status = "Vendido",
                    OrdenDate =DateTime.Now,
                    Total = dto.Total,
                };

                OrdenEntity dataOrder = await ShopRepository.CreateOrder(orden);

                List<DetailOrderEntity> detailOrders = new List<DetailOrderEntity>();

                foreach (var order in dto.detailOrders) {

                    detailOrders.Add(new DetailOrderEntity
                    {
                        OrdenId = dataOrder.Id,
                        ProductId = order.ProductId,
                        Amount = order.Amount,
                        UnitPrice = order.UnitPrice,
                    });

                }

                await ShopRepository.CreateDetailOrder(detailOrders);
                result.Element = new { saveInvoice = true };

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }
        public async Task<ResponseVM> GetOrdersByUser(int userId)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<OrdenEntity> data = await ShopRepository.GetOrdersByUse(userId);
                result.Element = Mapper.Map<IEnumerable<InvoiceResponseVM>>(data);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> GetAllOrders()
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<OrdenEntity> data = await ShopRepository.GetAllOrders();
                result.Element = Mapper.Map<IEnumerable<InvoiceResponseVM>>(data);
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
