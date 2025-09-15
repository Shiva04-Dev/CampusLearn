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
    public class ResponseService : IResponseService
    {
        private readonly CampusLearnContext _context;

        public ResponseService(CampusLearnContext context)
        {
            _context = context;
        }

        public async Task<TutorResponse> GetResponseByIdAsync(int responseId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.TutorTopicResponses
                .FirstOrDefaultAsync(r => r.TutorResponseID == responseId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<TutorResponse>> GetResponsesByTutorAsync(int tutorId)
        {
            return await _context.TutorTopicResponses
                .Where(r => r.TutorID == tutorId)
                .OrderByDescending(r => r.ResponseDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TutorResponse>> GetResponsesByTopicAsync(int topicId)
        {
            return await _context.TutorTopicResponses
                .Where(r => r.TopicID == topicId)
                .OrderBy(r => r.ResponseDate)
                .ToListAsync();
        }

        public async Task<TutorResponse> CreateResponseAsync(TutorResponse response)
        {
            try
            {
                _context.TutorTopicResponses.Add(response);
                await _context.SaveChangesAsync();
                return response;
            }
            catch (Exception)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public async Task<bool> UpdateResponseAsync(int responseId, string newText)
        {
            var response = await GetResponseByIdAsync(responseId);
            if (response == null) return false;

            response.EditResponse(newText);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteResponseAsync(int responseId)
        {
            try
            {
                var response = await GetResponseByIdAsync(responseId);
                if (response == null) return false;

                _context.TutorTopicResponses.Remove(response);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> GetResponseCountByTutorAsync(int tutorId)
        {
            return await _context.TutorTopicResponses
                .CountAsync(r => r.TutorID == tutorId);
        }

        public async Task<int> GetResponseCountByTopicAsync(int topicId)
        {
            return await _context.TutorTopicResponses
                .CountAsync(r => r.TopicID == topicId);
        }
    }
}