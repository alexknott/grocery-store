using System.Collections.Generic;
using GroceryStore.Core;
using GroceryStore.Products;

namespace GroceryStore.SpecialOffers
{
    public class SpecialOfferRepository : IRepository<ISpecialOffer>
    {
        private readonly IProductService _productService;

        public SpecialOfferRepository(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ISpecialOffer> Get()
        {
            return PopulateSpecialOffers();      
        }

        private IList<ISpecialOffer> PopulateSpecialOffers()
        {
            var apples = _productService.Get("Apples");
            var bread = _productService.Get("Bread");
            return new List<ISpecialOffer>
            {
                new SpecialOfferByProductBundle(apples,
                    new List<OfferActivationProduct> {new OfferActivationProduct("Apples", 1)}, 10),
                new SpecialOfferByProductBundle(bread,
                    new List<OfferActivationProduct> {new OfferActivationProduct("Soup", 2)}, 50)
            };
        }

        public ISpecialOffer Get(string Id)
        {
            throw new System.NotSupportedException();
        }
    }
}