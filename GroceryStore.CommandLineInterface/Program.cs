using GroceryStore.Application;
using GroceryStore.Basket;
using GroceryStore.Products;
using GroceryStore.SpecialOffers;

namespace GroceryStore.CommandLineInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var commandLineInterfaceService = new CommandLineInterfaceService(new ConsoleFacade(), BootstrapGroceryStoreApplication());
            while (true)
            {
                commandLineInterfaceService.ProcessCommands();
            }
        }

        private static IGroceryStoreApplication BootstrapGroceryStoreApplication()
        {
            var productService = new ProductService(new ProductRepository());
            return new GroceryStoreApplication(productService, new BasketFactory(), new SpecialOfferService(new SpecialOfferRepository(productService)));
        }
    }
}
