using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Repositories.IRepositoy;
using E_Comers_Pru.Repositories.Repository;
using E_Comers_Pru.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class UserService: IUserService
    {
        protected readonly IMapper Mapper;
        protected readonly IUserRepository UserRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
        }

        public async Task<ResponseVM> GetUsers()
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<UserEntity> data = await UserRepository.GeUsers();
                result.Element = Mapper.Map<IEnumerable<UserEntity>>(data);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Create(UserDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<UserEntity> entitiesByName = await UserRepository.GetUserByName(dto.Name);
                if (entitiesByName.Any())
                {
                    result.Result = false;
                    result.Message = "Ya existe un Usuario con el nombre ingresado";
                    return result;
                }

                UserEntity data = Mapper.Map<UserEntity>(dto);
                data = await UserRepository.Create(data);
                result.Element = Mapper.Map<CategoryDto>(data);

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Update(UserDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<UserEntity> entitiesByCode = await UserRepository.GetUserByName(dto.Name);
                if (entitiesByCode.Any(x => x.Id != dto.Id))
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                UserEntity data = Mapper.Map<UserEntity>(dto);
                await UserRepository.Update(data);

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
