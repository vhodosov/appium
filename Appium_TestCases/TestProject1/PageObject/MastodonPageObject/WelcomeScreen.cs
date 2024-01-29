using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class WelcomeScreen : Screen
    {
        private readonly IButton logInButton = ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/btn_log_in"), "Log in button");

        public WelcomeScreen() : base(By.Id("org.joinmastodon.android:id/blue_fill"), "Welcome screen")
        {
        }

        public void ClickLogIn() => logInButton.Click();
    }
}
