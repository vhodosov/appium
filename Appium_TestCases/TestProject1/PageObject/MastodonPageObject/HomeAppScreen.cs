using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class HomeAppScreen : NavigationBarScreen
    {
        public HomeAppScreen() : base(By.XPath("//android.widget.TextView[@text='Home']"), "Home app Screen")
        {
        }
    }
}
