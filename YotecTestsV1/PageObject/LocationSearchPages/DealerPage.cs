using log4net;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.Settings;

namespace YotecTestsV1.PageObject.LocationSearchPages
{
    public class DealerPage : BasePage
    {
        List<double> distances;
        List<string> servicesOfCompanies;
        public string Url => "http://qa.yotec.net/location-search/dealer";
        public string Breadcrumb => ">Home>Location Search>Dealer";
        public double ClearedSearchRadius => 1000;
        private static ILog Logger = Log4NetHelper.GetLogger(typeof(DealerPage));
        private int i = 0;
        int searchRadius;
        int coord;

        #region WebElement
        public By ResultsPanel => By.ClassName("w__info_panel");
        public By SearchTextBox => By.Id("CompanyName");
        public By LocationTextBox => By.Id("ContentPlaceHolderContent_C001_txtSourceZip");
        public By ClearButton => By.Id("clear");
        public By SearchRadiusValue => By.XPath("//div[@class='rs_tooltip']/span");
        public By DistanceForCompany => By.XPath("//div[@class='w__dealer_distance']/div");
        public By ServicesOfCompany => By.ClassName("service");
        public By CountOfResultsLine => By.Id("ContentPlaceHolderContent_C001_lblDealerCount");
        public By DealerItem => By.ClassName("w__dealer_item");
        public By Toggle => By.XPath("//div[contains(@class, 'noUi-handle')]");

        public By BrennerCheckBox => By.XPath("//span[text() = 'Brenner']/preceding-sibling::span");
        public By WabashCheckBox => By.XPath("//span[text() = 'Wabash National Trailers']/preceding-sibling::span");
        public By WalkerCheckBox => By.XPath("//span[text() = 'Walker']/preceding-sibling::span");
        public By BeallCheckBox => By.XPath("//span[text() = 'Beall']/preceding-sibling::span");
        public By BensonCheckBox => By.XPath("//span[text() = 'Benson']/preceding-sibling::span");
        public By TranscraftCheckBox => By.XPath("//span[text() = 'Transcraft']/preceding-sibling::span");
        public By BulkCheckBox => By.XPath("//span[text() = 'Bulk']/preceding-sibling::span");

        public By SalesCheckBox => By.XPath("//span[text() = 'Sales']/preceding-sibling::span");
        public By WarrantyCheckBox => By.XPath("//span[text() = 'Warranty']/preceding-sibling::span");
        public By ManufacturingCheckBox => By.XPath("//span[text() = 'Manufacturing']/preceding-sibling::span");
        public By CorporateCheckBox => By.XPath("//span[text() = 'Corporate']/preceding-sibling::span");
        public By ServiceCheckBox => By.XPath("//span[text() = 'Service']/preceding-sibling::span");
        public By PartsCheckBox => By.XPath("//span[text() = 'Parts']/preceding-sibling::span");
        public By CommonCheckBoxLocator => By.XPath("//span[@class='rbText']/preceding-sibling::span");
        #endregion

        #region Action
        public List<double> GetDistancesOfEveryCompany(By distanceLocator)
        {
            IReadOnlyCollection<IWebElement> elements = GenericHelper.GetElements(distanceLocator);
            distances = new List<double>();
            foreach(var el in elements)
            {
                double distanceValue = Convert.ToDouble(el.Text.Replace(" miles", ""));
                distances.Add(distanceValue);
            }

            return distances;
        }

        public double GetSearchRadiusValue()
        {
            double searchRadius = Convert.ToDouble(GenericHelper.GetElement(SearchRadiusValue).Text.Replace(" miles", "").Replace(".", ","));            
            return searchRadius;              
        }

        public bool AreAllDistancesInResultsNotMoreThanSearchRadius(List<double> results, double searchRadius)
        {
            i = 0;
            foreach(double distance in results)
            {
                if(distance > searchRadius)
                {
                    Logger.Error(string.Format("Distance: <{0}> for company number <{1}> longer than search radius: {2}", distance, i + 1, searchRadius));
                    return false;
                }
                i++;
            }
            return true;
        }

        public List<string> GetServicesOfEveryCompany(By serviceLocator)
        {
            IReadOnlyCollection<IWebElement> services = GenericHelper.GetElements(By.ClassName("service"));
            servicesOfCompanies = new List<string>();
            string serviceOfOneCompany = "";
            foreach (IWebElement el in services)
            {
                for (int i = 0; i < el.FindElements(By.TagName("strong")).Count; i++)
                {
                    serviceOfOneCompany += el.FindElements(By.TagName("strong"))[i].Text;
                }
                servicesOfCompanies.Add(serviceOfOneCompany);
            }
            return servicesOfCompanies;
        }

        public bool DoAllCompaniesHaveServiceWithCheckedCheckbox(string locationType)
        {
            i = 0;
            foreach (string service in servicesOfCompanies)
            {
                if (!service.Contains(locationType))
                {
                    Logger.Info(string.Format("Company number: <{0}> doesn't contain service: <{1}>", i + 1, locationType));
                    return false;
                }
                i++;
            }
            return true;
        }

        public int GetTotalCountOfCompanies()
        {
            return GenericHelper.GetElements(DealerItem).Count;
        }

        public int GetCountFromResultsLine()
        {
            int count = Convert.ToInt32(GenericHelper.GetElement(CountOfResultsLine).Text.Replace(" results near Indiana", ""));
            return count;
        }

        public void SetRandomSearchRadius()
        {
            searchRadius = GenerateRandomSearchRadiusValueInMiles();
            coord = ConvertMilesToRelativeCoordinatesForRadiusToggle(searchRadius);

            MouseHelper.DragAndMoveToRelativeCoordinates(Toggle, coord);
        }

        private int ConvertMilesToRelativeCoordinatesForRadiusToggle(int miles)
        {
            double temp;

            temp = 1000 / (miles - 500);
            coord = Convert.ToInt32(250 / temp);

            return coord;
        }

        private int GenerateRandomSearchRadiusValueInMiles()
        {
            Random rand = new Random();
            int searchRadius = rand.Next(1, 250) * 4;

            return searchRadius;
        }
        #endregion

    }
}
