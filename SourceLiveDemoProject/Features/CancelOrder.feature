Feature: CancelOrder

Scenario: Can Cancel order
	Given Sourcedemo live is loaded succcesfully
	When User logs in as a standard user 
	And  the user adds sauce lab backpacks and saucel labs bike light to cart
	And User proceeds to checkout Information
	And user cancels the transaction
	Then Order is canceled Succesfully
