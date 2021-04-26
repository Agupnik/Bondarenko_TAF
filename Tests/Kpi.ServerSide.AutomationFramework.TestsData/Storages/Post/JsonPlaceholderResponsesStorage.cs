﻿using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.JsonPlaceholder;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Post
{
    public static class JsonPlaceholderResponsesStorage
    {
        public static Dictionary<string, JsonPlaceholderResponse> JsonPlaceholderResponses =>
            new Dictionary<string, JsonPlaceholderResponse>
            {
                {
                    "Default", Default
                },
                {
                    "JsonPlaceholderToPut", JsonPlaceholderToPut
                }
            };

        private static JsonPlaceholderResponse Default =>
            new Faker<JsonPlaceholderResponse>()
                .RuleFor(u => u.Id, 1)
                .RuleFor(u => u.Body, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto")
                .RuleFor(u => u.Title, "sunt aut facere repellat provident occaecati excepturi optio reprehenderit")
                .RuleFor(u => u.UserId, 1);

        private static JsonPlaceholderResponse JsonPlaceholderToPut =>
            new Faker<JsonPlaceholderResponse>()
                .RuleFor(u => u.Id, 1)
                .RuleFor(u => u.Body, "Is anyone home?")
                .RuleFor(u => u.Title, "Hello!")
                .RuleFor(u => u.UserId, 1);
    }
}
