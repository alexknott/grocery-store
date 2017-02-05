using System.Collections.Generic;

namespace GroceryStore.Products
{
    public interface IProductService
    {
        IList<IProduct> GetProducts(IList<string> productNames);
        IProduct Get(string productName);
    }
}