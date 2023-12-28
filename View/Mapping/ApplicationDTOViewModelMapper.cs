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
    public class ApplicationDTOViewModelMapper
    {
        private readonly IMapper mapper;

        public ApplicationDTOViewModelMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationDTO, ApplicationViewModel>();
            });

            mapper = configuration.CreateMapper();
        }

        public ApplicationViewModel MapToViewModel(ApplicationDTO dto)
        {
            return mapper.Map<ApplicationViewModel>(dto);
        }

        public List<ApplicationViewModel> MapToViewModelList(List<ApplicationDTO> dtoList)
        {
            return dtoList.Select(dto => MapToViewModel(dto)).ToList();
        }
    }
}
