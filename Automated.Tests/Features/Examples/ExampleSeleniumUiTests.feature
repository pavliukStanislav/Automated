Feature: ExampleSpecflowUiTests
	UI tests with using Selenium

@uiTest
Scenario: Assert google search results exists
	Given User navigates to Google Search Main page
	When User searchs 'google' on the Google Search Main page
	Then User checks 'www.google' presents on the Google Search Results page

@uiTest
Scenario: Assert google search results exists in few browsers in the same time
	Given User navigates to Google Search Main page
	When User searchs 'google' on the Google Search Main page
		* User opens new browser with name 'another browser'
		* User makes 'another browser' browser main one
		* User navigates to Google Search Main page
		* User searchs 'google' on the Google Search Main page
		* User makes 'main browser' browser main one
	Then User checks 'www.google' presents on the Google Search Results page
	When User makes 'another browser' browser main one
	Then User checks 'www.google' presents on the Google Search Results page