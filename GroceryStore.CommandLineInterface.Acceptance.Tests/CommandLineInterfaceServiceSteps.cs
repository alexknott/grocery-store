using System;
using System.Collections.Generic;
using FluentAssertions;
using GroceryStore.Application;
using GroceryStore.Core.Exceptions;
using Moq;
using TechTalk.SpecFlow;

namespace GroceryStore.CommandLineInterface.Acceptance.Tests
{
    [Binding]
    public class CommandLineInterfaceServiceSteps
    {
        private readonly Mock<IConsole> _consoleMock = new Mock<IConsole>();
        private readonly Mock<IGroceryStoreApplication> _groceryStoreApplicationMock = new Mock<IGroceryStoreApplication>();
        private CommandLineInterfaceService _commandLineInterfaceService;
        private Action _processCommandsAction;

        [Given(@"a command line interface service instance")]
        public void GivenACommandLineInterfaceServiceInstance()
        {
            _commandLineInterfaceService = new CommandLineInterfaceService(_consoleMock.Object, _groceryStoreApplicationMock.Object);
        }

        [Given(@"the price basket grocery store application method returns (.*)")]
        public void GivenThePriceBasketGroceryStoreApplicationMethodReturns(string returnMessage)
        {
            _groceryStoreApplicationMock.Setup(m => m.PriceBasket(It.IsAny<IEnumerable<string>>())).Returns(returnMessage);
        }

        [When(@"I send the command (.*)")]
        public void WhenISendTheCommand(string command)
        {
            _consoleMock.Setup(m => m.ReadLine()).Returns(command);
            _processCommandsAction = () => _commandLineInterfaceService.ProcessCommands();

        }

        [Then(@"an CommandResolverException is thrown")]
        public void ThenAnCommandResolverExceptionIsThrown()
        {
            _processCommandsAction.ShouldThrow<CommandResolverException>().And.Message.Should().Be("Unknown command requested");
        }

        [Then(@"the PriceBasket grocery store application method should be called with (.*) parameters")]
        public void ThenThePriceBasketGroceryStoreApplicationMethodShouldBeCalledWithParameters(string parameters)
        {
            _processCommandsAction();

            var expectedArguments = parameters.Split(',');

            _groceryStoreApplicationMock.Verify(m => m.PriceBasket(expectedArguments), Times.Once);
        }

        [Then(@"the output (.*) is written to the console")]
        public void ThenTheOutputIsWrittenToTheConsole(string expectedMessage)
        {
            _processCommandsAction();
            _consoleMock.Verify(m => m.WriteLine(expectedMessage), Times.Once);
        }
    }
}
