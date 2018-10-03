using OpenQA.Selenium;
using System.Collections.Generic;


namespace YotecTestsV1.ComponentHelper
{
    public class CheckBoxHelper : BaseHelper
    {
        private static IReadOnlyCollection<IWebElement> elements;

        public static void CheckedCheckBox(By locator)
        {
            GenericHelper.ClickOnElement(locator);
        }

        public static void CheckedAllCheckBoxes(By commonLocator)
        {
            elements = GenericHelper.GetElements(commonLocator);

            foreach(IWebElement el in elements)
            {
                el.Click();
                Logger.Info("Click on the checkbox" );
            }
        }

        public static bool IsCheckBoxChecked(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string classValue = element.GetAttribute("class");
            Logger.Info("Checking if checkbox checked or not : " + locator.ToString());
            if (classValue.Contains("checked"))
                return true;
            return false;
        }

        public static bool AreCheckBoxesChecked(By commonLocator)
        {
            elements = GenericHelper.GetElements(commonLocator);

            foreach(IWebElement el in elements)
            {
                string classValue = el.GetAttribute("class");
                if (!classValue.Contains("checked"))
                    return false;
            }
            return true;
        }

        public static bool AreCheckBoxesUnchecked(By commonLocator)
        {
            elements = GenericHelper.GetElements(commonLocator);

            foreach (IWebElement el in elements)
            {
                string classValue = el.GetAttribute("class");
                if (classValue.Contains("checked"))
                    return false;
            }
            return true;
        }
    }
}
