using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [ForeignKey("Topic")]
        public int TopicID { get; set; }

        [ForeignKey("Student")]
        public int? StudentID { get; set; } // Nullable for anonymous posts

        [ForeignKey("Post")]
        public int? ParentPostID { get; set; } // For threaded replies

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DatePosted { get; set; } = DateTime.Now;

        
        public Post Reply(string content) { return null; }
        public void Edit(string content) { }
    }
}
