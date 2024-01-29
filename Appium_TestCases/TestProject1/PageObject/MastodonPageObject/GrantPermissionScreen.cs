using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class GrantPermissionScreen : Screen
    {
        private readonly IButton allowButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@text='Allow']"), "allow button");

        public GrantPermissionScreen() : base(By.Id("com.android.permissioncontroller:id/grant_dialog"), "Grant Permission Screen")
        {
        }

        public void ClickAllow() => allowButton.Click();
    }
}
