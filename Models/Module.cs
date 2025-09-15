using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampusLearn.Models
{
    public class Module
    {
        [Key]
        public int ModuleID { get; set; }

        [Required, StringLength(10)]
        public string ModuleCode { get; set; }

        [Required, StringLength(100)]
        public string ModuleName { get; set; }

        public Topic AddTopic(string title)
        {
            return null;
        }

        public Expertise AssignTutor(Tutor tutor)
        {
            return null;
        }
    }
}