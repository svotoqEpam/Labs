using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string WrongPasswordMessage { get; set; }

        public User(string name, string password, string wrongPasswordMessage)
        {
            Name = name;
            Password = password;
            WrongPasswordMessage = wrongPasswordMessage;
        }
    }
}
