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
    [Binding, Scope(Feature = "Patch Post with provided body")]
    public class PostPatchWithBody
    {
        private readonly IPostContext _postContext;
        private PostResponse _postResponse;
        private ResponseMessage _responseMessage;

        public PostPatchWithBody(
            IPostContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
            // Not supported because unneeded
        }

        [When(@"I send patch request to update body field")]
        public async Task WhenSendingPatchRequestWithValidBody()
        {
            _postResponse = await _postContext.PatchPostBodyAsync(
                PostPatchStorage.PostPatchBodies["Default"], PostGetValidData.ValidPostId);
        }

        [When(@"I send Patch request with (.*) invalid post id")]
        public async Task WhenPatchPostWithInvalidPostId(
            int value)
        {
            _responseMessage = await _postContext.PatchPostResponseAsync(
                PostPatchStorage.PostPatchBodies["Default"].Body,
                value);
        }

        [When(@"I send put request with (.*) invalid post body")]
        public async Task WhenPatchPostWithInvalidBody(
            string value)
        {
            _responseMessage = await _postContext.PatchPostResponseAsync(
                value,
                PostGetValidData.ValidPostId);
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

        [Then(@"I see returned patched post details")]
        public void ThenISeeReturnedPatchedPostDetails()
        {
            var expectedResponse = PostPatchStorage.PostPatchBodies["Default"];
            _postResponse.Should().BeEquivalentTo(
                expectedResponse,
                options =>
                    options.ExcludingMissingMembers());
        }
    }
}
