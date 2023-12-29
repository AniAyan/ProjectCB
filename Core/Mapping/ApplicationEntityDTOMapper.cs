using AutoMapper;
using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class ApplicationEntityDTOMapper
    {
        private readonly IMapper mapper;

        public ApplicationEntityDTOMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Application, ApplicationDTO>()
                   .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
                   .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                   .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Branch.Name));
            });

            mapper = configuration.CreateMapper();
        }

        public ApplicationDTO MapToDTO(Application entity)
        {
            return mapper.Map<ApplicationDTO>(entity);
        }

        public List<ApplicationDTO> MapToDTOList(List<Application> entityList)
        {
            return entityList.Select(entity => MapToDTO(entity)).ToList();
        }
    }
}
