@Patch
@Regression
Feature: Patch Post with provided body
	Strory:

@Smoke
Scenario: 1. Patch post with passed valid body value
	Given I have free API
	When I send patch request to update body field
	Then I see returned patched post details

Scenario Outline: 2. Validate Post patch with invalid post id
	Given I have free API
	When I send Patch request with <WrongPostId> invalid post id
	Then I see NotFound response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId   | WrongPostId | ErrorResponse |
		| minValue | -999999     | {}            |
		| zero     | 0           | {}            |

Scenario Outline: 3. Validate Post patch with invalid body
	Given I have free API
	When I send put request with <WrongBody> invalid post body
	Then I see BadRequest response status code
	And I see <ErrorResponse> response

	Examples: 
		| TestId      | WrongBody | ErrorResponse |
		| emptyString |           | {}            |