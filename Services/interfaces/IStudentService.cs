using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<bool> CreateStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int studentId);
        Task<Topic> CreateTopicAsync(int studentId, string title, string description, int moduleId);
        Task<bool> SubscribeToTopicAsync(int studentId, int topicId);
        Task<bool> UnsubscribeFromTopicAsync(int studentId, int topicId);
        Task<Message> SendMessageAsync(int studentId, int tutorId, string content, int? topicId);
        Task<Feedback> GiveFeedbackAsync(int studentId, int tutorId, int rating, string comment);
        Task<IEnumerable<Topic>> GetSubscribedTopicsAsync(int studentId);
    }
}