using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "User Registration")]
    public class PostUserDefinition
    {
        private readonly UserRequest _defaultUser;
        private readonly IPetStoreContext _userContext;

        public PostUserDefinition(
            IPetStoreContext userContext)
        {
            _userContext = userContext;
            _defaultUser = UserStorage.UserRequests["Default"];
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I send the user creation request with provided model")]
        public async Task WhenISendTheUserCreationRequestWithProvidedModel()
        {
            await _userContext.CreateUserResponseAsync(_defaultUser);
        }

        [Then(@"I see created user in the get response")]
        public async Task ThenISeeCreatedUserInTheGetResponse()
        {
            var createdUser = await _userContext.GetUserByNameAsync(
                _defaultUser.Username);
            createdUser.Username.Should().Be(
                _defaultUser.Username);
        }
    }
}
