using System;
using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using System.Linq;

namespace Vavatech.Shop.FakeServices
{

    public class FakeCustomerService : ICustomerService
    {
        private IEnumerable<Customer> customers;

        // Install-Package Bogus
        public FakeCustomerService(CustomerFaker customerFaker)
        {
            customers = customerFaker.Generate(100);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }
    }
}
