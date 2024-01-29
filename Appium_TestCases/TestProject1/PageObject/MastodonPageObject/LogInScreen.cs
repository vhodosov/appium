using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class LogInScreen : Screen
    {
        private readonly ITextBox userEmailTextBox = ElementFactory.GetTextBox(By.XPath("//android.widget.EditText[@resource-id='user_email']"), "User email text box", ElementState.ExistsInAnyState);
        private readonly ITextBox passwordTextBox = ElementFactory.GetTextBox(By.XPath("//android.widget.EditText[@resource-id='user_password']"), "Search text box", ElementState.ExistsInAnyState);
        private readonly IButton logInButton = ElementFactory.GetButton(By.XPath("//android.widget.Button[@text='Log in']"), "LogIn button", ElementState.ExistsInAnyState);

        public LogInScreen() : base(By.XPath("//android.webkit.WebView[@text='Log in - Mastodon']"), "Log In screen")
        {
        }

        public void SetEmail(string email) => userEmailTextBox.Type(email);

        public void SetPassword(string password) => passwordTextBox.Type(password);

        public void ClickLogIn() => logInButton.Click();
    }
}
