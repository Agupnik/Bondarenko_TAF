using System.Reflection;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder;
using Kpi.ServerSide.AutomationFramework.Model.Platform.Communication;
using Kpi.ServerSide.AutomationFramework.Platform.Client;
using Kpi.ServerSide.AutomationFramework.Platform.Communication.Http;
using Kpi.ServerSide.AutomationFramework.Platform.Configuration.Environment;
using Serilog;

namespace Kpi.ServerSide.AutomationFramework.JsonPlaceholder.Post
{
    public class JsonPlaceholderApiClient : ApiClientBase, IJsonPlaceholderApiClient
    {
        public JsonPlaceholderApiClient(
            IClient client, 
            ILogger logger, 
            IEnvironmentConfiguration environmentConfiguration) 
            : base(client, logger)
        {
            client.SetBaseUri(environmentConfiguration.EnvironmentUri);
        }

        public async Task<JsonPlaceholderResponse> GetJsonPlaceholderByIdAsync(int postId)
        {
            Logger.Information(
                "Start '{@Method}' with '{@postId}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                postId);

            var restResponse = await ExecuteGetAsync(
                $"/posts/{postId}");

            Logger.Information(
                "Finished '{@Method}' with '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            var model = restResponse.GetModel<JsonPlaceholderResponse>();
            return model;
        }

        public async Task<ResponseMessage> GetJsonPlaceholderByIdResponseAsync(string postId)
        {
            Logger.Information(
                "Start '{@Method}' with '{@postId}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName, 
                postId);

            var restResponse = await ExecuteGetAsync($"/posts/{postId}");
            
            Logger.Information(
                "Finished '{@Method}' with '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            var responseModel = new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
            return responseModel;
        }

        public async Task<JsonPlaceholderResponse> CreateJsonPlaceholderAsync(
            JsonPlaceholderPost postCreate)
        {
            Logger.Information(
                "Start '{@Method}' with '{@postCreate}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                postCreate);

            var restResponse = await ExecutePostAsync(
                $"/posts", 
                postCreate);

            Logger.Information(
                "Finished '{@Method}' with '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return restResponse.GetModel<JsonPlaceholderResponse>();
        }

        public async Task<ResponseMessage> CreateJsonPlaceholderResponseAsync(
            int userid, string title, string body)
        {
            Logger.Information(
                "Start '{@Method}' with user id as '{@userid}', title as '{@title}' and body as '{@body}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userid,
                body,
                title);

            var restResponse = await ExecutePostAsync(
                $"/posts",
                new JsonPlaceholderPost
                {
                    Body = body,
                    Title = title,
                    UserId = userid
                });

            Logger.Information(
                "Finished '{@Method}' with user id as '{@userid}', title as '{@title}' and body as '{@body}' with result '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse,
                userid, 
                title, 
                body);

            var responseModel = new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
            return responseModel;
        }

        public async Task<JsonPlaceholderResponse> PutJsonPlaceholderAsync(
            JsonPlaceholderResponse postResponse, int postId)
        {
            Logger.Information(
                "Start '{@Method}' with '{@postResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                postResponse);

            var restResponse = await ExecutePutAsync(
                $"/posts/{postId}",
                postResponse);

            Logger.Information(
                "Finished '{@Method}' with '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return restResponse.GetModel<JsonPlaceholderResponse>();
        }

        public async Task<ResponseMessage> PutJsonPlaceholderResponseAsync(
            int userid, string title, string body, int postId)
        {
            Logger.Information(
                "Start '{@Method}' with user id as '{@userid}', title as '{@title}', body as '{@body}' and post id as '{@postId}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userid,
                body,
                title,
                postId);

            var restResponse = await ExecutePutAsync(
                $"/posts/{postId}",
                new JsonPlaceholderResponse
                {
                    Id = postId,
                    Body = body,
                    Title = title,
                    UserId = userid
                });

            Logger.Information(
                "Finished '{@Method}' with user id as '{@userid}', title as '{@title}', body as '{@body}' and post id as '{@postId}' with result of '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse,
                userid,
                title, 
                body, 
                postId);

            var responseModel = new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
            return responseModel;
        }

        public async Task<JsonPlaceholderResponse> PatchJsonPlaceholderBodyAsync(
            JsonPlaceholderPatch postPatch, int postId)
        {
            Logger.Information(
                "Start '{@Method}' with '{@postPatch}' object which contains changed body value and '{@postId}' as post id",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                postPatch,
                postId);

            var restResponse = await ExecutePatchAsync(
                $"/posts/{postId}",
                postPatch);

            Logger.Information(
                "Finished '{@Method}' with '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return restResponse.GetModel<JsonPlaceholderResponse>();
        }

        public async Task<ResponseMessage> PatchJsonPlaceholderResponseAsync(
            string body, int postId)
        {
            Logger.Information(
                "Start '{@Method}' with body as '{@body}' and post id as '{@postId}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                body,
                postId);

            var restResponse = await ExecutePatchAsync(
                $"/posts/{postId}",
                new JsonPlaceholderPatch
                {
                    Body = body,
                });

            Logger.Information(
                "Finished '{@Method}' with body as '{@body}' and post id as '{@postId}' with result of '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse,
                body,
                postId);

            var responseModel = new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
            return responseModel;
        }

        public async Task<ResponseMessage> DeleteJsonPlaceholderResponseAsync(string postId)
        {
            Logger.Information(
                "Start '{@Method}' with '{@postId}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                postId);

            var restResponse = await ExecuteDeleteAsync($"/posts/{postId}");

            Logger.Information(
                "Finished '{@Method}' with '{@restResponse}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            var responseModel = new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
            return responseModel;
        }
    }
}
