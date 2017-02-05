using System.Collections.Generic;
using System.Linq;
using GroceryStore.Products;

namespace GroceryStore.Basket
{
    public class BasketFactory : IBasketFactory
    {
        public IBasket Create(IEnumerable<IProduct> products)
        {
            return new Basket(products.ToList());            
        }
    }
}
