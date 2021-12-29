Feature: Notification
	In order to avoid overworking
	As a user
	I want to be told when i try to take a shift that i cant take

@mytag
Scenario: Taking a shift im unqualified for
	Given i meet all other requirements
	And i have a qualification level of 2
	And the shift has as qualification level of 3
	When i try to book the shift
	Then i should be rejected

Scenario: Taking a shift im qualified for
    Given i meet all other requirements
    And i have a qualification level of 3
    And the shift has as qualification level of 3
    When i try to book the shift
    Then i should be accepted

Scenario: Taking a shift on a day where i have no shifts
    Given i meet all other requirements
    And i have a shift next week
    And there is a shift available tomorrow from 12 to 16
	When i try to book the shift
    Then i should be accepted

Scenario: Taking a shift on the same day as a day where already have a shift but not at the same time
    Given i meet all other requirements
    And i have a shift tomorrow from 7 to 11
    And there is a shift available tomorrow from 12 to 16
	When i try to book the shift
    Then i should be accepted

Scenario: Taking a shift on the same day as a day where already have a shift at the same time
    Given i meet all other requirements
    And i have a shift tomorrow from 10 to 14
    And there is a shift available tomorrow from 12 to 16
	When i try to book the shift
    Then i should be rejected

Scenario: Taking a shift in a week where i already am at the maximum number of shifts
    Given i meet all other requirements
    And i have 5 shifts tomorrow
    And there is a shift available tomorrow
    When i try to book the shift
    Then i should be rejected

Scenario: Taking a shift in a week where i am on bellow maximum number of shifts
    Given i meet all other requirements
    And i have 4 shifts tomorrow
    And there is a shift available tomorrow
    When i try to book the shift
    Then i should be accepted