Feature: UserRegistrationFeature
	In order to register
	As a user
	I want to create an account with the required data to access the experience that it offers me

@mytag
Scenario: The data entered is valid
	Given I have entered my data correctly
	When I make a post users request to 'api/users' with the following data '{ "email": "lucian@gmail.com",	"password": "password"	}'
	And also I make a post request to 'api/userprofiles' with the following data '{ "firstName": "Luciano", "lastName": "Alva", "dateOfBirth": "2021-05-08T14:45:59.175Z", "sex":"Male", "address":"Ca. Manco Capac 121 dpto 21","phoneNumber":"98817154","corporationName":"Repsol","userType": "washer","imageUrl":"empty", "districtId": 1 }'
	Then the response should be a status code of '200'

Scenario: The data entered is not valid
	Given I have entered my data correctly
	When I make a post users request to 'api/users' with the following data '{ "email": "lucian@gmail.com",	"password": "password"	}'
	And also I make a post request to 'api/users/24/accounts' with the following data '{ "FirstName": "Luciano", "LastName": "Alva", "BirthDate": "1978-06-03", "AccountType": "Musician", "DistrictId": 1 }'
	Then the response should be a status code of '400'