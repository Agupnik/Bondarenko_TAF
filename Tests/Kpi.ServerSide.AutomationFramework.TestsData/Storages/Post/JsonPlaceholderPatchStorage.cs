using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post
{
    public static class JsonPlaceholderPatchStorage
    {
        public static Dictionary<string, JsonPlaceholderPatch> JsonPlaceholderPatchBodies =>
            new Dictionary<string, JsonPlaceholderPatch>
            {
                {
                    "Default", Default
                }
            };

        private static JsonPlaceholderPatch Default =>
            new Faker<JsonPlaceholderPatch>()
                .RuleFor(u => u.Body, "Is anyone home?");
    }
}
