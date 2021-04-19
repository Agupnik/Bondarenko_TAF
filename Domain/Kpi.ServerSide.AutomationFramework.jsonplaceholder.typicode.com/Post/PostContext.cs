using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Post;

namespace Kpi.ServerSide.AutomationFramework.jsonplaceholder.typicode.com.Post
{
    public class PostContext : IPostContext
    {
        private readonly IPostApiClient _postApiClient;

        public PostContext(
            IPostApiClient postApiClient)
        {
            _postApiClient = postApiClient;
        }

        public async Task<PostResponse> CreatePostAsync(
            PostCreate postCreate)
        {
            return await _postApiClient.CreatePostAsync(postCreate);
        }

        public async Task<ResponseMessage> CreatePostResponseAsync(
            int userid, string title, string body)
        {
            return await _postApiClient.CreatePostResponseAsync(userid, title, body);
        }

        public async Task<ResponseMessage> DeletePostResponseAsync(
            string postId)
        {
            return await _postApiClient.DeletePostResponseAsync(postId);
        }

        public async Task<PostResponse> GetPostByIdAsync(
            int postId)
        {
            return await _postApiClient.GetPostByIdAsync(postId);
        }

        public async Task<ResponseMessage> GetPostByIdResponseAsync(
            string postId)
        {
            return await _postApiClient.GetPostByIdResponseAsync(postId);
        }

        public async Task<PostResponse> PatchPostBodyAsync(PostPatch postPatch, int postId)
        {
            return await _postApiClient.PatchPostBodyAsync(postPatch, postId);
        }

        public async Task<ResponseMessage> PatchPostResponseAsync(string body, int postId)
        {
            return await _postApiClient.PatchPostResponseAsync(body, postId);
        }

        public async Task<PostResponse> PutPostAsync(PostResponse postResponse, int postId)
        {
            return await _postApiClient.PutPostAsync(postResponse, postId);
        }

        public async Task<ResponseMessage> PutPostResponseAsync(int userid, string title, string body, int postId)
        {
            return await _postApiClient.PutPostResponseAsync(userid, title, body, postId);
        }
    }
}
