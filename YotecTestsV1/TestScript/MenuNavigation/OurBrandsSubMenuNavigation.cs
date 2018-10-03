using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.OurBrandsPages;


namespace YotecTestsV1.TestScript.MenuNavigation
{
    [TestClass]
    public class OurBrandsSubMenuNavigation : BaseTestClass
    {
        BeallPage beallPage;
        ProgressTankPage progressTankPage;
        SupremePage supremePage;

        [TestMethod, TestCategory("MenuNavigation")]
        public void BeallNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.OurBrandsMenu, homePage.BeallSubMenu);
                beallPage = new BeallPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(beallPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, beallPage.Url));
                Logger.Info("Url is correct");
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
        public void ProgressTankNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.OurBrandsMenu, homePage.ProgressTankSubMenu);
                progressTankPage = new ProgressTankPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(progressTankPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, progressTankPage.Url));
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

        [TestMethod, TestCategory("MenuNavigation")]
        public void SupremeNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.OurBrandsMenu, homePage.SupremeSubMenu);
                supremePage = new SupremePage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(supremePage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, supremePage.Url));
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
