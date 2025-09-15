using CampusLearn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampusLearn.Services.Interfaces
{
    public interface IModuleService
    {
        Task<Module> GetModuleByIdAsync(int moduleId);
        Task<Module> GetModuleByCodeAsync(string moduleCode);
        Task<IEnumerable<Module>> GetAllModulesAsync();
        Task<bool> CreateModuleAsync(Module module);
        Task<bool> UpdateModuleAsync(Module module);
        Task<bool> DeleteModuleAsync(int moduleId);
        Task<Topic> AddTopicToModuleAsync(int moduleId, string title, string description, int studentId);
        Task<bool> AssignTutorToModuleAsync(int moduleId, int tutorId, string expertiseLevel);
        Task<IEnumerable<Tutor>> GetModuleTutorsAsync(int moduleId);
        Task<IEnumerable<Topic>> GetModuleTopicsAsync(int moduleId);
        Task<IEnumerable<FAQ>> GetModuleFAQsAsync(int moduleId);
    }
}