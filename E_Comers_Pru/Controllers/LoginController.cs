using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Common.ViewModel.Request;
using E_Comers_Pru.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Comers_Pru.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService LoginService;
        public LoginController(ILoginService loginService)
        {
            LoginService = loginService;
        }

        [HttpPost("auth-backoffice")]
        public async Task<IActionResult> AuthBackoffice(LoginRequestVM vm)
        {
            try
            {
                ResponseVM response = await LoginService.LoginBackoffice(vm);
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

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RenovateTokenRequestVM vm)
        {
            try
            {
                ResponseVM response = await LoginService.RenovateToken(vm);
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
