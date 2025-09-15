using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CampusLearn.Models.Enums;
using System;

namespace CampusLearn.Services.Interfaces
{
    public interface ITutorService
    {
        
        Task<Tutor> GetTutorByIdAsync(int tutorId);
        Task<IEnumerable<Tutor>> GetAllTutorsAsync();
        Task<bool> CreateTutorAsync(Tutor tutor);
        Task<bool> UpdateTutorAsync(Tutor tutor);
        Task<bool> DeleteTutorAsync(int tutorId);
        Task<TutorResponse> RespondToTopicAsync(int tutorId, int topicId, string responseText);
        Task<Resource> UploadMaterialAsync(int tutorId, int topicId, string filePath, ResourceType type, string title);
        Task<bool> MarkTopicAsResolvedAsync(int tutorId, int topicId);
        Task<IEnumerable<Topic>> GetAssignedTopicsAsync(int tutorId);
        Task<IEnumerable<Module>> GetTutorExpertisesAsync(int tutorId);
        Task<bool> AddExpertiseAsync(int tutorId, int moduleId, string expertiseLevel);
    }
}