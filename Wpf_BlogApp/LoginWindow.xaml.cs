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
using System.Windows.Shapes;

namespace Wpf_BlogApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string userName;
        public string password;
        public string email;
        public LoginWindow()
        {
            InitializeComponent();

        }
        
        private void BtnSubmitLogin_Click(object sender, RoutedEventArgs e)
        {

            MainWindow main = this.Owner as MainWindow;
            main.Visibility = Visibility.Visible;
            main.Visibility = Visibility.Hidden;
            string emailLogin = textBoxEmailLogin.Text;
            string passwordLogin = textBoxPasswordLogin.Text;
            bool loggedIN = false;
            foreach (var member in main.members)
            {
                if (member.Email.ToString() == emailLogin && member.Password.ToString() == passwordLogin)
                {
                    loggedIN = true;
                    userName = member.UserName.ToString();
                    email = member.Email.ToString();
                    password = member.Password.ToString();
                }
            }

            if (loggedIN)
            {
                IsLoggedIN();
            }
            else
                BackToMainWindow();

        }

        private void BackToMainWindow()
        {
            MessageBox.Show("Incorrect information");
            MainWindow main = new MainWindow();
            main.Owner = this;
            main.ShowDialog();
            this.Close();
        }

        private void IsLoggedIN()
        {
            string strFromLogin = textBoxEmailLogin.Text;

            this.Visibility = Visibility.Hidden;
            DisplayAllMembers loggedInWindow = new DisplayAllMembers(strFromLogin);         
            loggedInWindow.Owner = this;
            loggedInWindow.ShowDialog();
            textBoxEmailLogin.Text = loggedInWindow.strFromLogin;
            this.Close();
        }
    }
}
