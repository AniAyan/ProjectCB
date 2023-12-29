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
    public class BranchEntityDTOMapper
    {
        private readonly IMapper mapper;

        public BranchEntityDTOMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Branch, BranchDTO>();
            });

            mapper = configuration.CreateMapper();
        }

        public BranchDTO MapToDTO(Branch entity)
        {
            return mapper.Map<BranchDTO>(entity);
        }

        public List<BranchDTO> MapToDTOList(List<Branch> entityList)
        {
            return entityList.Select(entity => MapToDTO(entity)).ToList();
        }
    }
}
