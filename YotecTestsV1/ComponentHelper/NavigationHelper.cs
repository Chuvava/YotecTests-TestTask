using YotecTestsV1.Settings;


namespace YotecTestsV1.ComponentHelper
{
    public class NavigationHelper : BaseHelper
    {

        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(Url);
            Logger.Info("Navigate to url: " + Url);
        }
    }
}
