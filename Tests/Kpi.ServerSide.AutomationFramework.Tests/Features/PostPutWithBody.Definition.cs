using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Post;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post;
using Kpi.ServerSide.AutomationFramework.TestsData.Valid_Data.Post;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Put Post with provided body")]
    public class PostPutWithBody
    {
        private readonly IPostContext _postContext;
        private PostResponse _postResponse;
        private ResponseMessage _responseMessage;

        public PostPutWithBody(
            IPostContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
            // Not supported because unneeded
        }

        [When(@"I send put request with valid body")]
        public async Task WhenSendingPutRequestWithValidBody()
        {
            _postResponse = await _postContext.PutPostAsync(
                PostResponsesStorage.PostResponses["PostToPut"], PostGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid user id")]
        public async Task WhenPutPostWithInvalidUserId(
            int value)
        {
            _responseMessage = await _postContext.PutPostResponseAsync(
                value,
                PostCreateValidData.ValidTitle,
                PostCreateValidData.ValidBody, PostGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid post body")]
        public async Task WhenPutPostWithInvalidBody(
            string value)
        {
            _responseMessage = await _postContext.PutPostResponseAsync(
                PostCreateValidData.ValidId,
                PostCreateValidData.ValidTitle,
                value, 
                PostGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid post title")]
        public async Task WhenPutPostWithInvalidTitle(
            string value)
        {
            _responseMessage = await _postContext.PutPostResponseAsync(
                PostCreateValidData.ValidId,
                value,
                PostCreateValidData.ValidBody,
                PostGetValidData.ValidPostId);
        }

        [When(@"I send put request with (.*) invalid post id")]
        public async Task WhenPutPostWithInvalidPostId(
            int value)
        {
            _responseMessage = await _postContext.PutPostResponseAsync(
                PostCreateValidData.ValidId,
                PostCreateValidData.ValidTitle,
                PostCreateValidData.ValidBody,
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

        [Then(@"I see returned updated post details")]
        public void ThenISeeReturnedUpdatedPostDetails()
        {
            var expectedResponse = PostResponsesStorage.PostResponses["PostToPut"];
            _postResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
