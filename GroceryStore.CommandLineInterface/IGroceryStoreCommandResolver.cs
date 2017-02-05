using System;

namespace GroceryStore.CommandLineInterface
{
    public interface IGroceryStoreCommandResolver
    {
        Func<string> Resolve(Command command);
    }
}