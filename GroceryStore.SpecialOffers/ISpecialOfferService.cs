using System.Collections.Generic;
using GroceryStore.Products;

namespace GroceryStore.SpecialOffers
{
    public interface ISpecialOfferService
    {
        IEnumerable<ISpecialOffer> Get(IList<IProduct> products);
    }
}