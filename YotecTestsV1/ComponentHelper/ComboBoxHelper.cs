using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace YotecTestsV1.ComponentHelper
{
    public class ComboBoxHelper : BaseHelper
    {
        private static SelectElement select;

        public static void SelectElement(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);
            Logger.Info("Select option with index: " + index + " in ComboBox: " + locator.ToString());
        }

        public static void SelectElement(By locator, string visibleText)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByText(visibleText);
            Logger.Info("Select option with text: " + visibleText + " in ComboBox: " + locator.ToString());
        }
    }
}
