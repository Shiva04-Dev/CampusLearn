using System;
using System.ComponentModel.DataAnnotations;

namespace CampusLearn.Models
{
    public abstract class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(50)]
        public required string UserName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        public virtual void Register(string username, string email, string password)
        {

        }

        public virtual bool Login(string email, string password)
        {
            return false;
        }

        public virtual void Logout()
        {

        }

    }
}