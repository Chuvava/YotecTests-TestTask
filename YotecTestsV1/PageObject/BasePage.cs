using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.Settings;


namespace YotecTestsV1.PageObject
{
    public class BasePage
    {
        ILog Logger = Log4NetHelper.GetLogger(typeof(BasePage));
        public By ContinueTrialVersion => By.XPath("//a[text()= 'Continue']");

        #region Breadcrumb
        public By breadcrumbLocator = By.ClassName("rsmLink");
        #endregion

        #region Menu
        public By WeAreWabashMenu => By.XPath("//li[@class='dropdown']//a[@href='/we-are-wabash']");
        public By TraditionOfInovationMenu => By.XPath("//li[@class='dropdown']//a[@href='/tradition-of-innovation']");
        public By OurProductsMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-products']");
        public By OurBrandsMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-brands']");
        public By WorkWithWabashMenu => By.XPath("//li[@class='dropdown']//a[@href='/work-with-wabash']");
        public By LocationSearchMenu => By.XPath("//li[@class='dropdown']//a[@href='/location-search']");
        #endregion

        #region SubMenu - We Are Wabash
        public By OurHeritageSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/we-are-wabash/our-heritage']");
        public By SupportSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/we-are-wabash/support']");
        public By TeamworkSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/we-are-wabash/teamwork']");
        #endregion

        #region SubMenu - Tradition Of Inovation
        public By FutureFocusSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/tradition-of-innovation/future-focus']");
        public By PatentsSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/tradition-of-innovation/patents-and-r-d-test-center']");
        public By ResponsibilitySubMenu => By.XPath("//li[@class='dropdown']//a[@href='/tradition-of-innovation/responsibility-to-our-customers']");
        #endregion

        #region SubMenu - Our Products
        public By PurchasingSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-products/purchasing']");
        public By SilosSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-products/silos']");
        public By TruckBodiesSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-products/truck-bodies']");
        #endregion

        #region SubMenu - Our Brands
        public By BeallSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-brands/beall']");
        public By ProgressTankSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-brands/progress-tank']");
        public By SupremeSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/our-brands/supreme']");
        #endregion

        #region SubMenu - Work With Wabash
        public By BenefitsSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/work-with-wabash/benefits']");
        public By CareersSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/work-with-wabash/careers']");
        #endregion

        #region SubMenu - Location Search
        public By DealerSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/location-search/dealer']");
        public By TestSubMenu => By.XPath("//li[@class='dropdown']//a[@href='/location-search/test']");
        #endregion

        #region Navigation
        public void NavigateToSubMenu(By menu, By subMenu)
        {
            MouseHelper.Hover(menu);
            MouseHelper.HoverAndClick(subMenu);
            Logger.Info("Navigate to submenu: " + subMenu + " from menu: " + menu);
        }
        #endregion

        #region Action
        public string GetBreadcrumbString()
        {
            string breadcrumbString = "";
            IReadOnlyCollection<IWebElement> breadcrumbList = ObjectRepository.Driver.FindElements(breadcrumbLocator);
            foreach (var el in breadcrumbList)
            {
                breadcrumbString = breadcrumbString + ">" + el.Text;
            }
            Logger.Info("Get breadcrumb of the page: " + breadcrumbString);
            return breadcrumbString;
        }
        #endregion

    }
}
