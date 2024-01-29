using Aquality.Appium.Mobile.Elements.Interfaces;
using OpenQA.Selenium;

namespace TestProject1.PageObject.MastodonPageObject
{
    public class PostScreen : NavigationBarScreen
    {
        private readonly ILabel postLabel = ElementFactory.GetLabel(By.XPath("//android.widget.TextView[@resource-id='org.joinmastodon.android:id/text']"), "Post label");

        public PostScreen() : base(By.Id("org.joinmastodon.android:id/appkit_loader_content"), "Post Screen")
        {
        }

        public string GetTextFromFirstPost()
        {
            return postLabel.Text;
        }
    }
}
