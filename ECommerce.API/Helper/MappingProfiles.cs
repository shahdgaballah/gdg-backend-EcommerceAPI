using AutoMapper;
using ECommerce.API.Dtos;
using ECommerce.Domain.Entities;

namespace ECommerce.API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name));
        }
    }
}
