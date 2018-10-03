using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using YotecTestsV1.Settings;


namespace YotecTestsV1.ComponentHelper
{

    public class GenericHelper : BaseHelper
    {
        static WebDriverWait wait;

        public static void ClickOnElement(By locator)
        {
            GetElement(locator).Click();
            Logger.Info("Click on element: " + locator.ToString());
        }

        public static bool IsElementPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
            {
                return WaitForElement(locator);
            }
        }

        public static IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            if(ObjectRepository.Driver.FindElements(locator).Count > 0)
                element = WaitForElement(locator);
            IReadOnlyCollection<IWebElement> list = ObjectRepository.Driver.FindElements(locator);
            return list;
        }

        private static IWebElement WaitForElement(By locator)
        {
            wait = new WebDriverWait(ObjectRepository.Driver,
                    TimeSpan.FromSeconds(ObjectRepository.Config.GetExplicitlementLoadTimeout()));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));            
            return wait.Until((d) =>
            {
                return d.FindElement(locator);
            });

            throw new NoSuchElementException("Element was not found: " + locator.ToString());
        }

        public static void WaitForVisibilityOfElement(By locator)
        {
            Logger.Info("Waiting for visibility of element: " + locator.ToString());
            wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(ObjectRepository.Config.GetExplicitlementLoadTimeout()));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            bool flag = wait.Until((d) =>
            {
                return d.FindElement(locator).Displayed;
            });
        }

        public static void TakeScreenShot(string fileName = "Screen")
        {
            Logger.Info("Taking ScreenShot");
            if (!Directory.Exists(ObjectRepository.Config.GetScreenShotsPath()))
                Directory.CreateDirectory(ObjectRepository.Config.GetScreenShotsPath());
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            if (fileName.Equals("Screen"))
            {
                fileName = ObjectRepository.Config.GetScreenShotsPath() + fileName + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                return;
            }
            fileName = ObjectRepository.Config.GetScreenShotsPath() + fileName;
            screen.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }
    }
}
