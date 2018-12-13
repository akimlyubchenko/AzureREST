using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RESTAPI.DAL.EF;
using RESTAPI.DAL.Interfaces;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<ICollection<AddressDBModel>> GetAllAddressAsync(string login)
            => await _context.Addresses.Where(user => user.UserDbModelId == login).ToArrayAsync();

        public async Task<AddressDBModel> GetAddressOfUserAsync(string login)
            => await _context.Addresses.FirstAsync(
                address => address.UserDbModelId == login && address.AddressType == AddressType.HomeAddress);

        public async Task<ICollection<UserDBModel>> GetAllUsersAsync()
            => await _context.Users.ToArrayAsync();

        public async Task<UserDBModel> CreateUserAsync(UserDBModel user)
        {
            var availabilityCheck = await _context.Users.Where(newUser => newUser.Login == user.Login).ToArrayAsync();
            if (availabilityCheck.Length > 0)
            {
                throw new HttpRequestException($"User {user.FirstName} {user.LastName} already created");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserDBModel> UpdateUserAsync(UserDBModel user)
        {
            var oldUser = await _context.Users.SingleAsync(newUser => newUser.Login == user.Login);

            oldUser.DateOfBirth = user.DateOfBirth;
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            oldUser.Password = user.Password;

            await _context.SaveChangesAsync();

            return oldUser;
        }

        public async Task<string> UpdateLastNameAsync(string login, string lastName)
        {
            var user = await _context.Users.SingleAsync(currentUser => currentUser.Login == login);

            user.LastName = lastName;

            await _context.SaveChangesAsync();

            return user.LastName;
        }

        public async Task<AddressDBModel> UpdateUserAddressAsync(string street, int building, int room, AddressDBModel address)
        {
            var newAddress = await _context.Addresses.SingleAsync( currentAddress => 
                currentAddress.UserDbModelId == address.UserDbModelId &&
                currentAddress.Building == building &&
                currentAddress.Room == room &&
                currentAddress.Street == street);

            newAddress.AddressType = address.AddressType;
            newAddress.Building = address.Building;
            newAddress.City = address.City;
            newAddress.Country = address.Country;
            newAddress.Room = address.Room;
            newAddress.Street = address.Street;

            await _context.SaveChangesAsync();

            return newAddress;
        }

        public async Task<AddressDBModel> AddAddressAsync(AddressDBModel address)
        {
            var user = await _context.Users.SingleAsync(curUser => curUser.Login == address.UserDbModelId);
            address.UserDBModel = user;
           

            _context.Addresses.Add(address);

            user.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }
    }
}
