using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

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
                .RuleFor(u => u.Email, "ExampleEmail@gmail.ru")
                .RuleFor(u => u.FirstName, "FirstName")
                .RuleFor(u => u.LastName, "LastName")
                .RuleFor(u => u.Password, "VeryGoodPassword12!45")
                .RuleFor(u => u.Username, "BassWonderWoman")
                .RuleFor(u => u.UserStatus, 0)
                .RuleFor(u => u.Phone, "0969535582");

        private static UserRequest NewUserInfo =>
            new Faker<UserRequest>()
                .RuleFor(u => u.Id, 16)
                .RuleFor(u => u.Email, "NewEmail@gmail.ru")
                .RuleFor(u => u.FirstName, "FirstName2")
                .RuleFor(u => u.LastName, "LastName2")
                .RuleFor(u => u.Password, "VeryGoodNewPassword12!")
                .RuleFor(u => u.Username, "BrassMan")
                .RuleFor(u => u.UserStatus, 0)
                .RuleFor(u => u.Phone, "0969512582");
    }
}
