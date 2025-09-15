using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Tutor")]
        public int? TutorID { get; set; }

        [Required]
        public required string Message { get; set; }

        [Required]
        public Enums.NotificationType Type { get; set; }

        public DateTime DateSent { get; set; } = DateTime.Now;

        public virtual required Student Student { get; set; }
        public virtual required Tutor Tutor { get; set; }

        public void Send()
        {
            switch (Type)
            {
                case Enums.NotificationType.EMAIL:
                    // Send email logic
                    break;
                case Enums.NotificationType.SMS:
                    // Send SMS logic
                    break;
                case Enums.NotificationType.WHATSAPP:
                    // Send WhatsApp message logic
                    break;
            }
        }
    }
}