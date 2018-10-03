using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.TraditionOfInovationPages;


namespace YotecTestsV1.TestScript.MenuNavigation
{
    [TestClass]
    public class TraditionOfInovationSubMenuNavigation : BaseTestClass
    {
        FutureFocusPage futureFocusPage;
        PatentsPage patentsPage;
        ResponsibilityPage responsibilityPage;

        [TestMethod, TestCategory("MenuNavigation")]
        public void FutureFocusNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.TraditionOfInovationMenu, homePage.FutureFocusSubMenu);
                futureFocusPage = new FutureFocusPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(futureFocusPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, futureFocusPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = futureFocusPage.GetBreadcrumbString();
                Assert.AreEqual(futureFocusPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, futureFocusPage.Breadcrumb));
                Logger.Info("ASSERT - Breadcrumb is correct");
            }            
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("MenuNavigation")]
        public void PatentsNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.TraditionOfInovationMenu, homePage.PatentsSubMenu);
                patentsPage = new PatentsPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(patentsPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, patentsPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = patentsPage.GetBreadcrumbString();
                Assert.AreEqual(patentsPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, patentsPage.Breadcrumb));
                Logger.Info("ASSERT - Breadcrumb is correct");
            }
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("MenuNavigation")]
        public void ResponsibilityNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.TraditionOfInovationMenu, homePage.ResponsibilitySubMenu);
                responsibilityPage = new ResponsibilityPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(responsibilityPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, responsibilityPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = responsibilityPage.GetBreadcrumbString();
                Assert.AreEqual(responsibilityPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, responsibilityPage.Breadcrumb));
                Logger.Info("ASSERT - Breadcrumb is correct");
            }
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }
    }
}
