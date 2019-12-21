using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class Location
    {
        public string Region { get; set; }

        public Location(string region)
        {
            Region = region;
        }
    }
}
