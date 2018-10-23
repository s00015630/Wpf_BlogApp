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
    public partial class LoggedInWindow : Window
    {
        public string strFromLogin { get; set; }

        List<string> userNames = new List<string>(); 
        public LoggedInWindow(string emailText)
        {
            InitializeComponent();
            MainWindow main = new MainWindow();
            main.Visibility = Visibility.Hidden;
            LoginWindow login = new LoginWindow();
            string loginEmail = emailText;       
            string userName = "";  
            
            foreach (var item in main.members)
            {
                userName = item.UserName.ToString();              
                userNames.Add(userName);
                if (loginEmail == item.Email.ToString())
                {
                    lbUserName.Content = item.UserName.ToString();
                }
            }
            listBoxMembers.ItemsSource = userNames.ToList();       
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Owner = this;
            main.ShowDialog();
            this.Close();
        }
    }
}
