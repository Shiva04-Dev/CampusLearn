using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public enum ResourceType { PDF, Video, Audio, Other }

    public class Resource
    {
        [Key]
        public int ResourceID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public DateTime UploadedDate { get; set; } = DateTime.Now;

        [ForeignKey("Tutor")]
        public int TutorID { get; set; }

        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        
        public object Download() { return null; }
        public void Delete() { }
    }
}
