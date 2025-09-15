using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public enum TopicStatus { OPEN, RESOLVED }

    public class Topic
    {
        [Key]
        public int TopicID { get; set; }

        [Required]
        public required string Title { get; set; }

        public required string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public TopicStatus Status { get; set; } = TopicStatus.OPEN;

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; }

        public TutorResponse AddResponse(Tutor tutor, string text)
        {
            throw new NotImplementedException();
        }

        public Resource AddResource(string file)
        {
            throw new NotImplementedException();
        }

        public void CloseTopic()
        {

        }
    }
}