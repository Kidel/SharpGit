using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGit.Model;

namespace SharpGit.Backbone
{
    static class Status
    {
        public static Repository CurrentRepository { get; set; }

        public static User CurrentUser { get; set; }
    }
}
