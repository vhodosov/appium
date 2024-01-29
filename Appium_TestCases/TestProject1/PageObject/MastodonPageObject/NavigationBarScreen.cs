using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;
using TestProject1.Enums;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class NavigationBarScreen : Screen
    {
        private const string NavigationBarElementLocator = "org.joinmastodon.android:id/tab_{0}";

        public NavigationBarScreen(By locator, string name) : base(locator, name)
        {
        }

        public void GoTo(NavigationTypes tab)
        {
            GetNavigationButton(tab).Click();
        }

        private IButton GetNavigationButton(NavigationTypes tab)
        {
            return ElementFactory.GetButton(By.Id(string.Format(NavigationBarElementLocator, tab.ToString())), $"Button {tab}");
        }
    }
}
