using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Generators;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.User
{
    public static class UserStorage
    {
        public static Dictionary<string, UserRequest> UserRequests =>
            new Dictionary<string, UserRequest>
            {
                { "Default", Default },
                { "NewUserInfo", NewUserInfo }
            };

        private static UserRequest Default =>
            new Faker<UserRequest>()
                .RuleFor(u => u.Id, 0)
                .RuleFor(u => u.Email, RandomGenerator.NewEmail)
                .RuleFor(u => u.FirstName, RandomGenerator.RandomString())
                .RuleFor(u => u.LastName, RandomGenerator.RandomString())
                .RuleFor(u => u.Password, RandomGenerator.RandomString())
                .RuleFor(u => u.Username, RandomGenerator.RandomString())
                .RuleFor(u => u.UserStatus, 0)
                .RuleFor(u => u.Phone, RandomGenerator.RandomString());

        private static UserRequest NewUserInfo =>
            new Faker<UserRequest>()
                .RuleFor(u => u.Id, 0)
                .RuleFor(u => u.Email, RandomGenerator.NewEmail)
                .RuleFor(u => u.FirstName, RandomGenerator.RandomString())
                .RuleFor(u => u.LastName, RandomGenerator.RandomString())
                .RuleFor(u => u.Password, RandomGenerator.RandomString())
                .RuleFor(u => u.Username, RandomGenerator.RandomString())
                .RuleFor(u => u.UserStatus, 0)
                .RuleFor(u => u.Phone, RandomGenerator.RandomString());
    }
}
