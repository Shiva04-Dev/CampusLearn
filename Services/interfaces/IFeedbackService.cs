using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> GetFeedbackByIdAsync(int feedbackId);
        Task<IEnumerable<Feedback>> GetFeedbacksByTutorAsync(int tutorId);
        Task<IEnumerable<Feedback>> GetFeedbacksByStudentAsync(int studentId);
        Task<Feedback> CreateFeedbackAsync(Feedback feedback);
        Task<bool> UpdateFeedbackAsync(int feedbackId, int rating, string comment);
        Task<bool> DeleteFeedbackAsync(int feedbackId);
        Task<double> GetAverageRatingAsync(int tutorId);
        Task<int> GetFeedbackCountAsync(int tutorId);
    }
}