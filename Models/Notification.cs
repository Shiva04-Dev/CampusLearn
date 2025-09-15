using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public enum NotificationType { EMAIL, SMS }
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Tutor")]
        public int TutorID { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        public DateTime DateSent { get; set; } = DateTime.Now;


        public void Send()
        {
            
        }
    }
}