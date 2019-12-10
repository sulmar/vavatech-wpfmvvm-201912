using System.Collections.Generic;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Bogus;
using System.Linq;

namespace Vavatech.Shop.FakeServices
{
    public class FakeEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IEnumerable<TEntity> entities;

        public FakeEntityService(Faker<TEntity> faker)
        {
            entities = faker.Generate(100);
        }

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }
    }
}
