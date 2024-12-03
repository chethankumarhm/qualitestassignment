Feature: Temperature

Seach for the Bournemouth so you can see the weather result for Bournemouth

@Tester
Scenario: Assert tomorrow high temperature is greater than tomorrows low temperature
	Given launch the browser
	When  Enter the url
	Then  Enter the city name text into Enter a city textfield
	And   Click on search icon
	And   Click on the result which matches the city name
	Then  Validate Maximum temperature of the day should be greater than minimum temperature of the day
	And   Close the browser

