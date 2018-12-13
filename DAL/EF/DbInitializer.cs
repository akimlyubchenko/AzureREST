using System;
using System.Collections.Generic;
using System.Data.Entity;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.DAL.EF
{
    public class DbInitializer : CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var Akim = new UserDBModel()
            {
                FirstName = "Akim",
                LastName = "Liubchenka",
                Login = "Akim",
                Password = "qwerty",
                DateOfBirth = DateTime.Now,
            };

            var Oleg = new UserDBModel()
            {
                FirstName = "Oleg",
                LastName = "Liubchenka",
                Login = "Oleg",
                Password = "qwerty12345",
                DateOfBirth = DateTime.Now,
            };

            Akim.Addresses = new List<AddressDBModel>();
            var akimsWorkAddress = new AddressDBModel
            {
                AddressType = AddressType.WorkAddress,
                Country = "Belarus",
                City = "Minsk",
                Street = "Kuprevicha",
                Building = 1,
                Room = 113,
                UserDBModel = Akim,
                UserDbModelId = Akim.Login
            };

            Akim.Addresses.Add(akimsWorkAddress);

            var akimsHomeAddress = new AddressDBModel
            {
                AddressType = AddressType.HomeAddress,
                Country = "Belarus",
                City = "Minsk",
                Street = "Geroev 120 div",
                Building = 17,
                Room = 118,
                UserDBModel = Akim,
                UserDbModelId = Akim.Login
            };

            Akim.Addresses.Add(akimsHomeAddress);


            Oleg.Addresses = new List<AddressDBModel>();

            var olegsWorkAddress = new AddressDBModel
            {
                AddressType = AddressType.WorkAddress,
                Country = "Belarus",
                City = "Minsk",
                Street = "Zhukova",
                Building = 21,
                Room = 12,
                UserDBModel = Oleg,
                UserDbModelId = Oleg.Login
            };

            Oleg.Addresses.Add(olegsWorkAddress);

            var olegsHomeAddress = new AddressDBModel
            {
                AddressType = AddressType.HomeAddress,
                Country = "Belarus",
                City = "Minsk",
                Street = "Kedishko",
                Building = 32,
                Room = 324,
                UserDBModel = Oleg,
                UserDbModelId = Oleg.Login
            };

            Oleg.Addresses.Add(olegsHomeAddress);


            context.Users.Add(Akim);
            context.Users.Add(Oleg);
            context.Addresses.Add(akimsHomeAddress);
            context.Addresses.Add(akimsWorkAddress);
            context.Addresses.Add(olegsHomeAddress);
            context.Addresses.Add(olegsWorkAddress);

            base.Seed(context);
        }
    }
}