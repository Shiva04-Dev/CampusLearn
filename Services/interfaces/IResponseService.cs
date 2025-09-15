using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IResponseService
    {
        Task<TutorResponse> GetResponseByIdAsync(int responseId);
        Task<IEnumerable<TutorResponse>> GetResponsesByTutorAsync(int tutorId);
        Task<IEnumerable<TutorResponse>> GetResponsesByTopicAsync(int topicId);
        Task<TutorResponse> CreateResponseAsync(TutorResponse response);
        Task<bool> UpdateResponseAsync(int responseId, string newText);
        Task<bool> DeleteResponseAsync(int responseId);
        Task<int> GetResponseCountByTutorAsync(int tutorId);
        Task<int> GetResponseCountByTopicAsync(int topicId);
    }
}