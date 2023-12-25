using Core.Entities;
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

        public CustomerRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Customer> GetCustomers()
        {
            return dbContext.Customers.ToList();
        }
    }
}
