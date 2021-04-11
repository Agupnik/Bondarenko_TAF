@Post
@Regression
Feature: Create Post with provided body
	Strory:

@Smoke
Scenario: 1. Create new post with passed valid body
	Given I have free API
	When I create new post with valid data
	Then I see returned post details

Scenario Outline: 2. Validate Post creation with invalid user id
	Given I have free API
	When I create new post with <WrongId> invalid user id
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongId | ErrorResponse |
		| minValue | -999999 | {}            |
		| zero     | 0       | {}            |

Scenario Outline: 3. Validate Post creation with invalid body
	Given I have free API
	When I create new post with <WrongBody> invalid post body
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongBody | ErrorResponse |
		| emptyString |           | {}            |

Scenario Outline: 4. Validate Post creation with invalid title
	Given I have free API
	When I create new post with <WrongTitle> invalid post title
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongTitle | ErrorResponse |
		| emptyString |            | {}            |
