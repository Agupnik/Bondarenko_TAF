using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Delete User by name")]
    public class DeleteUserDefinition
    {
        private readonly UserRequest _defaultUser;
        private readonly IPetStoreContext _petStoreContext;
        private ResponseMessage _responseMessage;

        public DeleteUserDefinition(
            IPetStoreContext userContext)
        {
            _petStoreContext = userContext;
            _defaultUser = UserStorage.UserRequests["Default"];
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I create user by post request")]
        public async Task WhenICreateUserByPostRequest()
        {
            await _petStoreContext.CreateUserResponseAsync(
                _defaultUser);
        }

        [When(@"I send delete request with created user name")]
        public async Task WhenISendDeleteRequestWithCreatedUserName()
        {
            _responseMessage = await _petStoreContext.DeleteUserResponseAsync(
                _defaultUser.Username);
        }

        [Then(@"I see (.*) status code")]
        public void ThenISeeOkStatusCode(string statusCode)
        {
            _responseMessage.StatusCode.Should().Be(
                statusCode);
        }

        [When(@"I send delete request with invalid user name")]
        public async Task WhenISendDeleteRequestWithInvalidUserName()
        {
            _responseMessage = await _petStoreContext.DeleteUserResponseAsync(
                Guid.NewGuid().ToString());
        }
    }
}
