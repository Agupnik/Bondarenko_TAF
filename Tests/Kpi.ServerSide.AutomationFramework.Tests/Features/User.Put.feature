@Put
@Regression
Feature: Update User by name
	Story:

@Smoke
Scenario: 1. Validate Update User by name and body with valid data
	Given I have free API with swagger
	When I create user by post request
	And I send the user update request with same name and new body
	Then I see updated user