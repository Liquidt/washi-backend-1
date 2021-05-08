using System;
using TechTalk.SpecFlow;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Washi;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace WashiSpecTest.Steps
{
    [Binding]
    public class GetSubscriptionFeatureSteps: IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private WebApplicationFactory<TestStartup> _factory;
        private HttpClient _client { get; set; }
        protected HttpResponseMessage ResponseMessage { get; set; }
        public GetSubscriptionFeatureSteps(WebApplicationFactory<TestStartup>factory)
        {
            _factory = factory;
        }
        [Given(@"I am a washer")]
        public void GivenIAmAWasher()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress=new Uri($"https://washiapi20210419224935.azurewebsites.net/")
            });
        }
        
        [When(@"I make a get request to '(.*)' with the subscription id of '(.*)'")]
        public virtual async Task WhenIMakeAGetRequestToWithTheSubscriptionIdOf(string endpoint, int subscriptionId)
        {
            var postRelativeUri = new Uri(endpoint + subscriptionId, UriKind.Relative);
            ResponseMessage = await _client.GetAsync(postRelativeUri).ConfigureAwait(false);
        }
        [Then(@"the response should be a status code of '(.*)'")]
        public void ThenTheResponseShouldBeAStatusCodeOf(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, ResponseMessage.StatusCode);
        }
    }
}
