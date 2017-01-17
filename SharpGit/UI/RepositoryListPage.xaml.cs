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

            repositories = rf.GetRepositoryList();
            if (repositories.Count > 0)
            {
                ListBox.ItemsSource = repositories;
            }
        }

        private void SelectRepository(object sender, MouseButtonEventArgs e)
        {
            Status.CurrentRepository = (Repository)((Grid)sender).DataContext;
            // TODO goes to repository page
        }
    }
}
