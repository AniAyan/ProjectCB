using Core.DTO;
using Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class BranchRepository
    {
        private readonly AppDbContext dbContext;
        private readonly BranchEntityDTOMapper branchMapper;

        public BranchRepository(AppDbContext dbContext, BranchEntityDTOMapper branchMapper)
        {
            this.dbContext = dbContext;
            this.branchMapper = branchMapper;
        }

        public List<BranchDTO> GetBranches()
        {
            var branchesDB = dbContext.Branches.ToList();
            var branchesDTO = branchMapper.MapToDTOList(branchesDB);

            return branchesDTO;
        }
    }
}
