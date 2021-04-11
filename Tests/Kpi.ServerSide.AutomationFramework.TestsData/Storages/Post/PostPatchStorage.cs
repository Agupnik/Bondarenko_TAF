using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Post;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post
{
    public static class PostPatchStorage
    {
        public static Dictionary<string, PostPatch> PostPatchBodies =>
            new Dictionary<string, PostPatch>
            {
                {
                    "Default", Default
                }
            };

        private static PostPatch Default =>
            new Faker<PostPatch>()
                .RuleFor(u => u.Body, "Is anyone home?");
    }
}
