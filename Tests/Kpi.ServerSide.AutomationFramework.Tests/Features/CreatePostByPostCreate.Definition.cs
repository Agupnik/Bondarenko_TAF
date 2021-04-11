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
    [Binding, Scope(Feature = "Create Post with provided body")]
    public class CreatePostByPostCreate
    {
        private readonly IPostContext _postContext;
        private PostResponse _postResponse;
        private ResponseMessage _responseMessage;

        public CreatePostByPostCreate(
            IPostContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
            // Not supported because unneeded
        }

        [When(@"I create new post with valid data")]
        public async Task WhenCreatingNewPostWithValidData()
        {
            _postResponse = await _postContext.CreatePostAsync(
                PostCreateStorage.PostCreated["Default"]);
        }

        [When(@"I create new post with (.*) invalid user id")]
        public async Task WhenCreateNewPostWithInvalidUserId(
            int value)
        {
            _responseMessage = await _postContext.CreatePostResponseAsync(
                value, 
                PostCreateValidData.ValidTitle, 
                PostCreateValidData.ValidBody);
        }

        [When(@"I create new post with (.*) invalid post body")]
        public async Task WhenCreateNewPostWithInvalidBody(
            string value)
        {
            _responseMessage = await _postContext.CreatePostResponseAsync(
                PostCreateValidData.ValidId, 
                PostCreateValidData.ValidTitle,
                value);
        }

        [When(@"I create new post with (.*) invalid post title")]
        public async Task WhenCreateNewPostWithInvalidTitle(
            string value)
        {
            _responseMessage = await _postContext.CreatePostResponseAsync(
                PostCreateValidData.ValidId,
                value, 
                PostCreateValidData.ValidBody);
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

        [Then(@"I see returned post details")]
        public void ThenISeeReturnedPostDetails()
        {
            var expectedResponse = PostCreateStorage.PostCreated["Default"];
            _postResponse.Should().BeEquivalentTo(
                expectedResponse, 
                options => 
                    options.ExcludingMissingMembers());
        }
    }
}
