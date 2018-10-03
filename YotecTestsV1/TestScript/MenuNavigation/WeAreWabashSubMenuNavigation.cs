using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.WeAreWabashPages;


namespace YotecTestsV1.TestScript.MenuNavigation
{
    [TestClass]
    public class WeAreWabashSubMenuNavigation : BaseTestClass
    {
        OurHeritagePage ourHeritagePage;
        TeamworkPage teamworkPage;
        SupportPage supportPage;

        [TestMethod, TestCategory("MenuNavigation")]
        public void OurHeritageNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.WeAreWabashMenu, homePage.OurHeritageSubMenu);
                ourHeritagePage = new OurHeritagePage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(ourHeritagePage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, ourHeritagePage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = ourHeritagePage.GetBreadcrumbString();
                Assert.AreEqual(ourHeritagePage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, ourHeritagePage.Breadcrumb));
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
        public void TeamworkNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.WeAreWabashMenu, homePage.TeamworkSubMenu);
                teamworkPage = new TeamworkPage();

                actualUrl = WindowHelper.GetUrl();            
                Assert.AreEqual(teamworkPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, teamworkPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = teamworkPage.GetBreadcrumbString();
                Assert.AreEqual(teamworkPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, teamworkPage.Breadcrumb));
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
        public void SupportNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.WeAreWabashMenu, homePage.SupportSubMenu);
                supportPage = new SupportPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(supportPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, supportPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = supportPage.GetBreadcrumbString();
                Assert.AreEqual(supportPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, supportPage.Breadcrumb));
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
