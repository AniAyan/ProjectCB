using AutoMapper;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.ViewModels;

namespace View.Mapping
{
    public class CustomerDTOViewModelMapper
    {
        private readonly IMapper mapper;

        public CustomerDTOViewModelMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDTO, CustomerViewModel>();
            });

            mapper = configuration.CreateMapper();
        }

        public CustomerViewModel MapToViewModel(CustomerDTO dto)
        {
            return mapper.Map<CustomerViewModel>(dto);
        }

        public List<CustomerViewModel> MapToViewModelList(List<CustomerDTO> dtoList)
        {
            return dtoList.Select(dto => MapToViewModel(dto)).ToList();
        }
    }
}
