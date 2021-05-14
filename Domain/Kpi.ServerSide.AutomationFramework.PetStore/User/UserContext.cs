using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.PetStore.User
{
    public class UserContext : IUserContext
    {
        private readonly IUserApiClient _userApiClient;

        public UserContext(
            IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public async Task<ResponseMessage> CreateUserResponseAsync(
            UserRequest userRequest)
        {
            return await _userApiClient.CreateUserResponseAsync(userRequest);
        }

        public async Task<ResponseMessage> DeleteUserResponseAsync(
            string userName)
        {
            return await _userApiClient.DeleteUserResponseAsync(userName);
        }

        public async Task<UserResponse> GetUserByNameAsync(
            string userName)
        {
            return await _userApiClient.GetUserByNameAsync(userName);
        }

        public async Task<ResponseMessage> GetUserByNameResponseAsync(
            string userName)
        {
            return await _userApiClient.GetUserByNameResponseAsync(userName);
        }

        public async Task<ResponseMessage> UpdateUserResponseAsync(
            string userName, 
            UserRequest userRequest)
        {
            return await _userApiClient.UpdateUserResponseAsync(userName, userRequest);
        }
    }
}
