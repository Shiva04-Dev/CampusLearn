using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Expertise
    {
        [Key]
        public int ExpertiseID { get; set; }

        [ForeignKey("Tutor")]
        public int TutorID { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; }

        public string ExpertiseLevel { get; set; }

        public void UpdateExpertiseLevel(string level)
        {

        }
    }
}