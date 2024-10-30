Feature: SignIN

Scenario: User can sign In Successfully
	Given Sourcedemo live is loaded succcesfully
	When User logs in as a standard user 
	Then user is logged in succesfully
