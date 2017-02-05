using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GroceryStore.Basket;
using GroceryStore.Core;
using GroceryStore.Core.Exceptions;
using GroceryStore.Products;
using GroceryStore.SpecialOffers;
using Moq;
using TechTalk.SpecFlow;

namespace GroceryStore.Application.Acceptance.Tests
{
    [Binding]
    public class PriceBasketSteps
    {
        private IList<IProduct> _products = new List<IProduct>();
        private IList<ISpecialOffer> _specialOffers = new List<ISpecialOffer>();
        private Mock<IRepository<IProduct>> _productRepositoryMock = new Mock<IRepository<IProduct>>();
        private Mock<IRepository<ISpecialOffer>> _specialOfferRepositoryMock = new Mock<IRepository<ISpecialOffer>>();
        private GroceryStoreApplication _groceryStoreApplication;
        private Func<string> _groceryStoreApplicationAction;
        private string _actualPriceBasketMessage;

        [Given(@"the product (.*) with price (.*)")]
        public void GivenTheProductWithPrice(string name, decimal price)
        {
            var product = new Product(name, price);
            _products.Add(product);
        }

        [Given(@"a grocery store application instance")]
        public void GivenAGroceryStoreApplicationInstance()
        {
            foreach (var product in _products)
                _productRepositoryMock.Setup(m => m.Get(product.Name)).Returns(product);

            _specialOfferRepositoryMock.Setup(m => m.Get()).Returns(_specialOffers);

            _groceryStoreApplication = new GroceryStoreApplication(
                new ProductService(_productRepositoryMock.Object),
                new BasketFactory(), 
                new SpecialOfferService(_specialOfferRepositoryMock.Object));
        }

        [Given(@"the single discount for (.*) for (.*) percent")]
        public void GivenTheSingleDiscountForForPercent(string specialOfferProductName, decimal discountPercent)
        {
            var specialOfferProduct = _products.FirstOrDefault(p => p.Name.Equals(specialOfferProductName, StringComparison.InvariantCultureIgnoreCase));
            var offerActivationProduct = new OfferActivationProduct(specialOfferProductName, 1);
            var specialOffer = new SpecialOfferByProductBundle(specialOfferProduct,
                new List<OfferActivationProduct> {offerActivationProduct}, discountPercent);

            _specialOffers.Add(specialOffer);
        }

        [Given(@"the bundle discount for (.*) for (.*) percent when purchasing (.*)")]
        public void GivenTheBundleDiscountForForPercentWhenPurchasing(string specialOfferProductName, decimal discountPercent, string bundleProductName)
        {
            var specialOfferProduct = _products.FirstOrDefault(p => p.Name.Equals(specialOfferProductName, StringComparison.InvariantCultureIgnoreCase));
            var offerActivationProduct = new OfferActivationProduct(bundleProductName, 2);
            var specialOffer = new SpecialOfferByProductBundle(specialOfferProduct,
                new List<OfferActivationProduct> { offerActivationProduct }, discountPercent);

            _specialOffers.Add(specialOffer);
        }


        [When(@"calling PriceBasket (.*)")]
        public void WhenCallingPriceBasket(string products)
        {
            _groceryStoreApplicationAction = () => _groceryStoreApplication.PriceBasket(products.Split(' '));
        }

        [Then(@"expected message ""(.*)""")]
        public void ThenExpectedMessage(string expectedMessage)
        {
            var expected = expectedMessage.Replace(@"\r\n", Environment.NewLine);
            _actualPriceBasketMessage = _groceryStoreApplicationAction();
            _actualPriceBasketMessage.Should().Be(expected);
        }

        [Then(@"a ProductNotFound exception should be thrown")]
        public void ThenAProductNotFoundExceptionShouldBeThrown()
        {
            Action action = () => _groceryStoreApplicationAction();
            action.ShouldThrow<ProductNotFoundException>();
        }
    }
}
