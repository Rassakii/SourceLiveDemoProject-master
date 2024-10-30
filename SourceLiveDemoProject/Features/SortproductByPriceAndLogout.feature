Feature: SortproductByPriceAndLogout

Scenario: Sort Product by price and Sign out
	Given Sourcedemo live is loaded succcesfully
	When User logs in as a standard user 
	And User sorts product by price 
	And user proceeds to logout
	Then signedout succesfully