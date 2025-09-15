using CampusLearn.Data;
using CampusLearn.Models;
using CampusLearn.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  CampusLearn.Models.Enums;

namespace CampusLearn.Services.Implementations
{
    public class TopicService : ITopicService
    {
        private readonly CampusLearnContext _context;

        public TopicService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<Topic> GetTopicByIdAsync(int topicId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Topics
                .FirstOrDefaultAsync(t => t.TopicID == topicId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByModuleAsync(int moduleId)
        {
            return await _context.Topics
                .Where(t => t.ModuleID == moduleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByStatusAsync(Status status)
        {
            return await _context.Topics
                .Where(t => (int)t.Status == (int)status)
                .ToListAsync();
        }

        public async Task<bool> CreateTopicAsync(Topic topic)
        {
            try
            {
                _context.Topics.Add(topic);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTopicAsync(Topic topic)
        {
            try
            {
                _context.Topics.Update(topic);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTopicAsync(int topicId)
        {
            try
            {
                var topic = await GetTopicByIdAsync(topicId);
                if (topic == null) return false;

                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CloseTopicAsync(int topicId)
        {
            var topic = await GetTopicByIdAsync(topicId);
            if (topic == null) return false;

            topic.CloseTopic();
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TutorResponse>> GetTopicResponsesAsync(int topicId)
        {
            return await _context.TutorTopicResponses
                .Where(r => r.TopicID == topicId)
                .OrderByDescending(r => r.ResponseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Resource>> GetTopicResourcesAsync(int topicId)
        {
            return await _context.LearningMaterials
                .Where(r => r.TopicID == topicId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetTopicSubscribersAsync(int topicId)
        {
            return await _context.Subscriptions
                .Where(s => s.TopicID == topicId)
                .Join(_context.Students, s => s.StudentID, st => st.StudentID, (s, st) => st)
                .ToListAsync();
        }

        public async Task<int> GetTopicSubscriptionCountAsync(int topicId)
        {
            return await _context.Subscriptions
                .CountAsync(s => s.TopicID == topicId);
        }

        // Helper methods to get related data using foreign key relationships
        public async Task<Student> GetTopicCreatorAsync(int topicId)
        {
            var topic = await _context.Topics.FindAsync(topicId);
#pragma warning disable CS8603 // Possible null reference return.
            if (topic == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Students.FindAsync(topic.StudentID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Module> GetTopicModuleAsync(int topicId)
        {
            var topic = await _context.Topics.FindAsync(topicId);
#pragma warning disable CS8603 // Possible null reference return.
            if (topic == null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Modules.FindAsync(topic.ModuleID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<object>> GetTopicsWithDetailsAsync(int moduleId)
        {
            return await _context.Topics
                .Where(t => t.ModuleID == moduleId)
                .Join(_context.Students, t => t.StudentID, s => s.StudentID, (t, s) => new { Topic = t, Student = s })
                .Join(_context.Modules, ts => ts.Topic.ModuleID, m => m.ModuleID, (ts, m) => new
                {
                    Topic = ts.Topic,
                    Student = ts.Student,
                    Module = m
                })
                .ToListAsync();
        }
    }
}