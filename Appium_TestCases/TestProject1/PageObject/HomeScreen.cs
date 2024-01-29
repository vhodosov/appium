using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace TestProject1.PageObject
{
    public class HomeScreen : Screen
    {
        private readonly IButton mastodonAppButton = ElementFactory.GetButton(By.XPath("//android.widget.TextView[@text='Mastodon']"), "Mastodon app button");

        public HomeScreen() : base(By.XPath("//android.view.View[@content-desc='Home']"), "Home screen")
        {
        }

        public void ClickMastodonAppButton() => mastodonAppButton.Click();
    }
}
