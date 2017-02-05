using System;

namespace GroceryStore.CommandLineInterface
{
    public class ConsoleFacade : IConsole
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
