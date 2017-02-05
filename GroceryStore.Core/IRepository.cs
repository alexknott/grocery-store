using System.Collections.Generic;

namespace GroceryStore.Core
{
    public interface IRepository<out TOut>
    {
        IEnumerable<TOut> Get();
        TOut Get(string Id);
    }
}
