using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroceryStore.Products;
using GroceryStore.SpecialOffers;

namespace GroceryStore.Basket
{
    public class Basket : IBasket
    {
        private StringBuilder _stringBuilder;

        public Basket()
        {
            Products = new List<IProduct>();
        }

        public Basket(IList<IProduct> products)
        {
            Products = products;
        }

        public IList<IProduct> Products { get; }

        public decimal SubTotal => Products.Sum(x => x.Price);

        public decimal GetBasketTotal(IEnumerable<ISpecialOffer> specialOffers)
        {
            var discountAmount = GetDiscountAmount(specialOffers.ToArray());
            return Products.Sum(p => p.Price) - discountAmount;
        }

        private decimal GetDiscountAmount(IList<ISpecialOffer> specialOffers)
        {
            if (!specialOffers.Any())
                return 0;

            return specialOffers.Sum(so => so.GetDiscountAmout());
        }
        
        public string PriceBasket(IList<ISpecialOffer> specialOffers)
        {
            var basketTotal = GetBasketTotal(specialOffers);
            _stringBuilder = new StringBuilder();
            _stringBuilder.AppendLine($"Subtotal: £{SubTotal:N}");

            if (!specialOffers.Any())
                _stringBuilder.AppendLine("(No offers available)");
            else
                foreach (var offer in specialOffers)
                    _stringBuilder.AppendLine(offer.ToString());

            _stringBuilder.AppendLine($"Total price: £{basketTotal:N}");
            return _stringBuilder.ToString();
        }
    }
}
