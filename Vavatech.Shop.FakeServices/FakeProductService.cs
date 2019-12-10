using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using System.Linq;
using Bogus;

namespace Vavatech.Shop.FakeServices
{
    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public IEnumerable<Product> Get(decimal from, decimal to)
        {
            return entities
                .Where(e => e.UnitPrice >= from && e.UnitPrice <= to)
                .ToList();
        }
    }
}
