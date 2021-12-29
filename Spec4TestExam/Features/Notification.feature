Feature: Notification
	In order to avoid overworking
	As a user
	I want to be told when i try to take a shift that i cant take

@mytag
Scenario: Taking a shift im unqualified for
	Given i have a qualification level of 2
	And the shift has as qualification level of 3
	When i check qualification
	Then i should be rejected

Scenario: Taking a shift im qualified for
    Given i have a qualification level of 3
    And the shift has as qualification level of 3
    When i check qualification
    Then i should be accepted


