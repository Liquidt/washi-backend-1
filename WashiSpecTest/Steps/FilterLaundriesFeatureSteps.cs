using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Washi;
using Xunit;

namespace WashiSpecTest.Steps
{
    [Binding]
    public class FilterLaundriesFeatureSteps: IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage ResponseMessage { get; set; }
        
        public FilterLaundriesFeatureSteps(WebApplicationFactory<TestStartup>factory)
        {
            _factory = factory;
        }

        [Given(@"I am a user")]
        public void GivenIAmAUser()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"https://washiapi20210419224935.azurewebsites.net/")
            });
        }
        
        [When(@"I select a service and make a request to '(.*)'")]
        public async Task WhenISelectAServiceAndMakeARequestTo(string endpoint)
        {
            var getRelativeUri = new Uri(endpoint, UriKind.Relative);
            ResponseMessage = await _client.GetAsync(getRelativeUri).ConfigureAwait(false);
        }
        
        [Then(@"the result list should be a status code of '(.*)'")]
        public void ThenTheResultListShouldBeAStatusCodeOf(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage.StatusCode);
        }
        
        [Then(@"respond with an empty list")]
        public void ThenRespondWithAnEmptyList()
        {
            var empty = ResponseMessage.RequestMessage.Properties.Count;
            Assert.Equal(0, empty);
        }
    }
}
