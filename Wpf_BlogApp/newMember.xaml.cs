using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for newMember.xaml
    /// </summary>
    public partial class NewMember : Window
    {
        
        public NewMember()
        {
            InitializeComponent();
            
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;
            main.Visibility = Visibility.Visible;
            string newMemberEmail = txtEmail.Text;

            int memberCount = 0;
            foreach (var member in main.members)
            {
                if (member.Email.ToString() != newMemberEmail)
                {

                    if (memberCount == main.members.Count() - 1)
                    {
                        string newMemberUserName = txtUserName.Text;
                        string newMemberpassword = txtPassword.Text;

                        main.members.Add(new Member
                        {
                            UserName = newMemberUserName,
                            Email = newMemberEmail,
                            Password = newMemberpassword
                        });
                        FileStream outFile = new FileStream("MembersList.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(outFile);
                        writer.WriteLine(newMemberUserName+","+newMemberEmail+","+newMemberpassword);
                        MessageBox.Show("New user added");
                        writer.Close();
                        outFile.Close();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("This email has already been taken");
                    break;
                }
                memberCount++;
            }
            
            this.Close();
            
        }

        


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = this.Owner as MainWindow;
            main.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
