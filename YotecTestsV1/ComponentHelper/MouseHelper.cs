using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using YotecTestsV1.Settings;


namespace YotecTestsV1.ComponentHelper
{
    public class MouseHelper : BaseHelper
    {
        static Actions actions;

        public static void Hover(By locator)
        {
            element = GenericHelper.GetElement(locator);
            actions = new Actions(ObjectRepository.Driver);
            actions.MoveToElement(element).Build().Perform();
        }
        
        public static void HoverAndClick(By locator)
        {
            element = GenericHelper.GetElement(locator);
            actions = new Actions(ObjectRepository.Driver);
            actions.MoveToElement(element).Click().Build().Perform();
        }

        public static void DragAndMoveToRelativeCoordinates(By locator, int coordX, int coordY = 0)
        {
            actions = new Actions(ObjectRepository.Driver);
            IWebElement toggle = GenericHelper.GetElement(locator);
            actions.MoveToElement(toggle).ClickAndHold(toggle).MoveByOffset(coordX, coordY).Release().Build().Perform();
        }
    }
}
