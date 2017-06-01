using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Unit.Tests.Models
{
    public class RegistrationUser
    {
        private string key;
        private string email;
        private string fullName;
        private string password;
        private string confirmPassword;


        public RegistrationUser(
                                string key,
                                string email,
                                string fullName,
                                string password,
                                string confirmPassword

                              )
        {

            this.key = key;
            this.email = email;
            this.fullName = fullName;
            this.password = password;
            this.confirmPassword = confirmPassword;

        }

        public string Key
        {
            get { return this.key; }
            set { this.Key = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

    }
}