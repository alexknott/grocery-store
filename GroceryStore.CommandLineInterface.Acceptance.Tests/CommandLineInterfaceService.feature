Feature: CommandLineInterfaceService feature tests
	End to end test scenarios for the command line interface service

Scenario: When an unknown command sent the service throws an exception
 Given a command line interface service instance
 When I send the command Unknown Command
 Then an CommandResolverException is thrown

Scenario: When PriceBasket command is sent the service calls grocey store application with correct parameters
 Given a command line interface service instance
 When I send the command PriceBasket Milk Bread
 Then the PriceBasket grocery store application method should be called with Milk,Bread parameters

Scenario: When PriceBasket command is sent the output is written to the console
 Given a command line interface service instance
 And the price basket grocery store application method returns price basket response
 When I send the command PriceBasket Milk Bread
 Then the output price basket response is written to the console
