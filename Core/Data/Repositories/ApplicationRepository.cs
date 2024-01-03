using Core.DTO;
using Core.Entities;
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
        private List<Application> GetApplicationsDB()
        {
            var applicationsDB = dbContext.Applications.Include(c => c.Type)
                                                       .Include(c => c.Customer)
                                                       .Include(c => c.Branch)
                                                       .ToList();

            return applicationsDB;
        }
        public List<ApplicationDTO> GetApplications()
        {
            var applicationsDTO = applicationMapper.MapToDTOList(GetApplicationsDB());

            return applicationsDTO;
        }

        public List<ApplicationDTO> GetApplicationsByCustomerId(int customerId)
        {
            return GetApplications().Where(a => a.CustomerId == customerId).ToList();
        }
        public void UpdateBranchInApplication(int applicationId, int newBranchId)
        {
            var application = dbContext.Applications.Find(applicationId);

            if (application != null)
            {
                application.Branch = dbContext.Branches.Find(newBranchId);
                dbContext.SaveChanges();
            }
        }
    }
}
