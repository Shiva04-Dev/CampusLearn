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

        public required string Comment { get; set; }

        public DateTime FeedbackDate { get; set; } = DateTime.Now;

        public virtual required Student Student { get; set; }
        public virtual required Tutor Tutor { get; set; }

        public void UpdateFeedback(int newRating, string newComment)
        {
            if (newRating < 1 || newRating > 5)
                throw new ArgumentException("Rating must be between 1 and 5");

            Rating = newRating;
            Comment = newComment;
        }
    }
}