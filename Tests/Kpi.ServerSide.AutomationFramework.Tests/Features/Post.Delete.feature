@Delete
@Regression
Feature: Delete Post by Id
	Strory:

@Smoke
Scenario: 1. Validate Delete Post by id with valid data
	Given I have free API
	When I send delete request with valid id
	Then I see OK response status code

Scenario Outline: 2. Validate Delete Post by Id with invalid data
	Given I have free API
	When I send delete post with <WrongId> wrong id
	Then I see NotFound response status code

	Examples: 
		| TestId   | WrongId            |
		| string   | string             |
		| specChar | @#%^wewe!""&*()№\/ |
		| maxValue | 99999999999999999  |
		| minValue | -999999            |
		| zero     | 0                  |