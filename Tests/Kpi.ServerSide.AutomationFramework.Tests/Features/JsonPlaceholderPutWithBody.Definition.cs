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
    [Binding, Scope(Feature = "Put JsonPlaceholder with provided body")]
    public class PostPutWithBody
    {
        private readonly IJsonPlaceholderContext _postContext;
        private JsonPlaceholderResponse _postResponse;
        private ResponseMessage _responseMessage;

        public PostPutWithBody(
            IJsonPlaceholderContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
        }

        [When(@"I send put request with valid body")]
        public async Task WhenSendingPutRequestWithValidBody()
        {
            _postResponse = await _postContext.PutJsonPlaceholderAsync(
                JsonPlaceholderResponsesStorage.JsonPlaceholderResponses["JsonPlaceholderToPut"], JsonPlaceholderGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid user id")]
        public async Task WhenPutJsonPlaceholderWithInvalidUserId(
            int value)
        {
            _responseMessage = await _postContext.PutJsonPlaceholderResponseAsync(
                value,
                JsonPlaceholderPostValidData.ValidTitle,
                JsonPlaceholderPostValidData.ValidBody, JsonPlaceholderGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid JsonPlaceholder body")]
        public async Task WhenPutJsonPlaceholderWithInvalidBody(
            string value)
        {
            _responseMessage = await _postContext.PutJsonPlaceholderResponseAsync(
                JsonPlaceholderPostValidData.ValidId,
                JsonPlaceholderPostValidData.ValidTitle,
                value, 
                JsonPlaceholderGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid JsonPlaceholder title")]
        public async Task WhenPutPostWithInvalidTitle(
            string value)
        {
            _responseMessage = await _postContext.PutJsonPlaceholderResponseAsync(
                JsonPlaceholderPostValidData.ValidId,
                value,
                JsonPlaceholderPostValidData.ValidBody,
                JsonPlaceholderGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid JsonPlaceholder id")]
        public async Task WhenPutPostWithInvalidJsonPlaceholderId(
            int value)
        {
            _responseMessage = await _postContext.PutJsonPlaceholderResponseAsync(
                JsonPlaceholderPostValidData.ValidId,
                JsonPlaceholderPostValidData.ValidTitle,
                JsonPlaceholderPostValidData.ValidBody,
                value);
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

        [Then(@"I see returned updated JsonPlaceholder details")]
        public void ThenISeeReturnedUpdatedJsonPlaceholderDetails()
        {
            var expectedResponse = JsonPlaceholderResponsesStorage.JsonPlaceholderResponses["JsonPlaceholderToPut"];
            _postResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
