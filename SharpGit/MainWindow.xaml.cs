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
using SharpGit.Backbone;

namespace SharpGit
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CommandInterface CommandInterface = new CommandInterface();

        private void Clone(object sender, RoutedEventArgs e)
        {
            Message m = CommandInterface.Clone(UrlText.Text, "test", PathText.Text);
            Output.Text = m.Text;
        }

        private void Pull(object sender, RoutedEventArgs e)
        {

        }
    }
}
