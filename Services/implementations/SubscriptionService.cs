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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly CampusLearnContext _context;

        public SubscriptionService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<Subscription> GetSubscriptionAsync(int studentId, int topicId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Subscriptions
                .Include(s => s.Student)
                .Include(s => s.Topic)
                .FirstOrDefaultAsync(s => s.StudentID == studentId && s.TopicID == topicId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByStudentAsync(int studentId)
        {
            return await _context.Subscriptions
                .Where(s => s.StudentID == studentId)
                .Include(s => s.Topic)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByTopicAsync(int topicId)
        {
            return await _context.Subscriptions
                .Where(s => s.TopicID == topicId)
                .Include(s => s.Student)
                .ToListAsync();
        }

        public async Task<bool> CreateSubscriptionAsync(Subscription subscription)
        {
            try
            {
                _context.Subscriptions.Add(subscription);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSubscriptionAsync(int studentId, int topicId)
        {
            try
            {
                var subscription = await GetSubscriptionAsync(studentId, topicId);
                if (subscription == null) return false;

                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> IsSubscribedAsync(int studentId, int topicId)
        {
            return await _context.Subscriptions
                .AnyAsync(s => s.StudentID == studentId && s.TopicID == topicId);
        }

        public async Task<int> GetSubscriptionCountAsync(int topicId)
        {
            return await _context.Subscriptions
                .CountAsync(s => s.TopicID == topicId);
        }

        // Helper method to get subscriptions with module information using joins
        public async Task<IEnumerable<object>> GetSubscriptionsWithModuleInfoAsync(int studentId)
        {
            return await _context.Subscriptions
                .Where(s => s.StudentID == studentId)
                .Join(_context.Topics, s => s.TopicID, t => t.TopicID, (s, t) => new { s, t })
                .Join(_context.Modules, st => st.t.ModuleID, m => m.ModuleID, (st, m) => new
                {
                    Subscription = st.s,
                    Topic = st.t,
                    Module = m
                })
                .ToListAsync();
        }
    }
}