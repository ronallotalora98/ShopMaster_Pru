using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comers_Pru.Services.Mapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<RolDto, RolEntity>();
            CreateMap<RolEntity, RolDto>();
        }
    }
}
