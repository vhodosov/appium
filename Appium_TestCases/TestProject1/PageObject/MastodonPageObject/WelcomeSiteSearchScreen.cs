using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Appium.Mobile.Screens;
using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class WelcomeSiteSearchScreen : Screen
    {
        private const string SearchElementLocator = "//android.widget.TextView[@text='{0}']";
        private readonly ITextBox searchTextBox = ElementFactory.GetTextBox(By.Id("org.joinmastodon.android:id/search_edit"), "Search text box");
        private readonly IButton nextButton = ElementFactory.GetButton(By.Id("org.joinmastodon.android:id/btn_next"), "Next button");

        public WelcomeSiteSearchScreen() : base(By.Id("org.joinmastodon.android:id/refresh_layout"), "Welcome Site Search screen")
        {
        }

        public void ClickNextButton() => nextButton.Click();

        public void ClickRadioButtonByText(string text) => GetRadioButtonByText(text).Click();

        public void SetUrlToSearch(string url) => searchTextBox.ClearAndType(url);

        private IRadioButton GetRadioButtonByText(string text)
        {
            return ElementFactory.GetRadioButton(By.XPath(string.Format(SearchElementLocator, text)), $"{text} radio button");
        }
    }
}
