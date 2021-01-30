Feature: Example specflow
	Here you can see example of some specflow features

@exampleTag
Scenario: Tag scoping example
	Given Simple scoped step

Scenario: Example
	Given Simple step
	And Async step
	Then Simple step with parameter 120
	And Some step with argument transformation in 15 days
	When Some step with 'Monthly budget' xlsx file transformation
	When Table step with transformation
		| First  | Second |
		| data11 | data12 |
		| data21 | data22 |

@tms:thisIsTms @link:thisIsLink @issue:thisIsIssue @critical
Scenario: Assist helpers
	Given Create instance from table
		| Field  | Value      |
		| First  | sda        |
		| Second | secondData |
	When Create another instanse from tabe
		| First  | Second     |
		| asdwed | secondData |
	And Compare instance
		| First         | Second         |
		| First perfect | Second perfect |

@ignore
Scenario: Ignored test
	Given something