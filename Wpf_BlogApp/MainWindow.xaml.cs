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
using System.Collections.ObjectModel;
using System.IO;

namespace Wpf_BlogApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Member> members = new ObservableCollection<Member>();
        
        public MainWindow()
        {
            InitializeComponent();
            GetListOfMembers();
        }

        private void GetListOfMembers()
        {
            FileStream inFile = new FileStream("MembersList.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn = "";
            string[] details;

            recordIn = reader.ReadLine();

            while (recordIn != null)
            {
                details = recordIn.Split(',');
                string userName = details[0];
                string email = details[1];
                string password = details[2];
                members.Add(new Member
                {
                    UserName = userName,
                    Email = email,
                    Password = password
                }
                    );
                recordIn = reader.ReadLine();
            }
            reader.Close();
            inFile.Close();
        }

        private void NewMemberJoin(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            NewMember addMember = new NewMember();
            addMember.Owner = this;
            addMember.ShowDialog();
            Close();
        }

        private void ExitMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;
            loginWindow.ShowDialog();
            Close();

        }
    }
}
