namespace SharpGit.Backbone
{
    interface IGitInterface
    {
        Message SendMessage(string message);
        bool ChangeWorkingDirectory(string path);
    }
}
