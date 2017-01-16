using SharpGit.Backbone;
using SharpGit.Util;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SharpGit.UI
{
    /// <summary>
    /// Logica di interazione per ClonePage.xaml
    /// </summary>
    public partial class ClonePage : Page
    {
        private CommandParallel cp = new CommandParallel();
        private ProcessEventHandler peh;

        public ClonePage()
        {
            InitializeComponent();
        }

        private void UpdateOutputContent(string text) 
        {
            Output.Text = text; // TODO: spawn a widget for this
        }

        private void CloneParallel(object sender, RoutedEventArgs e)
        {
            Status.SetTemporaryRepositoryData(UrlText.Text, NameText.Text, PathText.Text);
            UpdateOutputContent("Cloning..."); 
            // Start long running process and return immediatly
            var task = Task.Factory.StartNew(cp.CloneProcess);
            peh = new ProcessEventHandler(Dispatcher, UpdateOutputContent);
            task.ContinueWith(peh.OnProcessFinished);
        }
    }
}
