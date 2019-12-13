using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using System.Linq;
using Bogus;
using System.Dynamic;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Vavatech.Shop.FakeServices
{
    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public IEnumerable<Product> Get(ProductSearchCriteria criteria)
        {
            IQueryable<Product> query = entities.AsQueryable();

            if (criteria.FromUnitPrice.HasValue)
            {
                query = query.Where(p => p.UnitPrice >= criteria.FromUnitPrice);
            }

            if (criteria.ToUnitPrice.HasValue)
            {
                query = query.Where(p => p.UnitPrice <= criteria.ToUnitPrice);
            }
            
            if (!string.IsNullOrEmpty(criteria.Name))
            {
                query = query.Where(p => p.Name.Contains(criteria.Name));
            }

            return query.ToList();


        }

        public Task<IEnumerable<Product>> GetAsync(ProductSearchCriteria criteria)
        {

            // return Task.FromResult(Get(criteria));

            return Task.Run(() => Get(criteria));
        }
    }
}
