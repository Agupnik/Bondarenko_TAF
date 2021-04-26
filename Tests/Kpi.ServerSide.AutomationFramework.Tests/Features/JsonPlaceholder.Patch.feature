@Patch
@Regression
Feature: Patch JsonPlaceholder with provided body
	Strory:

@Smoke
Scenario: 1. Patch JsonPlaceholder with passed valid body value
	Given I have free API
	When I send patch request to update body field
	Then I see returned patched JsonPlaceholder details

Scenario Outline: 2. Validate JsonPlaceholder patch with invalid post id
	Given I have free API
	When I send Patch request with <WrongJsonPlaceholderId> invalid JsonPlaceholder id
	Then I see NotFound response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongJsonPlaceholderId | ErrorResponse |
		| minValue | -999999                | {}            |
		| zero     | 0                      | {}            |

Scenario Outline: 3. Validate JsonPlaceholder patch with invalid body
	Given I have free API
	When I send Patch request with <WrongBody> invalid JsonPlaceholder body
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongBody | ErrorResponse |
		| emptyString |           | {}            |