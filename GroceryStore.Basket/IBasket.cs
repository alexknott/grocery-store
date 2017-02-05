using System.Collections.Generic;
using GroceryStore.Products;
using GroceryStore.SpecialOffers;

namespace GroceryStore.Basket
{
    public interface IBasket
    {
        IList<IProduct> Products { get; }
        decimal SubTotal { get; }
        decimal GetBasketTotal(IEnumerable<ISpecialOffer> specialOffers);
        string PriceBasket(IList<ISpecialOffer> specialOffers);
    }
}