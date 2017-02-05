namespace GroceryStore.Products
{
    public class Product : IProduct
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }
    }
}
