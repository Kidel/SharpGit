using System;
using SharpGit.Model.Facade;

namespace SharpGit.Backbone
{
    class CommandInterface
    {
        RepositoryFacade rf = new RepositoryFacade();
        UserFacade uf = new UserFacade();

        public Message Clone(string url, string name, string destinationFolder)
        {
            Message m = new Message();
            try
            {
                m.Type = 0;
                m.Text = LibGit2Sharp.Repository.Clone(url, destinationFolder);

                SelectRepository(rf.CreateRepository(name, destinationFolder).Name);
            }
            catch (Exception e)
            {
                m.Type = 1;
                m.Text = e.Message;
            }
            return m;
        }

        public Message SelectRepository(string name) {
            Message m = new Message();
            try
            {
                m.Type = 0;
                m.Text = $"Loaded repository {name}";
                Status.CurrentRepository = rf.GetRepositorybyName(name);
                var repo = new LibGit2Sharp.Repository(Status.CurrentRepository.Path);
                Status.CurrentRepository.Branches = repo.Branches;
                Status.CurrentRepository.Sources = repo.Network.Remotes;
            }
            catch (Exception e)
            {
                m.Type = 1;
                m.Text = e.Message;
            }
            return m;
        }
        public Message Pull()
        {
            Message m = new Message();
            try
            {
                m.Type = 0;

                var repo = new LibGit2Sharp.Repository(Status.CurrentRepository.Path);
                LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
                options.FetchOptions = new LibGit2Sharp.FetchOptions();
                options.FetchOptions.CredentialsProvider = new LibGit2Sharp.Handlers.CredentialsHandler(
                    (url, usernameFromUrl, types) =>
                        new LibGit2Sharp.UsernamePasswordCredentials()
                        {
                            Username = Status.CurrentUser.UserName,
                            Password = Status.CurrentUser.Password,
                        });
                m.Text = LibGit2Sharp.Commands.Pull(repo, 
                                                    new LibGit2Sharp.Signature(Status.CurrentUser.UserName, Status.CurrentUser.Password, new DateTimeOffset(DateTime.Now)), 
                                                    options)
                                                    .Status
                                                    .ToString();
            }
            catch (Exception e)
            {
                m.Type = 1;
                m.Text = e.Message;
            }
            return m;
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
