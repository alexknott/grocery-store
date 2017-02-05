using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GroceryStore.CommandLineInterface
{
    public class Command : ICommand
    {
        public Command(string arguments)
        {
            var args = SplitArguments(arguments);
            Name = args.First();
            Arguments = args.Skip(1);
        }

        private static string[] SplitArguments(string arguments)
        {
            Regex whitespace = new Regex("\\s");
            return whitespace.Split(arguments);
        }

        public string Name { get; }

        public IEnumerable<string> Arguments { get; }
    }
}
