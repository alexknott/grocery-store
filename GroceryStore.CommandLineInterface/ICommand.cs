using System.Collections.Generic;

namespace GroceryStore.CommandLineInterface
{
    public interface ICommand
    {
        string Name { get; }
        IEnumerable<string> Arguments { get; }
    }
}