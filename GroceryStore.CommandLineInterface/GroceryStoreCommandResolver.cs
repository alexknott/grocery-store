using System;
using GroceryStore.Application;
using GroceryStore.Core.Exceptions;

namespace GroceryStore.CommandLineInterface
{
    public class GroceryStoreCommandResolver : IGroceryStoreCommandResolver
    {
        private readonly IGroceryStoreApplication _groceryStoreApplication;

        public GroceryStoreCommandResolver(IGroceryStoreApplication groceryStoreApplication)
        {
            _groceryStoreApplication = groceryStoreApplication;
        }

        public Func<string> Resolve(Command command)
        {
            switch (command.Name)
            {
                case "PriceBasket":
                    return () => _groceryStoreApplication.PriceBasket(command.Arguments);
                default:
                    throw new CommandResolverException("Unknown command requested");
            }
        }
    }
}
