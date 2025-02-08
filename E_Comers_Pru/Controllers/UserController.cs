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
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                ResponseVM response = await UserService.GetUsers();
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
        public async Task<IActionResult> Create(UserDto dto)
        {
            try
            {
                ResponseVM response = await UserService.Create(dto);
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
        public async Task<IActionResult> Update(UserDto dto)
        {
            try
            {
                ResponseVM response = await UserService.Update(dto);
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
