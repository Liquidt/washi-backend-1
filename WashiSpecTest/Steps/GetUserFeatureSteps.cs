using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace WashiSpecTest.Steps
{
    [Binding]
    public class GetUserFeatureSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;
        private ScenarioContext _scenarioContext;
        public GetUserFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"that a user exists in the system")]
        public void GivenThatAUserExistsInTheSystem()
        {
            client = new RestClient("https://washiapi20210419224935.azurewebsites.net/api");
            request = new RestRequest("/users/{userid}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("userId", 1);
        }
        
        [When(@"I request to get the user by id")]
        public void WhenIRequestToGetTheUserById()
        {
            response = client.Execute(request);
        }
        
        [Then(@"the result code should be (.*)")]
        public void ThenTheResultCodeShouldBe(int status)
        {
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode, "Status code is not 200");
        }
    }
}
