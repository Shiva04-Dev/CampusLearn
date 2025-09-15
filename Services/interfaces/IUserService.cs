using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> RegisterUserAsync(User user, string password);
        Task<bool> LoginAsync(string email, string password);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    }
}