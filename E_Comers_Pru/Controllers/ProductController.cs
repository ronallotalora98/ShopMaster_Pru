using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_Pru.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducService ProducService;

        public ProductController(IProducService producService)
        {
            ProducService = producService;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GeProducts()
        {
            try
            {
                ResponseVM response = await ProducService.GetProducts();
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


        [HttpPost("create")]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            try
            {
                ResponseVM response = await ProducService.Create(dto);
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

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductDto dto)
        {
            try
            {
                ResponseVM response = await ProducService.Update(dto);
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
