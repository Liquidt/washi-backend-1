Feature: GetUserFeature
	In order to get user information
	As a user
	I want to be able to recieve the user

@mytag
Scenario: Get user by Id
	Given that a user exists in the system
	When I request to get the user by id
	Then the result code should be 200