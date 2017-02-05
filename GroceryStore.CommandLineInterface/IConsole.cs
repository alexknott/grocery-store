namespace GroceryStore.CommandLineInterface
{
    public interface IConsole
    {
        string ReadLine();
        void WriteLine(string line);
    }
}