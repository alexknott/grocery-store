Feature: Grocery store application basket price feature
	End to end test scenarios for the basket price feature of the grocery store application

Scenario: When a product with no offers is ordered the basket prices correctly
	Given the product Milk with price 1.30
	And a grocery store application instance
	When calling PriceBasket Milk
	Then expected message "Subtotal: £1.30\r\n(No offers available)\r\nTotal price: £1.30\r\n"

Scenario: When two products with no offers is ordered the basket prices correctly
	Given the product Milk with price 1.30
	And the product Bread with price 0.80
	And a grocery store application instance
	When calling PriceBasket Milk Bread
	Then expected message "Subtotal: £2.10\r\n(No offers available)\r\nTotal price: £2.10\r\n"

Scenario: When an unknown product is ordered an exception is thrown
	Given a grocery store application instance
	When calling PriceBasket Unknown 
	Then a ProductNotFound exception should be thrown

Scenario: When a product with single special offer is ordered the basket prices correctly
	Given the product Apples with price 1.00
	And the single discount for Apples for 15 percent
	And a grocery store application instance
	When calling PriceBasket Apples
	Then expected message "Subtotal: £1.00\r\nApples 15% Off: -£0.15\r\nTotal price: £0.85\r\n"

Scenario: When product with bundle special offer is ordered the basket prices correctly
	Given the product Soup with price 0.65
	And the product Bread with price 0.80
	And the bundle discount for Bread for 50 percent when purchasing Soup
	And a grocery store application instance
	When calling PriceBasket Soup Bread Soup
	Then expected message "Subtotal: £2.10\r\nBread 50% Off: -£0.40\r\nTotal price: £1.70\r\n"

Scenario: When a mix of products is order the basket is prices correctly
	Given the product Soup with price 0.65
	And the product Bread with price 0.80
	And the product Milk with price 1.30
	And the product Apples with price 1.00
	And the single discount for Apples for 15 percent
	And the bundle discount for Bread for 50 percent when purchasing Soup
	And a grocery store application instance
	When calling PriceBasket Soup Bread Soup Bread Apples Milk Apples
	Then expected message "Subtotal: £6.20\r\nApples 15% Off: -£0.15\r\nApples 15% Off: -£0.15\r\nBread 50% Off: -£0.40\r\nTotal price: £5.50\r\n"
