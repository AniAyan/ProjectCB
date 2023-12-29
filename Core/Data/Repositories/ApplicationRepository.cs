using Core.DTO;
using Core.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class ApplicationRepository
    {
        private readonly AppDbContext dbContext;
        private readonly ApplicationEntityDTOMapper applicationMapper;

        public ApplicationRepository(AppDbContext dbContext, ApplicationEntityDTOMapper applicationMapper)
        {
            this.dbContext = dbContext;
            this.applicationMapper = applicationMapper;
        }

        public List<ApplicationDTO> GetApplications()
        {
            var applicationsDB = dbContext.Applications.Include(c => c.Type)
                                                       .Include(c => c.Customer)
                                                       .Include(c => c.Branch)
                                                       .ToList();
            var applicationsDTO = applicationMapper.MapToDTOList(applicationsDB);

            return applicationsDTO;
        }

        public List<ApplicationDTO> GetApplicationsByCustomerId(int customerId)
        {
            return GetApplications().Where(a => a.CustomerId == customerId).ToList();
        }
    }
}
