using GitHubAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Services
{
    class CreateUser
    {
        public static User WithLogin()
        {
            return new User(TestDataReader.GetTestData("UserName"),
                TestDataReader.GetTestData("UserPassword"),
                TestDataReader.GetTestData("WrongPasswordMessage"));
        }
    }
}
