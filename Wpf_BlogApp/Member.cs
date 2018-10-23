using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_BlogApp
{
    public class Member
    {
        public string UserName { get; set; }
       
        public string Email { get; set; }
       
        public string Password { get; set; }


        public Member() { }

        public Member(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        
    }
}
