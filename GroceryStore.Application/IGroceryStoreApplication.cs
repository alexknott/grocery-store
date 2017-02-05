using System.Collections.Generic;

namespace GroceryStore.Application
{
    public interface IGroceryStoreApplication
    {
        string PriceBasket(IEnumerable<string> productNames);
    }
}