using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<Subscription> GetSubscriptionAsync(int studentId, int topicId);
        Task<IEnumerable<Subscription>> GetSubscriptionsByStudentAsync(int studentId);
        Task<IEnumerable<Subscription>> GetSubscriptionsByTopicAsync(int topicId);
        Task<bool> CreateSubscriptionAsync(Subscription subscription);
        Task<bool> DeleteSubscriptionAsync(int studentId, int topicId);
        Task<bool> IsSubscribedAsync(int studentId, int topicId);
        Task<int> GetSubscriptionCountAsync(int topicId);
    }
}