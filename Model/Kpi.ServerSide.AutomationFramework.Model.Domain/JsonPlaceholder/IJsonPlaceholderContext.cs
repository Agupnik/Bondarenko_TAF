using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder
{
    public interface IJsonPlaceholderContext
    {
        Task<JsonPlaceholderResponse> GetJsonPlaceholderByIdAsync(int postId);

        Task<ResponseMessage> GetJsonPlaceholderByIdResponseAsync(string postId);

        Task<JsonPlaceholderResponse> CreateJsonPlaceholderAsync(JsonPlaceholderPost postCreate);

        Task<ResponseMessage> CreateJsonPlaceholderResponseAsync(int userid, string title, string body);

        Task<JsonPlaceholderResponse> PutJsonPlaceholderAsync(JsonPlaceholderResponse postResponse, int postId);

        Task<ResponseMessage> PutJsonPlaceholderResponseAsync(int userid, string title, string body, int postId);

        Task<JsonPlaceholderResponse> PatchJsonPlaceholderBodyAsync(JsonPlaceholderPatch postPatch, int postId);

        Task<ResponseMessage> PatchJsonPlaceholderResponseAsync(string body, int postId);

        Task<ResponseMessage> DeleteJsonPlaceholderResponseAsync(string postId);
    }
}
