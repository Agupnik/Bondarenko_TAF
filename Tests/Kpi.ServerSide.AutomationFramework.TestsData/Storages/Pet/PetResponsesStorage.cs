using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet
{
    public static class PetResponsesStorage
    {
        public static Dictionary<string, PetResponse> PetResponses =>
            new Dictionary<string, PetResponse>
            {
                { "Default", Default }
            };

        private static PetResponse Default =>
        new Faker<PetResponse>()
            .RuleFor(u => u.Id, 1)
            .RuleFor(u => u.Category, PetCategoriesStorage.DefaultCategory)
            .RuleFor(u => u.Name, "doggie")
            .RuleFor(u => u.Status, "available")
            .RuleFor(u => u.PhotoUrls, value: new[] { "yahoo" })
            .RuleFor(u => u.Tags, new[] { PetTagsStorage.Default });
    }
}
