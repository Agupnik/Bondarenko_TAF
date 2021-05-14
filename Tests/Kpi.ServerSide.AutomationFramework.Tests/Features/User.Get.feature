@Get
@Regression
Feature: Get User by name
	Story:

@Smoke
Scenario: 1. Validate Get User by name with valid data
	Given I have free API with swagger
	When I create user by post request
	And I receive get user by name response
	Then I see returned user details which are equal with created

Scenario Outline: 2. Validate Get User by name with invalid data
	Given I have free API with swagger
	When I receive get user by name response with invalid name
	Then I see NotFound response status code