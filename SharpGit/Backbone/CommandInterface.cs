using LibGit2Sharp;
using System;

namespace SharpGit.Backbone
{
    class Commands
    {
        private IGitInterface GitInterface;

        public Commands()
        {
            GitInterface = new GitWindows();
        }

        public bool ChangeWorkingDirectory(string path)
        {
            return GitInterface.ChangeWorkingDirectory(path);
        }

        public Message Clone(string url)
        {
            return new Message { Type = 0, Text = Repository.Clone(url, @"C:\Users\Gaetano\Documents\Git\test") };
        }

        public Message Pull()
        {
            return GitInterface.SendMessage($"pull");
        }

        /*
        Message Fetch();
        Message Status();
        
        Message Push();
        Message Add();
        Message Add(string[] files);
        Message Commit(string message);
        Message Checkout();
        Message Checkout(string[] files);
        Message Checkout(string commit);
        Message Checkout(string commit, string[] files);
        Message ResetHard();
        */
    }
}
