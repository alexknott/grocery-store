namespace GroceryStore.Products
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
    }
}