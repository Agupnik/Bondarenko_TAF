using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.YourDomain.Pet
{
    public class PetContext : IPetContext
    {
        private readonly IPetApiClient _petApiClient;

        public PetContext(
            IPetApiClient petApiClient)
        {
            _petApiClient = petApiClient;
        }

        public async Task<PetResponse> GetPetByIdAsync(
            int petId)
        {
            return await _petApiClient.GetPetByIdAsync(petId);
        }

        public async Task<ResponseMessage> GetPetByIdResponseAsync(
            string petId)
        {
            return await _petApiClient.GetPetByIdResponseAsync(petId);
        }

        public async Task<ResponseMessage> CreatePetResponseAsync(
            PetRequest petRequest)
        {
            return await _petApiClient.CreatePetResponseAsync(petRequest);
        }
        
        public async Task<CreatePetResponse> CreatePetAsync(
            PetRequest petRequest)
        {
            return await _petApiClient.CreatePetAsync(petRequest);
        }
    }
}
