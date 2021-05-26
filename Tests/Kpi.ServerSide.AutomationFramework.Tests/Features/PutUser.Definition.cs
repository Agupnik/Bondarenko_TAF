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
        private readonly UserRequest _defaultUser;
        private readonly UserRequest _newUserInfo;

        public PutUserDefinition(
            IUserContext userContext)
        {
            _userContext = userContext;
            _defaultUser = UserStorage.UserRequests["Default"];
            _newUserInfo = UserStorage.UserRequests["NewUserInfo"];
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I create user by post request")]
        public async Task WhenICreateUserByPostRequest()
        {
            await _userContext.CreateUserResponseAsync(
                _defaultUser);
        }

        [When(@"I send the user update request with same name and new body")]
        public async Task WhenISendTheUserUpdateRequestWithSameNameAndNewBody()
        {
            await _userContext.UpdateUserResponseAsync(
                _defaultUser.Username,
                _newUserInfo);
        }

        [Then(@"I see updated user")]
        public async Task ThenISeeUpdatedUser()
        {
            var actual = await _userContext.GetUserByNameAsync(
                _newUserInfo.Username);
            actual.Email.Should().BeEquivalentTo(_newUserInfo.Email);
        }
    }
}
