namespace GroceryStore.SpecialOffers
{
    public class OfferActivationProduct : IOfferActivationProduct
    {
        public OfferActivationProduct(string productName, int quantity)
        {
            ProductName = productName;
            Quantity = quantity;
            Applied = 1;
        }

        public string ProductName { get; }
        public int Quantity { get; }
        public int Applied { get; set; }
    }
}
