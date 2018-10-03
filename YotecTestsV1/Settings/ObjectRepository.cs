using OpenQA.Selenium;
using YotecTestsV1.Configuration;


namespace YotecTestsV1.Settings
{
    public class ObjectRepository
    {
        public static AppConfigReader Config { get; set; }

        public static IWebDriver Driver { get; set; }
    }
}
