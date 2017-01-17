using SharpGit.Backbone;
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
    /// Logica di interazione per LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private CommandInterface CommandInterface = new CommandInterface();
        private UserFacade uf = new UserFacade();

        public LoginPage()
        {
            InitializeComponent();
            var userList = uf.GetUserList();
            if (userList.Count > 0)
            {
                var user = userList.First();
                UsernameText.Text = user.UserName;
                ServiceSelector.Text = user.AccountType;

                EmailText.Text = user.Email;
                FirstNameText.Text = user.GetFirstName();
                LastNameText.Text = user.GetLastName();
            }
        }

        private void LoginUser(object sender, RoutedEventArgs e)
        {
            Message m = CommandInterface.LogIn(UsernameText.Text, PasswordText.Password, ServiceSelector.Text);
            Output1.Text = m.IsError() ? $"Unexpected error: {m.Text}" : $"Login successfull, password won't be stored but will be kept for this session";
            // TODO load repo panel if m.Type is not error
        }

        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            Message m = new Message();
            var userList = uf.GetUserList();
            if (userList.Count > 0)
            {
                var user = userList.First();
                uf.UpdateUser(user.UserId, EmailText.Text, UsernameText.Text, $"{FirstNameText.Text} {LastNameText.Text}", ServiceSelector.Text);
                m.Text = "Updated";
                CommandInterface.SetCurrentUser(user);
            }
            else
            {
                m.Text = "You must log in before updating";
                m.SetError();
            }
            Output2.Text = m.Text;
            // TODO load repo panel if m.Type is not error
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
