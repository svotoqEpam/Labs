using GitHubAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Services
{
    class CreateLocation
    {
        public static Location WithRegion()
        {
            return new Location(TestDataReader.GetTestData("Region"));
        }
    }
}
