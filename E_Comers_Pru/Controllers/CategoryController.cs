using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_Pru.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                ResponseVM response = await CategoryService.GetCategories();
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
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            try
            {
                ResponseVM response = await CategoryService.Create(dto);
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
        public async Task<IActionResult> Update(CategoryDto dto)
        {
            try
            {
                ResponseVM response = await CategoryService.Update(dto);
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
