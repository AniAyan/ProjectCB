//using Core.Entities;
using Core.Mapping;
using Core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class CustomerRepository
    {
        private readonly AppDbContext dbContext;
        private readonly CustomerEntityDTOMapper customerMapper;

        public CustomerRepository(AppDbContext dbContext, CustomerEntityDTOMapper customerMapper)
        {
            this.dbContext = dbContext;
            this.customerMapper = customerMapper;
        }

        public List<CustomerDTO> GetCustomers()
        {
            var customersDB = dbContext.Customers.Include(c => c.Region).ToList();
            var customersDTO = customerMapper.MapToDTOList(customersDB);

            return customersDTO;
        }
    }
}
