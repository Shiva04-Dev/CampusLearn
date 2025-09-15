using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Escalation
    {
        [Key]
        public int EscalationID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Tutor")]
        public int? TutorID { get; set; }

        [Required]
        public required string QueryText { get; set; }

        [Required]
        public DateTime EscalationDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; } = "PENDING";

        public virtual required Student Student { get; set; }
        public virtual required Tutor Tutor { get; set; }

        public void AssignTutor(Tutor tutor)
        {
            Tutor = tutor;
            Status = "ASSIGNED";
        }

        public void Resolve()
        {
            Status = "RESOLVED";
        }
    }
}