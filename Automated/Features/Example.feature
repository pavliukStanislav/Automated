Feature: ExampleFeature


@exampleTag
Scenario: Example
	Given Simple step
	And Async step
	When Table step
	| name1  | name2  |
	| data11 | data12 |
	| data21 | data22 |
	Then Simple step with parameter 120
	And Some step with argument transformation in 15 days