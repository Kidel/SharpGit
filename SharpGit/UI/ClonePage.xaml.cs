using SharpGit.Backbone;
using SharpGit.Model.Facade;
using SharpGit.Util;
using System;
using System.Linq;
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
        private UserFacade uf = new UserFacade();
        private CommandInterface ci = new CommandInterface();
        private ProcessEventHandler peh;

        public ClonePage()
        {
            InitializeComponent();
            var userList = uf.GetUserList();
            if (userList.Count > 0)
            {
                var user = userList.First();
                PathText.Text = user.LastFolderUsed;
            }
        }

        private void UpdateOutputContent(string text) 
        {
            WindowStatus.ModalOutput.Text = text;
            WindowStatus.ModalFrameCloseButton.IsEnabled = true;
            WindowStatus.ShowModalFrame();
        }

        private void CloneParallel(object sender, RoutedEventArgs e)
        {
            if(Status.CurrentUser != null)
                uf.UpdateUser(Status.CurrentUser.UserId, "", "", "", "", "", PathText.Text);
            Status.SetTemporaryRepositoryData(UrlText.Text, NameText.Text, PathText.Text);
            UpdateOutputContent("Cloning...");
            WindowStatus.ModalFrameCloseButton.IsEnabled = false;
            // Start long running process and return immediatly
            var task = Task.Factory.StartNew(ci.CloneFromStatus);
            peh = new ProcessEventHandler(Dispatcher, UpdateOutputContent);
            task.ContinueWith(peh.OnProcessFinished);
        }

    }
}
