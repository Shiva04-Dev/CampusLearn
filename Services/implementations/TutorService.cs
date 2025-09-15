using CampusLearn.Data;
using CampusLearn.Models;
using CampusLearn.Models.Enums;
using CampusLearn.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLearn.Services.Implementations
{
    public class TutorService : ITutorService
    {
        private readonly CampusLearnContext _context;

        public TutorService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<Tutor> GetTutorByIdAsync(int tutorId)
        {
            return await _context.Tutors
                .Include(t => t.TutorExpertise)
                .ThenInclude(e => e.Module)
                .Include(t => t.Responses)
                .Include(t => t.UploadedMaterials)
                .FirstOrDefaultAsync(t => t.TutorID == tutorId);
        }

        public async Task<IEnumerable<Tutor>> GetAllTutorsAsync()
        {
            return await _context.Tutors.ToListAsync();
        }

        public async Task<bool> CreateTutorAsync(Tutor tutor)
        {
            try
            {
                _context.Tutors.Add(tutor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTutorAsync(Tutor tutor)
        {
            try
            {
                _context.Tutors.Update(tutor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTutorAsync(int tutorId)
        {
            try
            {
                var tutor = await GetTutorByIdAsync(tutorId);
                if (tutor == null) return false;

                _context.Tutors.Remove(tutor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TutorResponse> RespondToTopicAsync(int tutorId, int topicId, string responseText)
        {
            var tutor = await GetTutorByIdAsync(tutorId);
            var topic = await _context.Topics.FindAsync(topicId);

#pragma warning disable CS8603 // Possible null reference return.
            if (tutor == null || topic == null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var response = tutor.RespondTopic(topic, responseText);
            _context.TutorTopicResponses.Add(response);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<Resource> UploadMaterialAsync(int tutorId, int topicId, string filePath, Models.Enums.ResourceType type, string title)
        {
            var tutor = await GetTutorByIdAsync(tutorId);
            var topic = await _context.Topics.FindAsync(topicId);

            if (tutor == null || topic == null) return null;

            var material = tutor.UploadMaterial(topic, filePath, type, title);
            _context.LearningMaterials.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task<bool> MarkTopicAsResolvedAsync(int tutorId, int topicId)
        {
            var tutor = await GetTutorByIdAsync(tutorId);
            var topic = await _context.Topics.FindAsync(topicId);

            if (tutor == null || topic == null) return false;

            tutor.MarkResolved(topic);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Topic>> GetAssignedTopicsAsync(int tutorId)
        {
            return await _context.TutorTopicResponses
                .Where(r => r.TutorID == tutorId)
                .Include(r => r.Topic)
                //  .ThenInclude(t => t.Module)
                .Select(r => r.Topic)
                .Distinct()
                .ToListAsync();
        }


        public async Task<bool> AddExpertiseAsync(int tutorId, int moduleId, string expertiseLevel)
        {
            var tutor = await GetTutorByIdAsync(tutorId);
            var module = await _context.Modules.FindAsync(moduleId);

            if (tutor == null || module == null) return false;

            var expertise = new TutorExpertise
            {
                TutorID = tutorId,
                ModuleID = moduleId,
                ExpertiseLevel = expertiseLevel
            };

            _context.TutorExpertises.Add(expertise);
            await _context.SaveChangesAsync();
            return true;
        }

              public Task<IEnumerable<Module>> GetTutorExpertisesAsync(int tutorId)
        {
            throw new NotImplementedException();
        }
    }

    public class TutorExpertise : Expertise
    {
        public int TutorID { get; set; }
        public int ModuleID { get; set; }
        //  public string ExpertiseLevel { get; set; }
    }
}
    