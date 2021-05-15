using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.PetStore
{
    public class PetStoreContext : IPetStoreContext
    {
        private readonly IPetStoreApiClient _petStoreApiClient;

        public PetStoreContext(
            IPetStoreApiClient petStoreApiClient)
        {
            _petStoreApiClient = petStoreApiClient;
        }

        public async Task<ResponseMessage> CreateUserResponseAsync(
            UserRequest userRequest)
        {
            return await _petStoreApiClient.CreateUserResponseAsync(userRequest);
        }

        public async Task<ResponseMessage> DeleteUserResponseAsync(
            string userName)
        {
            return await _petStoreApiClient.DeleteUserResponseAsync(userName);
        }

        public async Task<UserResponse> GetUserByNameAsync(
            string userName)
        {
            return await _petStoreApiClient.GetUserByNameAsync(userName);
        }

        public async Task<ResponseMessage> GetUserByNameResponseAsync(
            string userName)
        {
            return await _petStoreApiClient.GetUserByNameResponseAsync(userName);
        }

        public async Task<ResponseMessage> UpdateUserResponseAsync(
            string userName, 
            UserRequest userRequest)
        {
            return await _petStoreApiClient.UpdateUserResponseAsync(userName, userRequest);
        }
    }
}
