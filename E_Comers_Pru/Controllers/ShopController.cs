using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_Pru.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        
        
        [HttpGet("getAllSales")]
        public async Task<IActionResult> GetAllSales()
        {
            try
            {
                ResponseVM response = new ResponseVM(); //await RoleService.GetRoles();
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
        public async Task<IActionResult> GetSalesByUser()
        {
            try
            {
                ResponseVM response = new ResponseVM(); //await RoleService.GetRoles();
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
