using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Upvote
    {
        [Key]
        public int UpvoteID { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public DateTime DateUpvoted { get; set; } = DateTime.Now;

        public virtual required Post Post { get; set; }
        public virtual required Student Student { get; set; }

        public void Remove()
        {
            // Implementation would remove this upvote from database
        }
    }
}