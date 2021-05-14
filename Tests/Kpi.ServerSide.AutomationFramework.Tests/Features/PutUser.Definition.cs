using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Update User by name")]
    public class PutUserDefinition
    {
        private readonly IUserContext _userContext;

        public PutUserDefinition(
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

        [When(@"I send the user update request with same name and new body")]
        public async Task WhenISendTheUserUpdateRequestWithSameNameAndNewBody()
        {
            await _userContext.UpdateUserResponseAsync(
                UserStorage.UserRequests["Default"].Username,
                UserStorage.UserRequests["NewUserInfo"]);
        }

        [Then(@"I see updated user")]
        public async Task ThenISeeUpdatedUser()
        {
            var actual = await _userContext.GetUserByNameAsync(
                UserStorage.UserRequests["NewUserInfo"].Username);
            actual.Email.Should().BeEquivalentTo(UserStorage.UserRequests["NewUserInfo"].Email);
        }
    }
}
