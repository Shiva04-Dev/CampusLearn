using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<Notification>> GetNotificationsByStudentAsync(int studentId);
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int studentId);
        Task<Notification> CreateNotificationAsync(Notification notification);
        Task<bool> MarkNotificationAsReadAsync(int notificationId);
        Task<bool> DeleteNotificationAsync(int notificationId);
        Task<bool> SendNotificationAsync(int notificationId);
        Task<int> GetUnreadNotificationCountAsync(int studentId);
    }
}