using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Pet
{
    public interface IPetContext
    {
        Task<PetResponse> GetPetByIdAsync(int petId);

        Task<ResponseMessage> GetPetByIdResponseAsync(string petId);

        Task<ResponseMessage> CreatePetResponseAsync(PetRequest petRequest);

        Task<CreatePetResponse> CreatePetAsync(PetRequest petRequest);
    }
}
