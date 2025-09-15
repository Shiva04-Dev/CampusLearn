using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CampusLearn.Services.Implementations;

namespace CampusLearn.Models
{
    public class Tutor : User
    {
        [Key]
        [ForeignKey("User")]
        public int TutorID { get; set; }

        public string Bio { get; set; } = string.Empty;

        [MaxLength(20)]
        public string StaffID { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<TutorExpertise> TutorExpertise { get; set; } = new List<TutorExpertise>();
        public virtual ICollection<TutorResponse> Responses { get; set; } = new List<TutorResponse>();
        public virtual ICollection<Resource> UploadedMaterials { get; set; } = new List<Resource>();
        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public virtual ICollection<Feedback> ReceivedFeedbacks { get; set; } = new List<Feedback>();
        public virtual ICollection<Escalation> AssignedEscalations { get; set; } = new List<Escalation>();

        // Methods
        public TutorResponse RespondTopic(Topic topic, string responseText)
        {
            return new TutorResponse
            {
                Tutor = this,
                Topic = topic,
                ResponseText = responseText,
                ResponseDate = DateTime.Now
            };
        }

        public Resource UploadMaterial(Topic topic, string filePath, Enums.ResourceType type, string title)
        {
            return new Resource
            {
                Tutor = this,
                Topic = topic,
                FilePath = filePath,
                Type = type,
                Title = title,
                UploadedDate = DateTime.Now
            };
        }

        public void MarkResolved(Topic topic)
        {
            topic.CloseTopic();
        }
    }
}