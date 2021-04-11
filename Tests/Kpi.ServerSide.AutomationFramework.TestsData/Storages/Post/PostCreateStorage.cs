using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Post;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post
{
    public static class PostCreateStorage
    {
        public static Dictionary<string, PostCreate> PostCreated =>
            new Dictionary<string, PostCreate>
            {
                {
                    "Default", Default
                }
            };

        private static PostCreate Default =>
            new Faker<PostCreate>()
                .RuleFor(u => u.Body, "Is anyone home?")
                .RuleFor(u => u.Title, "Hello!")
                .RuleFor(u => u.UserId, 1);
    }
}
