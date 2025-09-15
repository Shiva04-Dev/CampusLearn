using CampusLearn.Data;
using CampusLearn.Models;
using CampusLearn.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLearn.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly CampusLearnContext _context;

        public AdminService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetAdminByIdAsync(int adminId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Admins.FindAsync(adminId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<bool> CreateAdminAsync(Admin admin)
        {
            try
            {
                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAdminAsync(Admin admin)
        {
            try
            {
                _context.Admins.Update(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAdminAsync(int adminId)
        {
            try
            {
                var admin = await GetAdminByIdAsync(adminId);
                if (admin == null) return false;

                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ManageUserAsync(int adminId, int userId, string action)
        {
            var admin = await GetAdminByIdAsync(adminId);
            var user = await _context.Users.FindAsync(userId); 

            if (admin == null || user == null) return false;

            try
            {
                admin.ManageUser(user, action);
                await _context.SaveChangesAsync(); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ModerateContentAsync(int adminId, int postId)
        {
            var admin = await GetAdminByIdAsync(adminId);
            var post = await _context.ForumPosts.FindAsync(postId); 

            if (admin == null || post == null) return false;

            admin.ModerateContent(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersForManagementAsync()
        {
            return await _context.Users.ToListAsync(); 
        }

        public async Task<IEnumerable<Post>> GetFlaggedContentAsync()
        {
            return await _context.ForumPosts 
                .Where(p => p.IsFlagged)
                .Include(p => p.Student)
                .Include(p => p.Topic)
                .ToListAsync();
        }
    }
}