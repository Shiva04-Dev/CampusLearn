using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface ITopicService
    {
        Task<Topic> GetTopicByIdAsync(int topicId);
        Task<IEnumerable<Topic>> GetAllTopicsAsync();
        Task<IEnumerable<Topic>> GetTopicsByModuleAsync(int moduleId);
        Task<IEnumerable<Topic>> GetTopicsByStatusAsync(Models.Enums.Status status);
        Task<bool> CreateTopicAsync(Topic topic);
        Task<bool> UpdateTopicAsync(Topic topic);
        Task<bool> DeleteTopicAsync(int topicId);
        Task<bool> CloseTopicAsync(int topicId);
        Task<IEnumerable<TutorResponse>> GetTopicResponsesAsync(int topicId);
        Task<IEnumerable<Resource>> GetTopicResourcesAsync(int topicId);
        Task<IEnumerable<Student>> GetTopicSubscribersAsync(int topicId);
        Task<int> GetTopicSubscriptionCountAsync(int topicId);
    }
}