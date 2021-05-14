@Delete
@Regression
Feature: Delete User by name
	Story:

@Smoke
Scenario: 1. Validate Delete User by name with valid data
	Given I have free API with swagger
	When I create user by post request
	And I send delete request with created user name
	Then I see OK status code

Scenario Outline: 2. Validate Delete User by name with invalid data
	Given I have free API with swagger
	When I send delete request with invalid user name
	Then I see NotFound status code
