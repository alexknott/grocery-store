using System.Collections.Generic;
using GroceryStore.Products;

namespace GroceryStore.Basket
{
    public interface IBasketFactory
    {
        IBasket Create(IEnumerable<IProduct> products);
    }
}