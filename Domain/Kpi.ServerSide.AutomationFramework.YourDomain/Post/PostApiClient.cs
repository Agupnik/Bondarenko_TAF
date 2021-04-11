using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Post;
using Kpi.ServerSide.AutomationFramework.Model.Platform.Communication;
using Kpi.ServerSide.AutomationFramework.Platform.Client;
using Kpi.ServerSide.AutomationFramework.Platform.Communication.Http;
using Kpi.ServerSide.AutomationFramework.Platform.Configuration.Environment;
using RestSharp;
using Serilog;

namespace Kpi.ServerSide.AutomationFramework.jsonplaceholder.typicode.com.Post
{
    public class PostApiClient : ApiClientBase, IPostApiClient
    {
        public PostApiClient(
            IClient client, 
            ILogger logger, 
            IEnvironmentConfiguration environmentConfiguration) 
            : base(client, logger)
        {
            client.SetBaseUri(environmentConfiguration.EnvironmentUri);
        }

        public async Task<PostResponse> GetPostByIdAsync(int postId)
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

            var model = restResponse.GetModel<PostResponse>();
            return model;
        }

        public async Task<ResponseMessage> GetPostByIdResponseAsync(string postId)
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

        public async Task<PostResponse> CreatePostAsync(
            PostCreate postCreate)
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

            return restResponse.GetModel<PostResponse>();
        }

        public async Task<ResponseMessage> CreatePostResponseAsync(
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
                new PostCreate
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

        public async Task<PostResponse> PutPostAsync(
            PostResponse postResponse, int postId)
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

            return restResponse.GetModel<PostResponse>();
        }

        public async Task<ResponseMessage> PutPostResponseAsync(
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
                new PostResponse
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

        public async Task<PostResponse> PatchPostBodyAsync(
            PostPatch postPatch, int postId)
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

            return restResponse.GetModel<PostResponse>();
        }

        public async Task<ResponseMessage> PatchPostResponseAsync(
            string body, int postId)
        {
            Logger.Information(
                "Start '{@Method}' with body as '{@body}' and post id as '{@postId}'",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                body,
                postId);

            var restResponse = await ExecutePatchAsync(
                $"/posts/{postId}",
                new PostPatch
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

        public async Task<ResponseMessage> DeletePostResponseAsync(string postId)
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
