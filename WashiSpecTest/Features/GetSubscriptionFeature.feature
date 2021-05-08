Feature: GetSubscriptionFeature
	As a washer
	I want to see the available subscriptions
	in order to find the subscription i need

@mytag
Scenario: Subscription was found
	Given I am a washer
	When I make a get request to 'api/subsriptions/' with the subscription id of '1'
	Then the response should be a status code of '200'

	@mytag
Scenario: Subscription was not found
	Given I am a washer
	When I make a get request to 'api/subsriptions/' with the subscription id of '50'
	Then the response should be a status code of '400'
