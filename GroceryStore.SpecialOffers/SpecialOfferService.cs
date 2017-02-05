using System.Collections.Generic;
using System.Linq;
using GroceryStore.Core;
using GroceryStore.Products;

namespace GroceryStore.SpecialOffers
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IRepository<ISpecialOffer> _specialOffersRepository;

        public SpecialOfferService(IRepository<ISpecialOffer> specialOffersRepository)
        {
            _specialOffersRepository = specialOffersRepository;
        }

        public IEnumerable<ISpecialOffer> Get(IList<IProduct> products)
        {
            if (!products.Any())
                return new List<ISpecialOffer>();

            var specialOffers = _specialOffersRepository.Get();
            var offers = from offer in specialOffers
                         join prod in products
                         on offer.SpecialOfferProduct.Name equals prod.Name
                         select offer;

            return offers.Where(o => o.Applies(products)).ToList();
        }
    }
}
