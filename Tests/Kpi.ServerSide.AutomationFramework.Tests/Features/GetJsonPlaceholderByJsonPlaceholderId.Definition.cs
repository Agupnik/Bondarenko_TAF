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
    [Binding, Scope(Feature = "Get JsonPlaceholder by Id")]
    public class GetPostByPostId
    {
        private readonly IJsonPlaceholderContext _postContext;
        private JsonPlaceholderResponse _postResponse;
        private ResponseMessage _responseMessage;

        public GetPostByPostId(
            IJsonPlaceholderContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
        }

        [When(@"I receive get JsonPlaceholder by id response")]
        public async Task WhenIReceiveGetJsonPlaceholderByIdResponse()
        {
            _postResponse = await _postContext.GetJsonPlaceholderByIdAsync(
                JsonPlaceholderGetValidData.ValidPostId);
        }

        [When(@"I receive get JsonPlaceholder by id with (.*) wrong id")]
        public async Task WhenIReceiveGetJsonPlaceholderByIdWithWrongId(
            string value)
        {
            _responseMessage = await _postContext.GetJsonPlaceholderByIdResponseAsync(
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

        [Then(@"I see returned JsonPlaceholder details")]
        public void ThenISeeReturnedJsonPlaceholderDetails()
        {
            var expectedResponse = JsonPlaceholderResponsesStorage.JsonPlaceholderResponses["Default"];
            _postResponse.Should().BeEquivalentTo(
                expectedResponse);
        }
    }
}
