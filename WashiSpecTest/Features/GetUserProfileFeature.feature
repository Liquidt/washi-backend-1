Feature: GetUserProfileFeature
	In order to see my profile
	As a user
	I want to be able to recieve my profile information

@mytag
Scenario: Get profile info by Id
	Given that a user profile exists in the system
	When I request to get the user profile by id
	Then the result code should be 200