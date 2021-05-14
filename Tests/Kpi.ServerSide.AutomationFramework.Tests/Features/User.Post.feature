@Post
@Regression
Feature: User Registration
	Story:

@Smoke
Scenario: 1. Validate User creation with provided model
	Given I have free API with swagger
	When I send the user creation request with provided model
	Then I see created user in the get response