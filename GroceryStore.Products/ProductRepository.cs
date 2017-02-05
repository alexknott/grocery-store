using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStore.Core;

namespace GroceryStore.Products
{
    public class ProductRepository : IRepository<IProduct>
    {
        private IList<Product> _products;

        public ProductRepository()
        {
            PopulateDefaultProducts();
        }

        private void PopulateDefaultProducts()
        {
            _products = new List<Product>
            {
                new Product("Soup", 0.65M),
                new Product("Bread", 0.80M),
                new Product("Milk", 1.30M),
                new Product("Apples", 1M)
            };
        }
        
        public IEnumerable<IProduct> Get()
        {
            return _products;
        }

        public IProduct Get(string name)
        {
            return _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
