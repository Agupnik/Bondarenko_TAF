using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Post
{
    public interface IPostContext
    {
        Task<PostResponse> GetPostByIdAsync(int postId);

        Task<ResponseMessage> GetPostByIdResponseAsync(string postId);

        Task<PostResponse> CreatePostAsync(PostCreate postCreate);

        Task<ResponseMessage> CreatePostResponseAsync(int userid, string title, string body);

        Task<PostResponse> PutPostAsync(PostResponse postResponse, int postId);

        Task<ResponseMessage> PutPostResponseAsync(int userid, string title, string body, int postId);

        Task<PostResponse> PatchPostBodyAsync(PostPatch postPatch, int postId);

        Task<ResponseMessage> PatchPostResponseAsync(string body, int postId);

        Task<ResponseMessage> DeletePostResponseAsync(string postId);
    }
}
