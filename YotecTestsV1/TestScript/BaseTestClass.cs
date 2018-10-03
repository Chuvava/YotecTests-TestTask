using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.Configuration;
using YotecTestsV1.PageObject;
using YotecTestsV1.Settings;


namespace YotecTestsV1.BaseClasses
{
    [TestClass]
    public class BaseTestClass
    {
        protected static ILog Logger;
        protected HomePage homePage;
        protected string actualUrl;
        protected string actualBreadcrumb;
        

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            Logger.Info("Initialize Chrome Driver");
            return driver;
        }

        [TestInitialize]
        public void TestBefore()
        {
            try
            {
                Logger = Log4NetHelper.GetLogger(typeof(BaseTestClass));
                ObjectRepository.Config = new AppConfigReader();
                ObjectRepository.Driver = GetChromeDriver();

                ObjectRepository.Driver.Manage().Timeouts().PageLoad =
                    TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeout());

                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
                    TimeSpan.FromSeconds(ObjectRepository.Config.GetImplicitElementLoadTimeout());

                WindowHelper.BrowserMaximize();
                NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());

                homePage = new HomePage();
                WindowHelper.BannerListener(homePage.ContinueTrialVersion); //comment for running in debug mode
            }            
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestCleanup]
        public void TestAfter()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                Logger.Info("Driver Close");
                ObjectRepository.Driver.Quit();
                Logger.Info("Driver Quit");
                ObjectRepository.Driver = null;
            }
        }
    }
}
