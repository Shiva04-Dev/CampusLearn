using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public enum EscalationStatus { PENDING, ASSIGNED, RESOLVED}
    public class Escalation
    {
        [Key]
        public int EscalationID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Tutor")]
        public int? TutorID { get; set; }

        [Required]
        public string QueryText { get; set; }

        [Required]
        public DateTime EscalationDate { get; set; } = DateTime.Now;

        [Required]
        public EscalationStatus Status { get; set; } = EscalationStatus.PENDING;


        public void AssignTutor(Tutor tutor)
        {
           
        }

        public void Resolve()
        {
         
        }
    }
}