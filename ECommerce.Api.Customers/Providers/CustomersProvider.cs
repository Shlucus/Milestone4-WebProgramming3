using AutoMapper;
using ECommerce.Api.Customers.Db;
using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext dbContext;
        private readonly ILogger<CustomersProvider> logger;
        private readonly IMapper mapper;

        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
        {
               
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Customers.Any())
            {
                dbContext.Customers.Add(new Db.Customer() { Address = "Address 1", Id = 1, Name = "Lucas" });
                dbContext.Customers.Add(new Db.Customer() { Address = "Address 2", Id = 2, Name = "David" });
                dbContext.Customers.Add(new Db.Customer() { Address = "Address 3", Id = 3, Name = "Ryan" });
                dbContext.Customers.Add(new Db.Customer() { Address = "Address 4", Id = 4, Name = "Taryn" });
                dbContext.Customers.Add(new Db.Customer() { Address = "Address 5", Id = 5, Name = "Hana" });
                dbContext.SaveChanges();
            }
        }

        public Task<(bool IsSuccess, Models.Customer Customer, string ErrorMessage)> GetCustomerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
