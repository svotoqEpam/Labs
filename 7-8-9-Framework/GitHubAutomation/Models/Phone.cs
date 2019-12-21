using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class Phone
    {
        public string Name { get; set; }
        public string ComparisonParameter { get; set; }

        public Phone(string name, string comparisonParameter = "")
        {
            Name = name;
            ComparisonParameter = comparisonParameter;
        }
    }
}
