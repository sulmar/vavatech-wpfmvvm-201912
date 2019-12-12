using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface ICustomerService : IEntityService<Customer>
    {
        Task<IEnumerable<Customer>> GetAsync();
    }

   
}
