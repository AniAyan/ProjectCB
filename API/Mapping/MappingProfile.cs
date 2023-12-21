using API.Models;
using AutoMapper;
using Core.Entities;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Core.Entities.Customer, Models.Customer>().ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Name));
        }
    }
}
