Feature: FilterLaundriesFeature
	As a user
	I want to search a laundry using many filters
	in order to find the laundry I need

@mytag
Scenario: Using laundry filter I found many laundries that have this service
	Given I am a user
	When I select a service and make a request to '/api/laundryservicematerials/1/laundries'
	Then the result list should be a status code of '200'
	
@mytag
Scenario: Using laundry filter I found many laundries who have this service
	Given I am a user
	When I select a service and make a request to '/api/laundryservicematerials/66/laundries'
	Then the result list should be a status code of '400'
	And respond with an empty list

Scenario: Using service material filter I found many laundries that have this service
	Given I am a user
	When I select a service and make a request to '/api/servicematerial/1/laundries'
	Then the result list should be a status code of '200'

Scenario: Using service material filter I didn't find any laundry that has this service
	Given I am a user
	When I select a service and make a request to '/api/servicematerial/66/laundries'
	Then the result list should be a status code of '400'
	And respond with an empty list
