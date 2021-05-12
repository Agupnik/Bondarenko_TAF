using System.Reflection;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.Model.Platform.Communication;
using Kpi.ServerSide.AutomationFramework.Platform.Client;
using Kpi.ServerSide.AutomationFramework.Platform.Communication.Http;
using Kpi.ServerSide.AutomationFramework.Platform.Configuration.Environment;
using Serilog;

namespace Kpi.ServerSide.AutomationFramework.YourDomain.Pet
{
    public class PetApiClient : ApiClientBase, IPetApiClient
    {
        public PetApiClient (
            IClient client,
            ILogger logger,
            IEnvironmentConfiguration environmentConfiguration)
            : base(client, logger)
        {
            client.SetBaseUri(environmentConfiguration.EnvironmentUri);
        }

        public async Task<PetResponse> GetPetByIdAsync(
            int petId)
        {
            var restResponse = await ExecuteGetAsync(
                $"/v2/pet/{petId}");

            return restResponse.GetModel<PetResponse>();
        }

        public async Task<ResponseMessage> GetPetByIdResponseAsync(
            string petId)
        {
            Logger.Information(
                "Start '{@Method}' with {@petId}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petId);

            var restResponse = await ExecuteGetAsync(
                $"/v2/pet/{petId}");

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

        public async Task<ResponseMessage> CreatePetResponseAsync(
            PetRequest petRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@petRequest}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petRequest);

            var restResponse = await ExecutePostAsync(
                "/v2/pet",
                petRequest);

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

        public async Task<CreatePetResponse> CreatePetAsync(
            PetRequest petRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@petRequest}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                petRequest);

            var restResponse = await ExecutePostAsync(
                "/v2/pet",
                petRequest);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);
            return restResponse.GetModel<CreatePetResponse>();
        }
    }
}
