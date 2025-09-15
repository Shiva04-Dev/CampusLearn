using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Admin> GetAdminByIdAsync(int adminId);
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<bool> CreateAdminAsync(Admin admin);
        Task<bool> UpdateAdminAsync(Admin admin);
        Task<bool> DeleteAdminAsync(int adminId);
        Task<bool> ManageUserAsync(int adminId, int userId, string action);
        Task<bool> ModerateContentAsync(int adminId, int postId);
        Task<IEnumerable<User>> GetAllUsersForManagementAsync();
        Task<IEnumerable<Post>> GetFlaggedContentAsync();
    }
}