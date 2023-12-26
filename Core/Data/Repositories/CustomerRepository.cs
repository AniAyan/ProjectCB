//using Core.Entities;
using Core.DTO;
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
            var customersDB = dbContext.Customers.ToList();
            var customersDTO = new List<Customer>();

            foreach (var customerDB in customersDB)
            {
                var customer = new Customer
                {
                    Id = customerDB.Id,
                    FirstName = customerDB.FirstName,
                    LastName = customerDB.LastName,
                    Region = customerDB.Region.Name,
                    Address = customerDB.Address
                };
                customersDTO.Add(customer);
            }

            return customersDTO;
        }
    }
}
