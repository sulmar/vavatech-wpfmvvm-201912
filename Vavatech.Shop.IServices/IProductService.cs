using System.Collections.Generic;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> Get(ProductSearchCriteria criteria);
    }


}
