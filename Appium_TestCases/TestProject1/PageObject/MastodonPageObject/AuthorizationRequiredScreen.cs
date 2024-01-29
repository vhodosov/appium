using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class AuthorizationRequiredScreen : Screen
    {
        private readonly IButton authorizeButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@text='Authorize']"), "authorize button");

        public AuthorizationRequiredScreen() : base(By.XPath("//android.webkit.WebView[@text='Authorization required - Mastodon']"), "authorize screen")
        {
        }

        public void ClickAuthorize() => authorizeButton.Click();
    }
}
