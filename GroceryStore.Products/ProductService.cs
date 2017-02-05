using System.Collections.Generic;
using GroceryStore.Core;
using GroceryStore.Core.Exceptions;

namespace GroceryStore.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<IProduct> _productRepository;

        public ProductService(IRepository<IProduct> productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<IProduct> GetProducts(IList<string> productNames)
        {
            var products = new List<IProduct>();
            foreach (var productName in productNames)
            {
                var product = _productRepository.Get(productName);
                if (product == null)
                    throw new ProductNotFoundException("Product not found");

                products.Add(product);
            }

            return products;
        }

        public IProduct Get(string productName)
        {
            return _productRepository.Get(productName);
        }
    }
}
