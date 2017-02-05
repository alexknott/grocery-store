using System.Collections.Generic;
using System.Linq;
using GroceryStore.Basket;
using GroceryStore.Products;
using GroceryStore.SpecialOffers;

namespace GroceryStore.Application
{
    public class GroceryStoreApplication : IGroceryStoreApplication
    {
        private readonly IProductService _productService;
        private readonly IBasketFactory _basketFactory;
        private readonly ISpecialOfferService _specialOfferService;

        public GroceryStoreApplication(IProductService productService, IBasketFactory basketFactory, ISpecialOfferService specialOfferService)
        {
            _productService = productService;
            _basketFactory = basketFactory;
            _specialOfferService = specialOfferService;
        }

        public string PriceBasket(IEnumerable<string> productNames)
        {
            var products = GetProducts(productNames);
            var offers = GetOffers(products).ToList();
            var basket = _basketFactory.Create(products);
            return basket.PriceBasket(offers);
        }

        private IEnumerable<ISpecialOffer> GetOffers(IEnumerable<IProduct> products)
        {
            return _specialOfferService.Get(products.ToList());
        }

        private IList<IProduct> GetProducts(IEnumerable<string> productNames)
        {
            return _productService.GetProducts(productNames.ToList());
        }
    }
}
