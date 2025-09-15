using System;
using System.Collections.Generic;
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
        public int? StudentID { get; set; }

        [ForeignKey("ParentPost")]
        public int? ParentPostID { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public DateTime DatePosted { get; set; } = DateTime.Now;

        public bool IsFlagged { get; set; } = false;

        public virtual required Topic Topic { get; set; }
        public virtual Student? Student { get; set; }
        public virtual required Post ParentPost { get; set; }
        public virtual required ICollection<Post> Replies { get; set; }
        public virtual required ICollection<Upvote> Upvotes { get; set; }

        public Post Reply(string content, Student? student = null)
        {
            return new Post
            {
                Topic = Topic,
                ParentPost = this,
                Student = student,
                Content = content,
                DatePosted = DateTime.Now,
                Replies = new List<Post>(),
                Upvotes = new List<Upvote>()
            };
        }

        public void Edit(string content)
        {
            Content = content;
        }
    }
}