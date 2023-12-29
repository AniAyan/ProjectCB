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
    public class BranchDTOViewModelMapper
    {
        private readonly IMapper mapper;

        public BranchDTOViewModelMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BranchDTO, BranchViewModel>();
            });

            mapper = configuration.CreateMapper();
        }

        public BranchViewModel MapToViewModel(BranchDTO dto)
        {
            return mapper.Map<BranchViewModel>(dto);
        }

        public List<BranchViewModel> MapToViewModelList(List<BranchDTO> dtoList)
        {
            return dtoList.Select(dto => MapToViewModel(dto)).ToList();
        }
    }
}
