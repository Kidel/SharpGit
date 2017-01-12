using SharpGit.Backbone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharpGit.UI
{
    /// <summary>
    /// Logica di interazione per ClonePage.xaml
    /// </summary>
    public partial class ClonePage : Page
    {
        public ClonePage()
        {
            InitializeComponent();
        }

        private CommandInterface CommandInterface = new CommandInterface();

        private void Clone(object sender, RoutedEventArgs e)
        {
            Message m = CommandInterface.Clone(UrlText.Text, "test", PathText.Text);
            // TODO fork and loadbar
            Output.Text = m.Text;
        }

        private void Pull(object sender, RoutedEventArgs e)
        {

        }
    }
}
