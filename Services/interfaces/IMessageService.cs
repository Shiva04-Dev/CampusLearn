using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> GetMessageByIdAsync(int messageId);
        Task<IEnumerable<Message>> GetMessagesBetweenUsersAsync(int studentId, int tutorId);
        Task<IEnumerable<Message>> GetMessagesByTopicAsync(int topicId);
        Task<IEnumerable<Message>> GetSentMessagesAsync(int studentId);
        Task<IEnumerable<Message>> GetReceivedMessagesAsync(int tutorId);
        Task<Message> SendMessageAsync(Message message);
        Task<bool> MarkMessageAsReadAsync(int messageId);
        Task<bool> DeleteMessageAsync(int messageId);
        Task<int> GetUnreadMessageCountAsync(int tutorId);
    }
}