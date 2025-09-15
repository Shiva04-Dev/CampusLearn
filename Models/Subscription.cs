using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Subscription
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        public DateTime SubscribedDate { get; set; } = DateTime.Now;

        public void Unsubscribe()
        {
            // Implementation would remove this subscription from database
        }
    }
}