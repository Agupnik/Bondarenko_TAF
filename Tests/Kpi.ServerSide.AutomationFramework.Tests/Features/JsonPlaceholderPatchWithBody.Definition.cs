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
    [Binding, Scope(Feature = "Patch JsonPlaceholder with provided body")]
    public class PostPatchWithBody
    {
        private readonly IJsonPlaceholderContext _postContext;
        private JsonPlaceholderResponse _postResponse;
        private ResponseMessage _responseMessage;

        public PostPatchWithBody(
            IJsonPlaceholderContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
        }

        [When(@"I send patch request to update body field")]
        public async Task WhenSendingPatchRequestWithValidBody()
        {
            _postResponse = await _postContext.PatchJsonPlaceholderBodyAsync(
                JsonPlaceholderPatchStorage.JsonPlaceholderPatchBodies["Default"], JsonPlaceholderGetValidData.ValidPostId);
        }

        [When(@"I send Patch request with (.*) invalid JsonPlaceholder id")]
        public async Task WhenPatchPostWithInvalidJsonPlaceholderId(
            int value)
        {
            _responseMessage = await _postContext.PatchJsonPlaceholderResponseAsync(
                JsonPlaceholderPatchStorage.JsonPlaceholderPatchBodies["Default"].Body,
                value);
        }

        [When(@"I send Patch request with (.*) invalid JsonPlaceholder body")]
        public async Task WhenPatchJsonPlaceholderWithInvalidBody(
            string value)
        {
            _responseMessage = await _postContext.PatchJsonPlaceholderResponseAsync(
                value,
                JsonPlaceholderGetValidData.ValidPostId);
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

        [Then(@"I see returned patched JsonPlaceholder details")]
        public void ThenISeeReturnedPatchedJsonPlaceholderDetails()
        {
            var expectedResponse = JsonPlaceholderPatchStorage.JsonPlaceholderPatchBodies["Default"];
            _postResponse.Should().BeEquivalentTo(
                expectedResponse,
                options =>
                    options.ExcludingMissingMembers());
        }
    }
}
