using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.WorkWithWabashPages;


namespace YotecTestsV1.TestScript.MenuNavigation
{
    [TestClass]
    public class WorkWithWabashSubMenuNavigation : BaseTestClass
    {
        BenefitsPage benefitsPage;
        CareersPage careersPage;

        [TestMethod, TestCategory("MenuNavigation")]
        public void BenefitsNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.WorkWithWabashMenu, homePage.BenefitsSubMenu);
                benefitsPage = new BenefitsPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(benefitsPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, benefitsPage.Url));
                Logger.Info("Url is correct");

                actualBreadcrumb = benefitsPage.GetBreadcrumbString();
                Assert.AreEqual(benefitsPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, benefitsPage.Breadcrumb));
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
        public void CareersNavigation()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.WorkWithWabashMenu, homePage.CareersSubMenu);
                careersPage = new CareersPage();

                actualUrl = WindowHelper.GetUrl();
                Assert.AreEqual(careersPage.Url, actualUrl,
                    string.Format("Actual url: <{0}> is not equal to expected: <{1}>", actualUrl, careersPage.Url));
                Logger.Info("ASSERT - Url is correct");

                actualBreadcrumb = careersPage.GetBreadcrumbString();
                Assert.AreEqual(careersPage.Breadcrumb, actualBreadcrumb,
                    string.Format("Actual breadcrumb: <{0}> is not equal to expected: <{1}>", actualBreadcrumb, careersPage.Breadcrumb));
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
