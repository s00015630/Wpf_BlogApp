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
using System.IO;
namespace Wpf_BlogApp
{
    /// <summary>
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class DisplayAllMembers : Window
    {
        public string strFromLogin { get; set; }
        string loginEmail = "";
        string userName = "";
        List<string> userNames = new List<string>(); 

        public DisplayAllMembers(string emailText)
        {
            InitializeComponent();
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Hidden;
            LoginWindow login = new LoginWindow();
            loginEmail = emailText;       
            userName = "";  
            
            foreach (var item in main.members)
            {
                userName = item.UserName.ToString();              
                userNames.Add(userName);
                if (loginEmail == item.Email.ToString())
                {
                    lbUserName.Content = item.UserName.ToString();
                    passwordLabel.Content = item.Email.ToString();
                }
            }
            listBoxMembers.ItemsSource = userNames.ToList();       
        }

        private void LogOutBtn(object sender, RoutedEventArgs e)
        {
            CloseAndGotoMain();
        }

        private void CloseAndGotoMain()
        {
            MainWindow main = new MainWindow();
            main.Owner = this;
            main.ShowDialog();
            this.Close();
        }

        private void DeleteMember(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Hidden;

            string deleteEmail = passwordLabel.Content.ToString();
            string fileName = "MembersList.txt";
            foreach (var item in main.members)
            {
                userNames.Remove(userName);

            }
            string[] recordIn;
            string[] Lines = File.ReadAllLines(fileName);
            File.Delete(fileName);// Deleting the file
            using (StreamWriter sw = File.AppendText(fileName))
            {
                foreach (string line in Lines)
                {
                    recordIn = line.Split(',');
                    string userName = recordIn[0];
                    string email = recordIn[1];
                    string password = recordIn[2];
                    if (email == deleteEmail)
                    {
                        //Skip the line
                        continue;
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            CloseAndGotoMain();
        }
    }
}
