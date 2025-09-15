using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Subscription
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        public DateTime SubscribedDate { get; set; } = DateTime.Now;

        public virtual Student Student { get; set; }
        public virtual Topic Topic { get; set; }

        public void Unsubscribe()
        {
            // Implementation would remove this subscription from database
        }
    }
}