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
    public class UserService : IUserService
    {
        private readonly CampusLearnContext _context;

        public UserService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Users.FindAsync(userId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> RegisterUserAsync(User user, string password)
        {
            try
            {
                user.Register(user.Username, user.Email, password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null && user.Login(email, password);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                var user = await GetUserByIdAsync(userId);
                if (user == null) return false;

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await GetUserByIdAsync(userId);
            if (user == null || !user.Login(user.Email, currentPassword)) return false;

            user.PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(newPassword));
            await _context.SaveChangesAsync();
            return true;
        }
    }
}