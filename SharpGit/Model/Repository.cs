using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpGit.Model
{
    public class Repository
    {
        public int RepositoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }

        [NotMapped]
        public LibGit2Sharp.BranchCollection Branches { get; set; }
        [NotMapped]
        public LibGit2Sharp.RemoteCollection Sources { get; set; }
    }
}
