using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Resource
    {
        [Key]
        public int ResourceID { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }

        [Required]
        public Enums.ResourceType Type { get; set; }

        [Required]
        public required string FilePath { get; set; }

        [Required]
        public DateTime UploadedDate { get; set; }

        [ForeignKey("Tutor")]
        public int TutorID { get; set; }

        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        public virtual required Tutor Tutor { get; set; }
        public virtual required Topic Topic { get; set; }

        public byte[] Download()
        {
            return System.IO.File.ReadAllBytes(FilePath);
        }

        public void Delete()
        {
            if (System.IO.File.Exists(FilePath))
            {
                System.IO.File.Delete(FilePath);
            }
        }
    }
}