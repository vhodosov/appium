using Aquality.Appium.Mobile.Actions;
using Aquality.Appium.Mobile.Applications;
using Aquality.Appium.Mobile.Elements.Interfaces;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Core.Elements.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using TestProject1.Enums;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class PostsScreen : NavigationBarScreen
    {
        private const string searchResultsLocator = "//android.widget.ImageView[@resource-id='org.joinmastodon.android:id/avatar']";
        private const string searchLabelLocator = "//android.widget.TextView[@resource-id='org.joinmastodon.android:id/title' and contains(@text, '{0}')]";
        private readonly ITextBox searchTextBox = ElementFactory.GetTextBox(By.Id("org.joinmastodon.android:id/search_text"), "Search text box");
        private readonly ITextBox searchAfterClickTextBox = ElementFactory.GetTextBox(By.XPath("//android.widget.EditText[@text='Search Mastodon']"), "Search text box");
        private readonly ILabel postLabel = ElementFactory.GetLabel(By.XPath("(//android.widget.TextView[@resource-id='org.joinmastodon.android:id/text'])[1]"), "Post label", state: ElementState.ExistsInAnyState);
        private readonly ILabel postsTestTitleLabel = ElementFactory.GetLabel(By.XPath("//android.widget.TextView[@resource-id='org.joinmastodon.android:id/title' and @text='#tests']"), "Posts tests title label");

        public PostsScreen() : base(By.Id("org.joinmastodon.android:id/discover_posts"), "Posts Screen")
        {
        }

        public void ScrollToSpecificElement(int number)
        {
            ElementFactory.GetLabel(By.XPath(string.Format("(//android.widget.TextView[@resource-id='org.joinmastodon.android:id/text'])[{0}]", number.ToString())), "Post label", state: ElementState.ExistsInAnyState).TouchActions.ScrollToElement(SwipeDirection.Down);
        }

        public void SwipeToFirstPost()
        {            
            do
            {
                new TouchActions().SwipeWithLongPress(new Point(720, 624), new Point(720, 2496));
            } while (postLabel.State.IsClickable);            
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

        public void CloseSearch()
        {
            searchAfterClickTextBox.SendKeys(Keys.Enter);
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
