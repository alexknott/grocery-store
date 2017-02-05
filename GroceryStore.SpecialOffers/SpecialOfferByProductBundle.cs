using System.Collections.Generic;
using System.Linq;
using GroceryStore.Products;

namespace GroceryStore.SpecialOffers
{
    public class SpecialOfferByProductBundle : ISpecialOffer
    {
        private readonly decimal _discountPercent;

        public SpecialOfferByProductBundle(IProduct specialOfferProduct, IEnumerable<IOfferActivationProduct> activationBundle, decimal discountPercent)
        {
            _discountPercent = discountPercent;
            SpecialOfferProduct = specialOfferProduct;
            ActivationProductBundle = activationBundle;
        }

        public IProduct SpecialOfferProduct { get; }

        private IEnumerable<IOfferActivationProduct> ActivationProductBundle { get; }

        public decimal GetDiscountAmout()
        {
            return SpecialOfferProduct.Price * (_discountPercent / 100);
        }

        public bool Applies(IEnumerable<IProduct> products)
        {
            foreach (var activationProduct in ActivationProductBundle)
            {
                var productCount = products.Count(p => p.Name.Equals(activationProduct.ProductName));
                if (productCount < activationProduct.Quantity * activationProduct.Applied)
                    return false;

                activationProduct.Applied++;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{SpecialOfferProduct.Name} {_discountPercent}% Off: -£{GetDiscountAmout():N}";
        }
    }
}