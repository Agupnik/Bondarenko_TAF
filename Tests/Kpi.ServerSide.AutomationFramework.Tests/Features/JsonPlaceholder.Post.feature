@Post
@Regression
Feature: Post JsonPlaceholder with provided body
	Strory:

@Smoke
Scenario: 1. Post new JsonPlaceholder with passed valid body
	Given I have free API
	When I post new JsonPlaceholder with valid data
	Then I see returned JsonPlaceholder details

Scenario Outline: 2. Validate JsonPlaceholder post with invalid user id
	Given I have free API
	When I post new JsonPlaceholder with <WrongId> invalid user id
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongId | ErrorResponse |
		| minValue | -999999 | {}            |
		| zero     | 0       | {}            |

Scenario Outline: 3. Validate JsonPlaceholder post with invalid body
	Given I have free API
	When I post new JsonPlaceholder with <WrongBody> invalid JsonPlaceholder body
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongBody | ErrorResponse |
		| emptyString |           | {}            |

Scenario Outline: 4. Validate JsonPlaceholder post with invalid title
	Given I have free API
	When I post new JsonPlaceholder with <WrongTitle> invalid JsonPlaceholder title
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongTitle | ErrorResponse |
		| emptyString |            | {}            |
