using log4net;
using OpenQA.Selenium;


namespace YotecTestsV1.ComponentHelper
{
    public class BaseHelper
    {
        protected static ILog Logger = Log4NetHelper.GetLogger(typeof(BaseHelper));
        protected static IWebElement element;
    }
}
