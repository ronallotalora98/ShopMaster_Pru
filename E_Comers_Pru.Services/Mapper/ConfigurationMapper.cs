using AutoMapper;
using E_Comers_Pru.Common.Dtos;
using E_Comers_Pru.Common.Entities;
using E_Comers_Pru.Common.ViewModel.Response;
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

            CreateMap<RolDto, RolEntity>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code));

            CreateMap<RolEntity, RolDto>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code));

            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<ProductDto, ProductEntity>();
            CreateMap<ProductEntity, ProductDto>();

            CreateMap<OrdenEntity, InvoiceResponseVM>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.OrdenDate, opt => opt.MapFrom(src => src.OrdenDate))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
             .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
             .ForMember(dest => dest.NameUser, opt => opt.MapFrom(src => src.User.Name))
             .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.DetailOrders.Select(det => new DetailOrderDto
             {
                 Id = det.Id,
                 OrdenId = det.OrdenId,
                 ProductId = det.ProductId,
                 Amount = det.Amount,
                 UnitPrice = det.UnitPrice,
             }).ToList()
            ));
        }
    }
}
