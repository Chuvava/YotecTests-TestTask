using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.OurProductsPages;


namespace YotecTestsV1.TestScript.MenuNavigation
{
    [TestClass]
    public class OurProductsSubMenuNavigaton : BaseTestClass
    {
        PurchasingPage purchasingPage;
        SilosPage silosPage;
        TruckBodiesPage truckBodiesPage;

        [TestMethod, TestCategory("MenuNavigation")]
        public void PurchasingNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.OurProductsMenu, homePage.PurchasingSubMenu);
                purchasingPage = new PurchasingPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(purchasingPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, purchasingPage.Url));
                Logger.Info("Url is correct");

                actualBreadcrumb = purchasingPage.GetBreadcrumbString();
                Assert.AreEqual(purchasingPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, purchasingPage.Breadcrumb));
                Logger.Info("Breadcrumb is correct");
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
        public void SilosNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.OurProductsMenu, homePage.SilosSubMenu);
                silosPage = new SilosPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(silosPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, silosPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = silosPage.GetBreadcrumbString();
                Assert.AreEqual(silosPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, silosPage.Breadcrumb));
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
        public void TruckBodiesNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.OurProductsMenu, homePage.TruckBodiesSubMenu);
                truckBodiesPage = new TruckBodiesPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(truckBodiesPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, truckBodiesPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = truckBodiesPage.GetBreadcrumbString();
                Assert.AreEqual(truckBodiesPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, truckBodiesPage.Breadcrumb));
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
