using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.LocationSearchPages;


namespace YotecTestsV1.TestScript.MenuNavigation
{
    [TestClass]
    public class LocationSearchSubMenuNavigation : BaseTestClass
    {
        TestPage testPage;
        DealerPage dealerPage;

        [TestMethod, TestCategory("MenuNavigation")]
        public void TestNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.TestSubMenu);
                testPage = new TestPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(testPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, testPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = testPage.GetBreadcrumbString();
                Assert.AreEqual(testPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, testPage.Breadcrumb));
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
        public void DealerNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(dealerPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, dealerPage.Url));
                Logger.Info("ASSERT - Url is correct");
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
