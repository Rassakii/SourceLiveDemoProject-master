Feature: OrderProducts

Scenario: User can order products
	Given Sourcedemo live is loaded succcesfully
	When User logs in as a standard user 
	And  the user adds sauce lab backpacks and saucel labs bike light to cart
	And user proceeds  to checkout and finish
	Then the products are purchased succesfully