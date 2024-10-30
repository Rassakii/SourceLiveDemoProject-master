Feature: RemoverProductFromCart

Scenario: User can remove product from cart
	Given Sourcedemo live is loaded succcesfully
	When User logs in as a standard user
	And  the user adds sauce lab backpacks and saucel labs bike light to cart
	And User Removes the product in the cart
	Then the products are removed succesfully