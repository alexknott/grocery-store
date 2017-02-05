using System.Collections.Generic;
using GroceryStore.Products;

namespace GroceryStore.SpecialOffers
{
    public interface ISpecialOffer
    {
        IProduct SpecialOfferProduct { get; }
        decimal GetDiscountAmout();
        bool Applies(IEnumerable<IProduct> products);
    }
}
