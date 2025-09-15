using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusLearn.Models
{
    public class FAQ
    {
        [Key]
        public int FaqID { get; set; }

        [Required]
        public required string Question { get; set; }

        [Required]
        public required string Answer { get; set; }

        [ForeignKey("Module")]
        public int ModuleID { get; set; }

        public virtual required Module Module { get; set; }

        public void UpdateAnswer(string newAnswer)
        {
            Answer = newAnswer;
        }
    }
}