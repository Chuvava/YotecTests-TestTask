using OpenQA.Selenium;
using System;
using System.Threading;
using System.Threading.Tasks;
using YotecTestsV1.Settings;


namespace YotecTestsV1.ComponentHelper
{
    public class WindowHelper : BaseHelper
    {

        public static string GetUrl()
        {
            Logger.Info("Get url of the page: " + ObjectRepository.Driver.Url);
            return ObjectRepository.Driver.Url;           
        }

        public static void BrowserMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
            Logger.Info("Browser Maximize");
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
            Logger.Info("Refresh Page");
        }

        public static void BannerListener(By by, int interval = 1000)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    while (ObjectRepository.Driver != null)
                    {
                        try
                        {
                            GenericHelper.GetElement(by);
                            GenericHelper.GetElement(by).Click();
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(interval);
                        }
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
