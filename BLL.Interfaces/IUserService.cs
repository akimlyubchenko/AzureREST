using System.Collections.Generic;
using System.Threading.Tasks;
using RESTAPI.Services.Interfaces.Model;

namespace RESTAPI.Services.Interfaces
{
    public interface IUserService
    { 
        Task<ICollection<Address>> GetAllAddressAsync(string login);

        Task<ICollection<User>> GetAllUsersAsync();

        Task<Address> GetAddressOfUserAsync(string login);

        Task<User> CreateUserAsync(User user, Address address);

        Task<User> UpdateUserAsync(string login, UserToUpdate user);

        Task<string> UpdateLastNameAsync(string login, string lastName);

        Task<Address> UpdateUserAddressAsync(string login, string street, int building, int room, Address newAddress);

        Task<Address> AddAddressAsync(string login, Address address);
    }
}