Feature: Exmple with Gherkin Language

Background:
	Given this is given for all scenarious in feature

@someTag
Scenario: Basic keywords example
	Given this is given
	And this is and
	* this is asterisk
	When this is when with 'string' parameter
	Then this is then with int '3' parameter
	But this is but

Scenario Outline: Scenario outline example
	Given step with <first> parameter
	When step with <second> parameter

	Examples:
		| first | second |
		| 1     | 2      |
		| 3     | 4      |

Scenario: Scenario with large string
	Given this is given with large string
		"""
		Some text
		is
		here
		"""

Scenario: Scenario with table
	Given this is given with table
		| First  | Second |
		| data11 | data12 |
		| data21 | data22 |