namespace SharpGit.Backbone
{
    class Message
    {
        public int Type { get; set; }
        public string Text { get; set; }

        public bool IsError()
        {
            return Type == 1;
        }

        public void SetError()
        {
            Type = 1;
        }
    }
}
