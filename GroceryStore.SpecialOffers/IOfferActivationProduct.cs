namespace GroceryStore.SpecialOffers
{
    public interface IOfferActivationProduct
    {
        string ProductName { get; }
        int Quantity { get; }
        int Applied { get; set; }
    }
}