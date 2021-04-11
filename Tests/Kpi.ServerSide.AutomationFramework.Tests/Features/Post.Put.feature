@Put
@Regression
Feature: Put Post with provided body
	Strory:

@Smoke
Scenario: 1. Put post with passed valid body
	Given I have free API
	When I send put request with valid body
	Then I see returned updated post details

Scenario Outline: 2. Validate Post put with invalid user id
	Given I have free API
	When I send put request with <WrongId> invalid user id
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongId | ErrorResponse |
		| minValue | -999999 | {}            |
		| zero     | 0       | {}            |

Scenario Outline: 3. Validate Post put with invalid body
	Given I have free API
	When I send put request with <WrongBody> invalid post body
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongBody | ErrorResponse |
		| emptyString |           | {}            |

Scenario Outline: 4. Validate Post put with invalid title
	Given I have free API
	When I send put request with <WrongTitle> invalid post title
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongTitle | ErrorResponse |
		| emptyString |            | {}            |

Scenario Outline: 5. Validate Post put with invalid post id
	Given I have free API
	When I send put request with <WrongPostId> invalid post id
	Then I see NotFound response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongPostId | ErrorResponse |
		| minValue | -999999     | {}            |
		| zero     | 0           | {}            |
