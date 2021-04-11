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
    [Binding, Scope(Feature = "Delete Post by Id")]
    public class DeletePostById
    {
        private readonly IPostContext _postContext;
        private ResponseMessage _responseMessage;

        public DeletePostById(
            IPostContext postContext)
        {
            _postContext = postContext;
        }

        [Given(@"I have free API")]
        public void GivenIHaveFreeApi()
        {
            // Not supported because unneeded
        }

        [When(@"I send delete request with valid id")]
        public async Task WhenISendDeleteRequestWithValidId()
        {
            _responseMessage = await _postContext.DeletePostResponseAsync(
                PostGetValidData.ValidPostId.ToString());
        }

        [When(@"I send delete post with (.*) wrong id")]
        public async Task WhenISendDeleteRequestWithInvalidId(
            string value)
        {
            _responseMessage = await _postContext.DeletePostResponseAsync(
                value);
        }

        [Then(@"I see (.*) response status code")]
        public void ThenISeeGivenResponseStatusCode(
            string expectedStatusCode)
        {
            _responseMessage.StatusCode.Should().Be(
                expectedStatusCode);
        }
    }
}
