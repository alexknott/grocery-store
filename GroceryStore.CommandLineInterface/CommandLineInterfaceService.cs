using GroceryStore.Application;

namespace GroceryStore.CommandLineInterface
{
    public class CommandLineInterfaceService : ICommandLineInterfaceService
    {
        private readonly IConsole _consoleFacade;
        private readonly IGroceryStoreCommandResolver _groceryStoreCommandResolver;

        public CommandLineInterfaceService(IConsole consoleFacade, IGroceryStoreApplication groceryStoreApplication)
        {
            _consoleFacade = consoleFacade;
            _groceryStoreCommandResolver = new GroceryStoreCommandResolver(groceryStoreApplication);
        }

        public void ProcessCommands()
        {
            WaitForCommand();
        }
        
        public void WaitForCommand()
        {
            _consoleFacade.WriteLine("Please enter a command for the grocery store assistant...");

            ProcessCommand();

            _consoleFacade.WriteLine("");
        }

        private void ProcessCommand()
        {
            var requestedCommand = _consoleFacade.ReadLine();
            
            var command = new Command(requestedCommand);

            var action = _groceryStoreCommandResolver.Resolve(command);
            var message = action();

            _consoleFacade.WriteLine(message);
        }
    }
}
