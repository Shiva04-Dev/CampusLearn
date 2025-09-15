using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Tutor")]
        public int TutorID { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime FeedbackDate { get; set; } = DateTime.Now;


        public void UpdateFeedback(int newRating, string newComment)
        {
            
        }
    }
}