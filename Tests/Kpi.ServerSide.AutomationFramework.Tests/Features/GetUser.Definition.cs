using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Get User by name")]
    public class GetUserDefinition
    {
        private readonly IUserContext _userContext;
        private UserResponse _userResponse;
        private ResponseMessage _responseMessage;

        public GetUserDefinition(
            IUserContext userContext)
        {
            _userContext = userContext;
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I create user by post request")]
        public async Task WhenICreateUserByPostRequest()
        {
            await _userContext.CreateUserResponseAsync(
                UserStorage.UserRequests["Default"]);
        }

        [When(@"I receive get user by name response")]
        public async Task WhenIReceiveGetUserByNameResponse()
        {
            _userResponse = await _userContext.GetUserByNameAsync(
                UserStorage.UserRequests["Default"].Username);
        }

        [Then(@"I see returned user details which are equal with created")]
        public void ThenISeeReturnedUserDetailsWhichAreEqualWithCreated()
        {
            _userResponse.Username.Should().Be(
                UserStorage.UserRequests["Default"].Username);
        }

        [When(@"I receive get user by name response with invalid name")]
        public async Task WhenIReceiveGetUserByNameResponseWithInvalidName()
        {
            _responseMessage = await _userContext.GetUserByNameResponseAsync(Guid.NewGuid().ToString());
        }

        [Then(@"I see (.*) response status code")]
        public void ThenISeeResponseStatusCode(
            string expectedErrorResponse)
        {
            _responseMessage.StatusCode.Should().Be(
                expectedErrorResponse);
        }
    }
}
