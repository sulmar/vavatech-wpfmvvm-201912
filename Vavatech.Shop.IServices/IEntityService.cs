using System.Collections.Generic;

namespace Vavatech.Shop.IServices
{
    // interfejs generyczny
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
    }

}
