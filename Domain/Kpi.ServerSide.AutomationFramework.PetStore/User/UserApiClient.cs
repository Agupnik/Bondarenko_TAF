using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.Model.Platform.Communication;
using Kpi.ServerSide.AutomationFramework.Platform.Client;
using Kpi.ServerSide.AutomationFramework.Platform.Communication.Http;
using Kpi.ServerSide.AutomationFramework.Platform.Configuration.Environment;
using Serilog;

namespace Kpi.ServerSide.AutomationFramework.PetStore.User
{
    public class UserApiClient : ApiClientBase, IUserApiClient
    {
        public UserApiClient(
            IClient client,
            ILogger logger,
            IEnvironmentConfiguration environmentConfiguration)
            : base(client, logger)
        {
            client.SetBaseUri(environmentConfiguration.EnvironmentUri);
            Logger.Information($"PetStore: Set base uri: {environmentConfiguration.EnvironmentUri}");
        }

        public async Task<UserResponse> GetUserByNameAsync(
            string userName)
        {
            var restResponse = await ExecuteGetAsync(
                $"/v2/user/{userName}");

            return restResponse.GetModel<UserResponse>();
        }

        public async Task<ResponseMessage> GetUserByNameResponseAsync(
            string userName)
        {
            Logger.Information(
                "Start '{@Method}' with {@userName} as username",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userName);

            var restResponse = await ExecuteGetAsync(
                $"/v2/user/{userName}");

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }

        public async Task<ResponseMessage> CreateUserResponseAsync(
            UserRequest userRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@userRequest} as new user",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userRequest);

            var restResponse = await ExecutePostAsync(
                "/v2/user",
                userRequest);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }

        public async Task<ResponseMessage> DeleteUserResponseAsync(
            string userName)
        {
            Logger.Information(
                "Start '{@Method}' with {@userName} username",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userName);

            var restResponse = await ExecuteDeleteAsync(
                $"/v2/user/{userName}");

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }

        public async Task<ResponseMessage> UpdateUserResponseAsync(
            string userName, UserRequest userRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@userRequest} as new user body and {@userName} as name of user that should be updated",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userRequest);

            var restResponse = await ExecutePutAsync(
                $"/v2/user/{userName}",
                userRequest);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }
    }
}
