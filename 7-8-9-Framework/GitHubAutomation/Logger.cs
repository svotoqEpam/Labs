using log4net;
using log4net.Config;
using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using GitHubAutomation.Pages;
using GitHubAutomation.Driver;

namespace GitHubAutomation
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger(typeof(Logger));
        public static ILog Log
        {
            get { return log; }
        }
    }
}
