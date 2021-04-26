@Put
@Regression
Feature: Put JsonPlaceholder with provided body
	Strory:

@Smoke
Scenario: 1. Put JsonPlaceholder with passed valid body
	Given I have free API
	When I send put request with valid body
	Then I see returned updated JsonPlaceholder details

Scenario Outline: 2. Validate JsonPlaceholder put with invalid user id
	Given I have free API
	When I send put request with <WrongId> invalid user id
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongId | ErrorResponse |
		| minValue | -999999 | {}            |
		| zero     | 0       | {}            |

Scenario Outline: 3. Validate JsonPlaceholder put with invalid body
	Given I have free API
	When I send put request with <WrongBody> invalid JsonPlaceholder body
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongBody | ErrorResponse |
		| emptyString |           | {}            |

Scenario Outline: 4. Validate JsonPlaceholder put with invalid title
	Given I have free API
	When I send put request with <WrongTitle> invalid JsonPlaceholder title
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongTitle | ErrorResponse |
		| emptyString |            | {}            |

Scenario Outline: 5. Validate JsonPlaceholder put with invalid JsonPlaceholder id
	Given I have free API
	When I send put request with <WrongJsonPlaceholderId> invalid JsonPlaceholder id
	Then I see NotFound response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongJsonPlaceholderId | ErrorResponse |
		| minValue | -999999                | {}            |
		| zero     | 0                      | {}            |
