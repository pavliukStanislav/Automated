Feature: ExampleSpecflowUiTests
	UI tests with using Selenium

@uiTest
Scenario: Assert google search results exists
	Given User open browser and navigate to Google Search Main page
	When User searchs 'google' on the Google Search Main page
	Then User checks 'www.google' presents on the Google Search Results page