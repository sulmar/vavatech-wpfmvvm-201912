using System;
using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using System.Linq;
using Bogus;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.Shop.FakeServices
{

    public class FakeCustomerService : ICustomerService
    {
        private IEnumerable<Customer> customers;

        // Install-Package Bogus    
        public FakeCustomerService(Faker<Customer> customerFaker)
        {
            customers = customerFaker.Generate(100);
        }

        public IEnumerable<Customer> Get()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));

            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public Task<IEnumerable<Customer>> GetAsync()
        {
            return Task.Run(() => Get());
        }
    }
}
