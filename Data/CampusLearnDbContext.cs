using Microsoft.EntityFrameworkCore;
using CampusLearn.Models;

namespace CampusLearn.Data
{
    public class CampusLearnContext : DbContext
    {
        public CampusLearnContext(DbContextOptions<CampusLearnContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Expertise> TutorExpertises { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Resource> LearningMaterials { get; set; }
        public DbSet<Post> ForumPosts { get; set; }
        public DbSet<Upvote> Upvotes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TutorResponse> TutorTopicResponses { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Escalation> Escalations { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public object TutorResponse { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Student>("Student")
                .HasValue<Tutor>("Tutor")
                .HasValue<Admin>("Admin");

            modelBuilder.Entity<Subscription>()
                .HasKey(s => new { s.StudentID, s.TopicID });

            modelBuilder.Entity<Expertise>()
                .HasKey(e => new { e.TutorID, e.ModuleID });

            // Configure additional relationships as needed
        }
    }
}