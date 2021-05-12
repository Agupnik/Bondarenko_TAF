using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Post pet")]
    public class PostPetDefinition
    {
        private readonly IPetContext _petContext;
        private ResponseMessage _responseMessage;
        private CreatePetResponse _createdPet;

        public PostPetDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I send the pet creation request with empty model")]
        public async Task WhenISendThePetCreationRequestWithEmptyModel()
        {
            _createdPet = await _petContext.CreatePetAsync(
                new PetRequest());
        }
        
        [When(@"I send the pet creation request with null model")]
        public async Task WhenISendThePetCreationRequestWithNullModel()
        {
            _responseMessage = await _petContext.CreatePetResponseAsync(
                null);
        }

        [Then(@"I see '(.*)' status code request")]
        public void ThenISeeStatusCodeRequest(string expectedStatusCode)
        {
            _responseMessage.StatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"I see created pet in the get response")]
        public async Task ThenISeeCreatedPet()
        {
            var actualGetResponse = await _petContext.GetPetByIdResponseAsync(
                _createdPet.Id.ToString());
            actualGetResponse.Content.Should().NotBeNullOrEmpty();
        }
    }
}
