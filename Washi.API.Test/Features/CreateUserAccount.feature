Feature: Create user account
	As user
	I want to register with my email on the page
	So that, make use of the services it offers.

@CreateUserAccount


Scenario: Account creation confirmation
	Given it is required to confirm the registration of a user
	When the user finishes filling in their registration data
	Then A confirmation message is then sent to the email you used.
