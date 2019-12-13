using System.Collections.Generic;
using System.Threading.Tasks;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> Get(ProductSearchCriteria criteria);

        Task<IEnumerable<Product>> GetAsync(ProductSearchCriteria criteria);
    }


}
