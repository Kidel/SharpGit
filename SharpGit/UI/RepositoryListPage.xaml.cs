using SharpGit.Backbone;
using SharpGit.Model;
using SharpGit.Model.Facade;
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
    /// Interaction logic for RepositoryListPage.xaml
    /// </summary>
    public partial class RepositoryListPage : Page
    {
        private RepositoryFacade rf = new RepositoryFacade();
        private List<Repository> repositories;
        public RepositoryListPage()
        {
            InitializeComponent();

            InitializeRepositoryList();
        }

        private void InitializeRepositoryList()
        {
            repositories = rf.GetRepositoryList();
            ListBox.ItemsSource = repositories;
        }
        private void SelectRepository(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Status.CurrentRepository = (Repository)((Grid)sender).DataContext;
                WindowStatus.ShowRepositoryPage();
            }
        }
        private void DeleteRepository(object sender, RoutedEventArgs e)
        {
            Status.CurrentRepository = null;
            Repository selected = (Repository)(ListBox.SelectedItem);
            rf.DeleteRepository(selected.RepositoryId);
            InitializeRepositoryList();
        }
        private void OpenRepository(object sender, RoutedEventArgs e)
        {
            Status.CurrentRepository = (Repository)(ListBox.SelectedItem);
            WindowStatus.ShowRepositoryPage();
        }
    }
}
