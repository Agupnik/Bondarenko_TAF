using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post
{
    public static class JsonPlaceholderPostStorage
    {
        public static Dictionary<string, JsonPlaceholderPost> JsonPlaceholderPosts =>
            new Dictionary<string, JsonPlaceholderPost>
            {
                {
                    "Default", Default
                }
            };

        private static JsonPlaceholderPost Default =>
            new Faker<JsonPlaceholderPost>()
                .RuleFor(u => u.Body, "Is anyone home?")
                .RuleFor(u => u.Title, "Hello!")
                .RuleFor(u => u.UserId, 1);
    }
}
