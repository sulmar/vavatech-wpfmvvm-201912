using System;
using System.Collections.Generic;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
    }
}
