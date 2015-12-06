using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class User
    {
        public string  UserName { get; set; }
        public string Password { get; set; }
        public bool Login { get; set; }

        public User(string username,string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public void VertifyLogin()
        {
            this.Login = true;
        }
    }
}
