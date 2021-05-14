using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.User
{
    public interface IUserApiClient
    {
        Task<UserResponse> GetUserByNameAsync(
            string userName);

        Task<ResponseMessage> GetUserByNameResponseAsync(
            string userName);

        Task<ResponseMessage> CreateUserResponseAsync(
            UserRequest userRequest);

        Task<ResponseMessage> DeleteUserResponseAsync(
            string userName);

        Task<ResponseMessage> UpdateUserResponseAsync(
            string userName, UserRequest userRequest);
    }
}
