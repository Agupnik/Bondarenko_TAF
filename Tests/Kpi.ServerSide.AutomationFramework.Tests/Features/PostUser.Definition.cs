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
    [Binding, Scope(Feature = "User Registration")]
    public class PostUserDefinition
    {
        private readonly IUserContext _userContext;

        public PostUserDefinition(
            IUserContext userContext)
        {
            _userContext = userContext;
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I send the user creation request with provided model")]
        public async Task WhenISendTheUserCreationRequestWithProvidedModel()
        {
            await _userContext.CreateUserResponseAsync(UserStorage.UserRequests["Default"]);
        }

        [Then(@"I see created user in the get response")]
        public async Task ThenISeeCreatedUserInTheGetResponse()
        {
            var createdUser = await _userContext.GetUserByNameAsync(
                UserStorage.UserRequests["Default"].Username);
            createdUser.Username.Should().Be(
                UserStorage.UserRequests["Default"].Username);
        }
    }
}
