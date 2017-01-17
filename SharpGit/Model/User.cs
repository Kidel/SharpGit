using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public string LastFolderUsed { get; set; }

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public bool RememberPassword { get; set; }

        public string GetFirstName()
        {
            var names = Name.Split(' ');
            return string.Join(" ", names.Take(names.Length - 1).ToArray());
        }

        public string GetLastName()
        {
            var names = Name.Split(' ');
            return names[names.Length - 1];
        }
    }
}