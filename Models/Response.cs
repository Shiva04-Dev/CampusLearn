using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class TutorResponse
    {
        [Key]
        public int TutorResponseID { get; set; }

        [ForeignKey("Tutor")]
        public int TutorID { get; set; }

        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        [Required]
        public required string ResponseText { get; set; }

        [Required]
        public DateTime ResponseDate { get; set; } = DateTime.Now;

        public virtual required Tutor Tutor { get; set; }
        public virtual required Topic Topic { get; set; }

        public void EditResponse(string newText)
        {
            ResponseText = newText;
        }
    }
}