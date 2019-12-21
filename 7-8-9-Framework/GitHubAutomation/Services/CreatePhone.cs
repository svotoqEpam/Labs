using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class CreatePhone
    {
        public static Phone WithPhoneName()
        {
            return new Phone(TestDataReader.GetTestData("PhoneName"));
        }

        public static Phone WithPhoneComparisonParameter()
        {
            return new Phone(TestDataReader.GetTestData("PhoneName"), TestDataReader.GetTestData("ComparisonParameter"));
        }
    }
}
