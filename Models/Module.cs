using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusLearn.Models
{
    public class Module
    {
        internal object TutorExpertises;

        [Key]
        public int ModuleID { get; set; }

        [Required, StringLength(10)]
        public required string ModuleCode { get; set; }

        [Required, StringLength(100)]
        public required string ModuleName { get; set; }
        public object Topics { get; internal set; }
        public object Expertises { get; internal set; }

        public Topic AddTopic(string title)
        {
            throw new System.NotImplementedException();
        }

        public Expertise AssignTutor(Tutor tutor, string expertiseLevel)
        {
            throw new System.NotImplementedException();
        }
    }
}