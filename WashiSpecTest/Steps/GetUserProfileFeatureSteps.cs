using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace WashiSpecTest.Steps
{
    class GetUserProfileFeatureSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;
        private ScenarioContext _scenarioContext;
        public GetUserProfileFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"that a user profile exists in the system")]
        public void GivenThatAUserProfileExistsInTheSystem()
        {
            client = new RestClient("https://washiapi20210419224935.azurewebsites.net/api");
            request = new RestRequest("/userprofiles/{id}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("id", 1);
        }

        [When(@"I request to get the user profile by id")]
        public void WhenIRequestToGetTheUserProfileById()
        {
            response = client.Execute(request);
        }

    }
}
