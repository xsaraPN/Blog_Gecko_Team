using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Models
{
    public class LogInUser
    {
        private string key;
        private string email;
        private string password;


        public LogInUser(
                         string key,
                         string email,
                         string password
                        )
        {
            this.key = key;
            this.email = email;
            this.password = password;
        }
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}