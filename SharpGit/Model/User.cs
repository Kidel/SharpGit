using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpGit.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string AccountType { get; set; }

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public bool RememberPassword { get; set; }
    }
}