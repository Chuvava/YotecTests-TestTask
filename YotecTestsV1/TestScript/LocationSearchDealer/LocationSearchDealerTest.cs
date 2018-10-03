using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.PageObject.LocationSearchPages;


namespace YotecTestsV1.TestScript.LocationSearchDealer
{
    [TestClass]
    public class LocationSearchDealerTest : BaseTestClass
    {
        DealerPage dealerPage;
        double actualSearchRadius;
        List<double> distancesForCompanies;
        List<string> servicesOfCompanies;

        public TestContext TestContext { get; set; }
        

        [TestMethod, TestCategory("DealerPage")]
        public void AllCheckBoxesCheckedCorrectly()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();
                CheckBoxHelper.CheckedAllCheckBoxes(dealerPage.CommonCheckBoxLocator);

                Assert.IsTrue(CheckBoxHelper.AreCheckBoxesChecked(dealerPage.CommonCheckBoxLocator), 
                    "Not all checkboxes are checked");
                Logger.Info("ASSERT - All checkboxes are checked");
            }
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("DealerPage")]
        public void ClearButtonWorksCorrectly()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();

                TextBoxHelper.TypeInTextBox(dealerPage.SearchTextBox, "some random value");
                TextBoxHelper.TypeInTextBox(dealerPage.LocationTextBox, "some random area");
                CheckBoxHelper.CheckedAllCheckBoxes(dealerPage.CommonCheckBoxLocator);
                GenericHelper.ClickOnElement(dealerPage.ClearButton);
                actualSearchRadius = dealerPage.GetSearchRadiusValue();

                Assert.AreEqual(dealerPage.ClearedSearchRadius, actualSearchRadius,
                    string.Format("Actual search radius: <{0}> is not equal to expected: <{1}>", actualSearchRadius, dealerPage.ClearedSearchRadius));
                Logger.Info("ASSERT - Search radius is cleared");

                Assert.IsTrue(TextBoxHelper.IsTextBoxEmpty(dealerPage.SearchTextBox), 
                    string.Format("Textbox: {0} is not empty", dealerPage.SearchTextBox));
                Logger.Info("ASSERT - Textbox " + dealerPage.SearchTextBox.ToString() + " is empty");

                Assert.IsTrue(TextBoxHelper.IsTextBoxEmpty(dealerPage.LocationTextBox),
                    string.Format("Textbox: {0} is not empty", dealerPage.LocationTextBox));
                Logger.Info("ASSERT - Textbox " + dealerPage.LocationTextBox.ToString() + " is empty");

                Assert.IsTrue(CheckBoxHelper.AreCheckBoxesUnchecked(dealerPage.CommonCheckBoxLocator), "Not all checkboxes are unchecked");
                Logger.Info("ASSERT - All checkboxes are unchecked");

            }
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("DealerPage")]
        public void DistancesInResultsNoLongerThanInitialSearchRadius()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();
                GenericHelper.WaitForVisibilityOfElement(dealerPage.ResultsPanel);
                actualSearchRadius = dealerPage.GetSearchRadiusValue();
                distancesForCompanies = dealerPage.GetDistancesOfEveryCompany(dealerPage.DistanceForCompany);

                Assert.IsTrue(dealerPage.AreAllDistancesInResultsNotMoreThanSearchRadius(distancesForCompanies, actualSearchRadius),
                    string.Format("Some of distance for company in results are bigger than actual initial radius: <{0}>", actualSearchRadius));
                Logger.Info("ASSERT - Distances in results are not longer than initial search radius");
            }
            catch(Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("DealerPage")]
        public void DistanceInResultsNoLongerThanSetSearchRadius()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();
                dealerPage.SetRandomSearchRadius();
                actualSearchRadius = dealerPage.GetSearchRadiusValue();
                GenericHelper.WaitForVisibilityOfElement(dealerPage.ResultsPanel);
                distancesForCompanies = dealerPage.GetDistancesOfEveryCompany(dealerPage.DistanceForCompany);

                Assert.IsTrue(dealerPage.AreAllDistancesInResultsNotMoreThanSearchRadius(distancesForCompanies, actualSearchRadius),
                    string.Format("Some of distance for company in results are bigger than actual set search radius: <{0}>", actualSearchRadius));
                Logger.Info("ASSERT - Distances in results are not longer than actual set search radius: " + actualSearchRadius);
            }
            catch(Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("DealerPage")]
        public void ResultsLineCorrectlyDisplaysNumberOfCompanies()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();
                GenericHelper.WaitForVisibilityOfElement(dealerPage.ResultsPanel);
                int countFromResultsLine = dealerPage.GetCountFromResultsLine();
                int countOfCompanies = dealerPage.GetTotalCountOfCompanies();

                Assert.AreEqual(countOfCompanies, countFromResultsLine,
                    string.Format("Count from results line: <{0}> is not equal to actual number of companies: <{1}>", countFromResultsLine, countOfCompanies));
                Logger.Info("Count in results line is correct");
            }
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);
                throw;
            }
        }

        [TestMethod, TestCategory("DealerPage")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData/locationTypeCheckboxes.xml",
            "LocationType",
            DataAccessMethod.Sequential)]
        public void LocationTypeCheckBoxesWorksCorrectly()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.LocationSearchMenu, homePage.DealerSubMenu);
                dealerPage = new DealerPage();
                string locationTypeCheckBox = Convert.ToString(TestContext.DataRow["xpath"]);
                string nameOfCheckBox = Convert.ToString(TestContext.DataRow["name"]);
                CheckBoxHelper.CheckedCheckBox(By.XPath(locationTypeCheckBox));
                GenericHelper.WaitForVisibilityOfElement(dealerPage.ResultsPanel);
                servicesOfCompanies = dealerPage.GetServicesOfEveryCompany(dealerPage.ServicesOfCompany);

                Assert.IsTrue(dealerPage.DoAllCompaniesHaveServiceWithCheckedCheckbox(nameOfCheckBox),
                    string.Format("Not all companies have service: <{0}>", nameOfCheckBox));
                Logger.Info("ASSERT - All companies have service: " + nameOfCheckBox);
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
