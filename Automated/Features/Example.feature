Feature: ExampleFeature


@exampleTag
Scenario: Example
	Given Simple step
	And Async step
	When Table step
	| name1  | name2  |
	| data11 | data12 |
	| data21 | data22 |
	| data241 | data3422 |
	Then Simple step with parameter 120
	And Some step with argument transformation in 15 days
	When Some step with 'Monthly budget' xlsx file transformation
	When Table step with transformation
	| First  | Second  |
	| data11 | data12 |
	| data21 | data22 |

@tms:auto_honda_accord_26736369.html @link:auto_honda_accord_26736369.html @critical
Scenario: Assist helpers
	Given Create instance from table
	| Field  | Value |
	| First  | sda  |
	| Second | secondData |

	When Create another instanse from tabe
	| First | Second  |
	| asdwed | secondData |

	And Compare instance
	| First | Second  |
	| First perfect | Second perfect |

@ignore
Scenario: Not implemented steps
	Given something

Scenario: WOrking with examples
	Given some step with <some_parameter> from example

Examples:
	| some_parameter |
	| 45             |
	| 32			 |