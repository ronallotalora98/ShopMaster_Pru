using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.ViewModel;
using E_Comers_Pru.Repositories.IRepositoy;
using E_Comers_Pru.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Service
{
    public class RoleService : IRoleService
    {
        protected readonly IMapper Mapper;
        protected readonly IRoleRepository RoleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            Mapper = mapper;
            RoleRepository = roleRepository;
        }

        public async Task<ResponseVM> GetRoles()
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<RolEntity> data = await RoleRepository.GetRoles();
                result.Element = Mapper.Map<IEnumerable<RolDto>>(data);
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Create(RolDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<RolEntity> entitiesByName = await RoleRepository.GetRolesByName(dto.Name);
                if (entitiesByName.Any())
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                RolEntity data = Mapper.Map<RolEntity>(dto);
                data = await RoleRepository.Create(data);
                result.Element = Mapper.Map<RolDto>(data);

            }
            catch (Exception ex)
            {
                result.Result = false;
                result.IsError = true;
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResponseVM> Update(RolDto dto)
        {
            ResponseVM result = new();
            try
            {
                IEnumerable<RolEntity> entitiesByCode = await RoleRepository.GetRolesByName(dto.Name);
                if (entitiesByCode.Any(x => x.Id != dto.Id))
                {
                    result.Result = false;
                    result.Message = "Ya existe un rol con el nombre ingresado";
                    return result;
                }

                RolEntity data = Mapper.Map<RolEntity>(dto);
                await RoleRepository.Update(data);
            
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
