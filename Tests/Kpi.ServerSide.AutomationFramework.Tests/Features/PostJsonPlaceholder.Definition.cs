using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post;
using Kpi.ServerSide.AutomationFramework.TestsData.Valid_Data.Post;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Post JsonPlaceholder with provided body")]
    public class PostJsonPlaceholder
    {
        private readonly IJsonPlaceholderContext _postContext;
        private JsonPlaceholderResponse _postResponse;
        private ResponseMessage _responseMessage;

        public PostJsonPlaceholder(
            IJsonPlaceholderContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
        }

        [When(@"I post new JsonPlaceholder with valid data")]
        public async Task WhenPostNewJsonPlaceholderWithValidData()
        {
            _postResponse = await _postContext.CreateJsonPlaceholderAsync(
                JsonPlaceholderPostStorage.JsonPlaceholderPosts["Default"]);
        }

        [When(@"I post new JsonPlaceholder with (.*) invalid user id")]
        public async Task WhenPostNewJsonPlaceholderWithInvalidUserId(
            int value)
        {
            _responseMessage = await _postContext.CreateJsonPlaceholderResponseAsync(
                value, 
                JsonPlaceholderPostValidData.ValidTitle, 
                JsonPlaceholderPostValidData.ValidBody);
        }

        [When(@"I post new JsonPlaceholder with (.*) invalid JsonPlaceholder body")]
        public async Task WhenPostNewJsonPlaceholderWithInvalidBody(
            string value)
        {
            _responseMessage = await _postContext.CreateJsonPlaceholderResponseAsync(
                JsonPlaceholderPostValidData.ValidId, 
                JsonPlaceholderPostValidData.ValidTitle,
                value);
        }

        [When(@"I post new JsonPlaceholder with (.*) invalid JsonPlaceholder title")]
        public async Task WhenPostNewPostWithInvalidTitle(
            string value)
        {
            _responseMessage = await _postContext.CreateJsonPlaceholderResponseAsync(
                JsonPlaceholderPostValidData.ValidId,
                value, 
                JsonPlaceholderPostValidData.ValidBody);
        }

        [Then(@"I see (.*) response status code")]
        public void ThenISeeGivenResponseStatusCode(string expectedStatusCode)
        {
            _responseMessage.StatusCode.Should().Be(
                expectedStatusCode);
        }

        [Then(@"I see (.*) response")]
        public void ThenISeeResponse(
            string expectedErrorResponse)
        {
            _responseMessage.Content.Should().Be(
                expectedErrorResponse);
        }

        [Then(@"I see returned JsonPlaceholder details")]
        public void ThenISeeReturnedPostDetails()
        {
            var expectedResponse = JsonPlaceholderPostStorage.JsonPlaceholderPosts["Default"];
            _postResponse.Should().BeEquivalentTo(
                expectedResponse, 
                options => 
                    options.ExcludingMissingMembers());
        }
    }
}
