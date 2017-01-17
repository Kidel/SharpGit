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
using SharpGit.UI;

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
            MainFrame.Content = new LoginPage();
            ModalFrame.Content = new SimpleModal();
            WindowStatus.ModalFrame = ModalFrame;
            HideModalFrame();
        }

        public void ShowModalFrame()
        {
            WindowStatus.ShowModalFrame();
        }
        public void HideModalFrame()
        {
            WindowStatus.HideModalFrame();
        }
        private void ShowClonePanel(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ClonePage();
        }

        private void ShowLoginPanel(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LoginPage();
        }

        private void ShowRepositoryListPanel(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LoginPage();
        }
    }
}
