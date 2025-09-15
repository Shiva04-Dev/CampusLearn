using Microsoft.Extensions.DependencyModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Tutor : User
    {
        [Key, ForeignKey("User")]
        public int TutorID { get; set; }

        public string Bio { get; set; }

        [StringLength(20)]
        public string StaffID { get; set; }

        public Response RespondTopic(Topic topic, string response)
        {
            return null;
        }

        public Resource UploadMaterial(Topic topic, string filePath, string type)
        {
            return null;
        }

        void MarkResolved(Topic topic)
        {

        }
    }
}