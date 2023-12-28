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
    public class CustomerEntityDTOMapper
    {
        private readonly IMapper mapper;

        public CustomerEntityDTOMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>()
                   .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.Name));
            });

            mapper = configuration.CreateMapper();
        }

        public CustomerDTO MapToDTO(Customer entity)
        {
            return mapper.Map<CustomerDTO>(entity);
        }

        public List<CustomerDTO> MapToDTOList(List<Customer> entityList)
        {
            return entityList.Select(entity => MapToDTO(entity)).ToList();
        }
    }
}
