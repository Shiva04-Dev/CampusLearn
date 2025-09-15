using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class Expertise
    {
        [Key]
        public int ExpertiseID { get; set; }

        [ForeignKey("Tutor")]
        public virtual  Tutor Tutor { get; set; }
        public int TutorID { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; }

        public required string ExpertiseLevel { get; set; }
        public object Module { get; internal set; }

        public void UpdateExpertiseLevel(string level)
        {

        }
    }
}