using SharpGit.Backbone;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SharpGit.Util
{
    class ProcessEventHandler
    {
        public Dispatcher Dispatcher { get; set; }
        public Action<string> Action { get; set; }

        public ProcessEventHandler(Dispatcher dispatcher, Action<string> action)
        {
            Dispatcher = dispatcher;
            Action = action;
        }
        public void OnProcessFinished(Task<string> task)
        {
            string content;
            if (task.Exception != null)
            {
                content = task.Exception.Message;
            }
            else
            {
                content = task.Result;
            }
            Status.TemporaryData = null;
            Dispatcher.BeginInvoke(new Action<string>(Action), DispatcherPriority.Normal, content);
        }
    }
}
