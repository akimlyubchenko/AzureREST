using System.Collections.Generic;
using System.Threading.Tasks;
using RESTAPI.DAL.Interfaces.Models;

namespace RESTAPI.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<UserDBModel>> GetAllUsersAsync();

        Task<ICollection<AddressDBModel>> GetAllAddressAsync(string login);

        Task<AddressDBModel> GetAddressOfUserAsync(string login);

        Task<UserDBModel> CreateUserAsync(UserDBModel user);

        Task<UserDBModel> UpdateUserAsync(UserDBModel user);

        Task<string> UpdateLastNameAsync(string login, string lastName);

        Task<AddressDBModel> UpdateUserAddressAsync(string street, int building, int room, AddressDBModel address);

        Task<AddressDBModel> AddAddressAsync(AddressDBModel address);

    }
}