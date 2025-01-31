using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.Settings;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Common.ViewModel.Request;
using E_Comers_Pru.Common.ViewModel.Response;
using E_Comers_Pru.Repositories.IRepositoy;
using E_Comers_Pru.Services.IService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class LoginService : ILoginService
    {
        private readonly LocalAdSettings LocalAdSettings;
        private readonly IUserRepository UserRepository;
        protected readonly IMapper Mapper;
        private readonly IJwtSecurityService JwtSecurityService;

        public LoginService(IOptions<LocalAdSettings> localAdSettings,
                            IUserRepository userRepository,
                            IMapper mapper,
                            IJwtSecurityService jwtSecurityService)
        {
            LocalAdSettings = localAdSettings.Value;
            UserRepository = userRepository;
            Mapper = mapper;
            JwtSecurityService = jwtSecurityService;
        }

        public async Task<ResponseVM> LoginBackoffice(LoginRequestVM vm)
        {
            ResponseVM result = new();
            try
            {
                UserDto dto = new();
                string token = string.Empty;
                UserEntity data = await UserRepository.SearchByEmail(vm.Username);
                if (data != null && data?.Id > 0)
                {
                    dto = Mapper.Map<UserDto>(data);
                    token = JwtSecurityService.GenerateTokenJwt(dto);

                    result.Element = new LoginResponseVM
                    {
                        User = dto,
                        Token = token,
                        Roles = Mapper.Map<RolDto>(data.Rol)
                    };
                }
                else
                {
                    result.Result = false;
                    result.Message = "El usuario no se encuentra registrado en el sistema";
                }
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> RenovateToken(RenovateTokenRequestVM vm)
        {
            ResponseVM result = new();
            try
            {
                int? userId = JwtSecurityService.ValidateCurrentToken(vm.Token ?? "");
                if (userId != null)
                {
                    UserEntity data = await UserRepository.GetUserById(userId ?? 0);
                    if (data != null && data?.Id > 0)
                    {
                        UserDto dto = Mapper.Map<UserDto>(data);
                        result.Element = JwtSecurityService.GenerateTokenJwt(dto);
                    }
                }
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
