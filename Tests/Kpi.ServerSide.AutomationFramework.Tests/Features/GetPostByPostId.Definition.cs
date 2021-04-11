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
    [Binding, Scope(Feature = "Get Post by Id")]
    public class GetPostByPostId
    {
        private readonly IPostContext _postContext;
        private PostResponse _postResponse;
        private ResponseMessage _responseMessage;

        public GetPostByPostId(
            IPostContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
            // Not supported because unneeded
        }

        [When(@"I receive get post by id response")]
        public async Task WhenIReceiveGetPostByIdResponse()
        {
            _postResponse = await _postContext.GetPostByIdAsync(
                PostGetValidData.ValidPostId);
        }

        [When(@"I receive get post by id with (.*) wrong id")]
        public async Task WhenIReceiveGetPostByIdWithWrongId(
            string value)
        {
            _responseMessage = await _postContext.GetPostByIdResponseAsync(
                value);
        }

        [Then(@"I see (.*) response status code")]
        public void ThenISeeGivenResponseStatusCode(
            string expectedStatusCode)
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

        [Then(@"I see returned post details")]
        public void ThenISeeReturnedPostDetails()
        {
            var expectedResponse = PostResponsesStorage.PostResponses["Default"];
            _postResponse.Should().BeEquivalentTo(
                expectedResponse);
        }
    }
}
