using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTAPI.DAL.Interfaces;
using RESTAPI.DAL.Interfaces.Models;
using RESTAPI.Services.Interfaces;
using RESTAPI.Services.Interfaces.Model;

namespace RESTAPI.Services.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            var dbUsers = await _repository.GetAllUsersAsync();

            var users = new Collection<User>();

            foreach (var dbUser in dbUsers)
            {
                var user = new User
                {
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth,
                    Login = dbUser.Login,
                    Password = dbUser.Password,
                    Address = await GetAddressOfUserAsync(dbUser.Login)
                };

                users.Add(user);
            }

            return users;
        }

        public async Task<Address> GetAddressOfUserAsync(string login)
        {
            var dbAddress = await _repository.GetAddressOfUserAsync(login);

            return new Address
            {
                AddressType = dbAddress.AddressType.ToString(),
                Country = dbAddress.Country,
                City = dbAddress.City,
                Street = dbAddress.Street,
                Building = dbAddress.Building,
                Room = dbAddress.Room
            };
        }


        public async Task<ICollection<Address>> GetAllAddressAsync(string login)
        {
            var dbAddresses = await _repository.GetAllAddressAsync(login);
            if (dbAddresses.Count < 1)
            {
                throw new ArgumentException($"Addresses with login {login} doesn't exist");
            }

            var addresses = new Collection<Address>();
            foreach (var dbAddress in dbAddresses)
            {
                addresses.Add(new Address
                {
                    AddressType = dbAddress.AddressType.ToString(),
                    Country = dbAddress.Country,
                    City = dbAddress.City,
                    Street = dbAddress.Street,
                    Building = dbAddress.Building,
                    Room = dbAddress.Room
                });
            }

            return addresses;
        }

        public async Task<User> CreateUserAsync(User user, Address address)
        {
            var dbUser = new UserDBModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth
            };

            await _repository.CreateUserAsync(dbUser);
            await AddAddressAsync(user.Login, address);
            return user;
        }

        public async Task<User> UpdateUserAsync(string login, UserToUpdate user)
        {
            var dbUser = await _repository.UpdateUserAsync(new UserDBModel
            {
                Login = login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth
            });

            return new User
            {
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Login = dbUser.Password,
                DateOfBirth = dbUser.DateOfBirth,
                Address = await GetAddressOfUserAsync(dbUser.Login)
            };
        }

        public async Task<string> UpdateLastNameAsync(string login, string lastName)
        {
            var newLastName = await _repository.UpdateLastNameAsync(login, lastName);

            return newLastName;
        }

        public async Task<Address> UpdateUserAddressAsync(string login, string street, int building, int room, Address newAddress)
        {
            var dbAddress = await _repository.UpdateUserAddressAsync(street, building, room,
                new AddressDBModel
                {
                    AddressType = (AddressType)Enum.Parse(typeof(AddressType), newAddress.AddressType),
                    UserDbModelId = login,
                    Country = newAddress.Country,
                    City = newAddress.City,
                    Street = newAddress.Street,
                    Building = newAddress.Building,
                    Room = newAddress.Room
                });

            return new Address
            {
                AddressType = dbAddress.AddressType.ToString(),
                Country = dbAddress.Country,
                City = dbAddress.City,
                Street = dbAddress.Street,
                Building = dbAddress.Building,
                Room = dbAddress.Room
            };
        }

        public async Task<Address> AddAddressAsync(string login, Address address)
        {
            var dbAddress = await _repository.AddAddressAsync(new AddressDBModel
            {
                UserDbModelId = login,
                AddressType = (AddressType)Enum.Parse(typeof(AddressType), address.AddressType),
                Country = address.Country,
                City = address.City,
                Street = address.Street,
                Building = address.Building,
                Room = address.Room
            });

            return new Address
            {
                AddressType = dbAddress.AddressType.ToString(),
                Country = dbAddress.Country,
                City = dbAddress.City,
                Street = dbAddress.Street,
                Building = dbAddress.Building,
                Room = dbAddress.Room
            };
        }
    }
}
