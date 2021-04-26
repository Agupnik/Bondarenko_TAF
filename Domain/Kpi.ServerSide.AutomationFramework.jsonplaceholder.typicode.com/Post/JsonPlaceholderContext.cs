using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder;

namespace Kpi.ServerSide.AutomationFramework.JsonPlaceholder.Post
{
    public class JsonPlaceholderContext : IJsonPlaceholderContext
    {
        private readonly IJsonPlaceholderApiClient _jsonPlaceholderApiClient;

        public JsonPlaceholderContext(
            IJsonPlaceholderApiClient postApiClient)
        {
            _jsonPlaceholderApiClient = postApiClient;
        }

        public async Task<JsonPlaceholderResponse> CreateJsonPlaceholderAsync(
            JsonPlaceholderPost postCreate)
        {
            return await _jsonPlaceholderApiClient.CreateJsonPlaceholderAsync(postCreate);
        }

        public async Task<ResponseMessage> CreateJsonPlaceholderResponseAsync(
            int userid, string title, string body)
        {
            return await _jsonPlaceholderApiClient.CreateJsonPlaceholderResponseAsync(userid, title, body);
        }

        public async Task<ResponseMessage> DeleteJsonPlaceholderResponseAsync(
            string postId)
        {
            return await _jsonPlaceholderApiClient.DeleteJsonPlaceholderResponseAsync(postId);
        }

        public async Task<JsonPlaceholderResponse> GetJsonPlaceholderByIdAsync(
            int postId)
        {
            return await _jsonPlaceholderApiClient.GetJsonPlaceholderByIdAsync(postId);
        }

        public async Task<ResponseMessage> GetJsonPlaceholderByIdResponseAsync(
            string postId)
        {
            return await _jsonPlaceholderApiClient.GetJsonPlaceholderByIdResponseAsync(postId);
        }

        public async Task<JsonPlaceholderResponse> PatchJsonPlaceholderBodyAsync(JsonPlaceholderPatch postPatch, int postId)
        {
            return await _jsonPlaceholderApiClient.PatchJsonPlaceholderBodyAsync(postPatch, postId);
        }

        public async Task<ResponseMessage> PatchJsonPlaceholderResponseAsync(string body, int postId)
        {
            return await _jsonPlaceholderApiClient.PatchJsonPlaceholderResponseAsync(body, postId);
        }

        public async Task<JsonPlaceholderResponse> PutJsonPlaceholderAsync(JsonPlaceholderResponse postResponse, int postId)
        {
            return await _jsonPlaceholderApiClient.PutJsonPlaceholderAsync(postResponse, postId);
        }

        public async Task<ResponseMessage> PutJsonPlaceholderResponseAsync(int userid, string title, string body, int postId)
        {
            return await _jsonPlaceholderApiClient.PutJsonPlaceholderResponseAsync(userid, title, body, postId);
        }
    }
}
