Feature: Work With Configuration

Tests with getting configuration data
Given should fail on CI
When should fail locally

Scenario: Get default json configuration
	Given Assert user email from json is equal to 'user@user.com'
	When Assert user email from command line is equal to 'usercommand@user.com'