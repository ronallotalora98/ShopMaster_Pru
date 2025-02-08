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
    //  [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService RoleService;

        public RoleController(IRoleService roleService)
        {
            RoleService = roleService;
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                ResponseVM response = await RoleService.GetRoles();
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
        public async Task<IActionResult> Create(RolDto dto)
        {
            try
            {
                ResponseVM response = await RoleService.Create(dto);
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
        public async Task<IActionResult> Update(RolDto dto)
        {
            try
            {
                ResponseVM response = await RoleService.Update(dto);
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
