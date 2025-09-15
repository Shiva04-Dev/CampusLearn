using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Student : User
    {
        [Key, ForeignKey("User")]
        public int StudentID { get; set; }

        [Required]
        public string Programme { get; set; }

        [Range(1, 4)]
        public int YearOfStudy { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        //Methods
        public Topic CreateTopic(string title, string description, Module module)
        {
            return null;
        }

        public void SubscribeTopic(Topic topic)
        {

        }

        public Message SendMessage(Tutor tutor, string content)
        {
            return null;
        }

        public Feedback GiveFeedback(Tutor tutor, int rating, string comment)
        {
            return null;
        }
    }
}