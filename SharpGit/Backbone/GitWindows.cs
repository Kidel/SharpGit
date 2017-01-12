using System.Diagnostics;
using System.IO;

namespace SharpGit.Backbone
{
    class GitWindows : IGitInterface
    {
        private System.Diagnostics.Process Process;
        public GitWindows()
        {
            Process = new Process();

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.FileName = "git";
            processStartInfo.Arguments = "";
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;

            Process.StartInfo = processStartInfo;
        }

        public Message SendMessage(string message)
        {
            Process.StartInfo.Arguments = message;
            Process.Start();

            string error = Process.StandardError.ReadToEnd();
            string output = Process.StandardOutput.ReadToEnd();
            Process.WaitForExit();
            Message m = new Message();
            if (error == "")
            {
                m.Type = 1;
                m.Text = error;
            }
            else
            {
                m.Type = 0;
                m.Text = message;
            }
            return m;
        }

        public bool ChangeWorkingDirectory(string path)
        {
            //if (!File.Exists(path)) return false; 
            Process.StartInfo.WorkingDirectory = path;
            return true;
        }
    }
}
