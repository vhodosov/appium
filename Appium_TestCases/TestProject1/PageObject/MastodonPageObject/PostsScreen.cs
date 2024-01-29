using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using TestProject1.Enums;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class PostsScreen : NavigationBarScreen
    {
        private const string searchResultsLocator = "//android.widget.ImageView[@resource-id='org.joinmastodon.android:id/avatar']";
        private const string searchLabelLocator = "//android.widget.TextView[@resource-id='org.joinmastodon.android:id/title' and contains(@text, '{0}')]";
        private readonly ITextBox searchTextBox = ElementFactory.GetTextBox(By.Id("org.joinmastodon.android:id/search_text"), "Search text box");
        private readonly ITextBox searchAfterClickTextBox = ElementFactory.GetTextBox(By.XPath("//android.widget.EditText[@text='Search Mastodon']"), "Search text box");
        private readonly ILabel postLabel = ElementFactory.GetLabel(By.XPath("//android.widget.TextView[@resource-id='org.joinmastodon.android:id/text']"), "Post label");
        private readonly ILabel postsTestTitleLabel = ElementFactory.GetLabel(By.XPath("//android.widget.TextView[@resource-id='org.joinmastodon.android:id/title' and @text='#tests']"), "Posts tests title label");

        public PostsScreen() : base(By.Id("org.joinmastodon.android:id/discover_posts"), "Posts Screen")
        {
        }

        public void ScrollToFourthPost()
        {
            var elements = ElementFactory.FindElements<ILabel>(By.XPath(postLabel.Locator.Criteria));

            var touchAction = new TouchAction(AqualityServices.Application.Driver);
            touchAction.MoveTo(elements[3].GetElement()).Perform();
        }

        public bool IsPostsTestsTitlePresent()
        {
            return postsTestTitleLabel.State.WaitForDisplayed();
        }

        public bool IsResultsNotEmpty()
        {
            return ElementFactory.FindElements<ILabel>(By.XPath(searchResultsLocator)).Any();
        }

        public void SetSearch(string text)
        {
            searchAfterClickTextBox.Type(text);
        }

        public void TapSearch()
        {
            searchTextBox.Click();
        }

        public string GetPositionForSearch()
        {
            var location = searchTextBox.Visual.Location;

            return $"{location.X}:{location.Y}";
        }

        public bool IsPostsDisplayed()
        {
            return postLabel.State.WaitForDisplayed();
        }

        public string GetTextFromFirstPost()
        {
            return postLabel.Text;
        }

        public void ClickOnFirstPost()
        {
            postLabel.Click();
        }

        public void ClickOnSearchByText(string text)
        {
            GetSearchLabel(text).Click();
        }

        private ILabel GetSearchLabel(string text)
        {
            return ElementFactory.GetLabel(By.XPath(string.Format(searchLabelLocator, text)), $"Label {text}");
        }
    }
}
