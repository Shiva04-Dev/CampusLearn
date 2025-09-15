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
    public class ModuleService : IModuleService
    {
        private readonly CampusLearnContext _context;

        public ModuleService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<Module> GetModuleByIdAsync(int moduleId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Modules
                .Include(m => m.Topics)
           
                .FirstOrDefaultAsync(m => m.ModuleID == moduleId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Module> GetModuleByCodeAsync(string moduleCode)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Modules
                .FirstOrDefaultAsync(m => m.ModuleCode == moduleCode);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<bool> CreateModuleAsync(Module module)
        {
            try
            {
                _context.Modules.Add(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateModuleAsync(Module module)
        {
            try
            {
                _context.Modules.Update(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteModuleAsync(int moduleId)
        {
            try
            {
                var module = await GetModuleByIdAsync(moduleId);
                if (module == null) return false;

                _context.Modules.Remove(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Topic> AddTopicToModuleAsync(int moduleId, string title, string description, int studentId)
        {
            var module = await GetModuleByIdAsync(moduleId);
            var student = await _context.Students.FindAsync(studentId);

#pragma warning disable CS8603 // Possible null reference return.
            if (module == null || student == null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var topic = module.AddTopic(title);
            topic.Description = description;
            topic.StudentID = studentId;
            
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<bool> AssignTutorToModuleAsync(int moduleId, int tutorId, string expertiseLevel)
        {
            var module = await GetModuleByIdAsync(moduleId);
            var tutor = await _context.Tutors.FindAsync(tutorId);

            if (module == null || tutor == null) return false;

            var expertise = module.AssignTutor(tutor, expertiseLevel);
            _context.TutorExpertises.Add(expertise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tutor>> GetModuleTutorsAsync(int moduleId)
        {
            return await _context.TutorExpertises
                .Where(e => e.ModuleID == moduleId)
                .Include(e => e.Tutor)
                .Select(e => e.Tutor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetModuleTopicsAsync(int moduleId)
        {
            return await _context.Topics
                .Where(t => t.ModuleID == moduleId)
                .ToListAsync();
        }

        public async Task<IEnumerable<FAQ>> GetModuleFAQsAsync(int moduleId)
        {
            return await _context.FAQs
                .Where(f => f.ModuleID == moduleId)
                .ToListAsync();
        }
    }
}