using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Common.ViewModel.Request;
using E_Comers_Pru.Services.IService;
using E_Comers_Pru.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_Pru.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService ShopService;

        public ShopController(IShopService shopService)
        {
            ShopService = shopService;
        }

        [HttpGet("getAllSales")]
        public async Task<IActionResult> GetAllSales()
        {
            try
            {
                ResponseVM response = await ShopService.GetAllOrders();
                if (!response.IsError)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("getSalesByUser")]
        public async Task<IActionResult> GetSalesByUser( int userId)
        {
            try
            {
                ResponseVM response = await ShopService.GetOrdersByUser(userId);
                if (!response.IsError)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        [HttpPost("saveOrder")]
        public async Task<IActionResult> SaveOrder(InvoiceRequestVM invoice)
        {
            try
            {
                ResponseVM response = await ShopService.CreateOrder(invoice);
                if (!response.IsError)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
