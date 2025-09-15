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
    public class StudentService : IStudentService
    {
        private readonly CampusLearnContext _context;

        public StudentService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Students
                .FirstOrDefaultAsync(s => s.StudentID == studentId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            try
            {
                var student = await GetStudentByIdAsync(studentId);
                if (student == null) return false;

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Topic> CreateTopicAsync(int studentId, string title, string description, int moduleId)
        {
            var student = await GetStudentByIdAsync(studentId);
            var module = await _context.Modules.FindAsync(moduleId);

#pragma warning disable CS8603 // Possible null reference return.
            if (student == null || module == null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var topic = student.CreateTopic(title, description, module);
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<bool> SubscribeToTopicAsync(int studentId, int topicId)
        {
            var student = await GetStudentByIdAsync(studentId);
            var topic = await _context.Topics.FindAsync(topicId);

            if (student == null || topic == null) return false;

            student.SubscribeTopic(topic);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnsubscribeFromTopicAsync(int studentId, int topicId)
        {
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.StudentID == studentId && s.TopicID == topicId);

            if (subscription == null) return false;

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Message> SendMessageAsync(int studentId, int tutorId, string content, int? topicId)
        {
            var student = await GetStudentByIdAsync(studentId);
            var tutor = await _context.Tutors.FindAsync(tutorId);
            Topic topic = null;

            if (topicId.HasValue)
                topic = await _context.Topics.FindAsync(topicId.Value);

#pragma warning disable CS8603 // Possible null reference return.
            if (student == null || tutor == null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var message = student.SendMessage(tutor, content, topic);
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Feedback> GiveFeedbackAsync(int studentId, int tutorId, int rating, string comment)
        {
            var student = await GetStudentByIdAsync(studentId);
            var tutor = await _context.Tutors.FindAsync(tutorId);

#pragma warning disable CS8603 // Possible null reference return.
            if (student == null || tutor == null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var feedback = student.GiveFeedback(tutor, rating, comment);
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<IEnumerable<Topic>> GetSubscribedTopicsAsync(int studentId)
        {
            return await _context.Subscriptions
                .Where(s => s.StudentID == studentId)
                .Include(s => s.Topic)
                .Select(s => s.Topic)
                .ToListAsync();
        }

        // Additional helper method to get topics created by a student
        public async Task<IEnumerable<Topic>> GetCreatedTopicsAsync(int studentId)
        {
            return await _context.Topics
                .Where(t => t.StudentID == studentId)
                .ToListAsync();
        }
    }
}