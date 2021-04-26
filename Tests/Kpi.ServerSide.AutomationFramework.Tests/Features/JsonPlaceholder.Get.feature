@Get
@Regression
Feature: Get JsonPlaceholder by Id
	Strory:

@Smoke
Scenario: 1. Validate Get JsonPlaceholder by id with valid data
	Given I have free API
	When I receive get JsonPlaceholder by id response
	Then I see returned JsonPlaceholder details

Scenario Outline: 2. Validate Get JsonPlaceholder by Id with invalid data
	Given I have free API
	When I receive get JsonPlaceholder by id with <WrongId> wrong id
	Then I see NotFound response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongId            | ErrorResponse |
		| string   | string             | {}            |
		| specChar | @#%^wewe!""&*()№\/ | {}            |
		| maxValue | 99999999999999999  | {}            |
		| minValue | -999999            | {}            |
		| zero     | 0                  | {}            |