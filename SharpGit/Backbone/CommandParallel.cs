using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGit.Backbone
{
    class CommandParallel
    {
        private CommandInterface CommandInterface = new CommandInterface();
        public string CloneProcess()
        {
            string url, name, path;
            if (Status.TemporaryData != null &&
                Status.TemporaryData.TryGetValue("url", out url) &&
                Status.TemporaryData.TryGetValue("name", out name) &&
                Status.TemporaryData.TryGetValue("path", out path))
            {
                Message m = CommandInterface.Clone(url, name, path);
                return m.IsError() ? $"There was an error: {m.Text}" : $"Repository successfully cloned to {m.Text}";
            }
            else return "Unexpected error";
        }
    }
}
