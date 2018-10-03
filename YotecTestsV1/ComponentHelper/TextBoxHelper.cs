using OpenQA.Selenium;


namespace YotecTestsV1.ComponentHelper
{
    public class TextBoxHelper : BaseHelper
    {

        public static void TypeInTextBox(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();
            element.SendKeys(text);
            Logger.Info("Type in textbox: " + locator.ToString() + " with value: " + text);
        }

        public static bool IsTextBoxEmpty(By locator)
        {
            element = GenericHelper.GetElement(locator);
            Logger.Info("Checking if Text Box empty or not: " + locator.ToString());
            if(element.GetAttribute("value") == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
