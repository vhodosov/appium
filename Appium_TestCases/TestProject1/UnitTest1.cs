using Aquality.Appium.Mobile.Applications;
using TestProject1.Enums;
using TestProject1.PageObject;
using TestProject1.PageObject.MastodonPageObject;
using TestProject1.Steps;

namespace TestProject1
{
    public class Tests : BaseTest
    {
        private string searchText = "tests";

        [Test]
        public void TestCase1()
        {
            _logger.Info("Check that Welcome screen is opened");
            var welcomeScreen = new WelcomeScreen();
            Assert.IsTrue(welcomeScreen.State.WaitForDisplayed(), "Welcome screen is not opened");

            _logger.Info("Close Mastodon without closing the session. App is closed");
            AqualityServices.Application.Driver.CloseApp();
            var homeScreen = new HomeScreen();
            Assert.IsTrue(homeScreen.State.WaitForDisplayed(), "Home screen is not opened");

            _logger.Info("LogIn in app. Home screen is opened");
            homeScreen.ClickMastodonAppButton();
            var logInStep = new LogInStep();
            logInStep.LogIn();
            var homeAppScreen = new HomeAppScreen();
            Assert.IsTrue(homeAppScreen.State.WaitForDisplayed(), "Home App screen is not opened");

            _logger.Info("Tap 'Search' tab. Posts screen is opened");
            homeAppScreen.GoTo(NavigationTypes.search);
            var postsScreen = new PostsScreen();
            Assert.IsTrue(postsScreen.State.WaitForDisplayed(), "Posts Screen is not opened");

            _logger.Info("Open the first post. The first post is opened");
            var firstTextPost = postsScreen.GetTextFromFirstPost();
            postsScreen.ClickOnFirstPost();

            var postScreen = new PostScreen();
            Assert.IsTrue(postScreen.State.WaitForDisplayed(), "Post Screen is not opened");
            Assert.AreEqual(firstTextPost, postScreen.GetTextFromFirstPost(), "Posts are not the same");
        }

        [Test]
        public void TestCase2()
        {
            _logger.Info("Check that Welcome screen is opened");
            var welcomeScreen = new WelcomeScreen();
            Assert.IsTrue(welcomeScreen.State.WaitForDisplayed(), "Welcome screen is not opened");

            _logger.Info("Close Mastodon without closing the session. App is closed");
            AqualityServices.Application.Driver.CloseApp();
            var homeScreen = new HomeScreen();
            Assert.IsTrue(homeScreen.State.WaitForDisplayed(), "Home screen is not opened");

            _logger.Info("LogIn in app. Home screen is opened");
            homeScreen.ClickMastodonAppButton();
            var logInStep = new LogInStep();
            logInStep.LogIn();
            var homeAppScreen = new HomeAppScreen();
            Assert.IsTrue(homeAppScreen.State.WaitForDisplayed(), "Home App screen is not opened");

            _logger.Info("Tap 'Search' tab. Posts screen is opened");
            homeAppScreen.GoTo(NavigationTypes.search);
            var postsScreen = new PostsScreen();
            Assert.IsTrue(postsScreen.State.WaitForDisplayed(), "Posts Screen is not opened");

            _logger.Info("Check that posts are in the Displayed state");
            Assert.IsTrue(postsScreen.IsPostsDisplayed(), "Posts have the Displayed state");

            _logger.Info("Get the position of a search field");
            Assert.AreNotEqual("0:0", postsScreen.GetPositionForSearch(), "Position for search is 0:0");

            _logger.Info("Tap the search field by the position. Enter 'tests'. Search result is not empty");
            postsScreen.TapSearch();
            postsScreen.SetSearch(searchText);
            Assert.IsTrue(postsScreen.IsResultsNotEmpty(), "Results is empty");

            _logger.Info("Open the Posts with '#tests' search results using method to click an Element. Post screen with #tests is opened");
            postsScreen.ClickOnSearchByText(searchText);
            Assert.IsTrue(postsScreen.IsPostsTestsTitlePresent(), "tests post results is not shown");

            _logger.Info("Scroll down to the fourth post");
            postsScreen.ScrollToFourthPost();
        }

        [Test]
        public void TestCase3()
        {
            _logger.Info("Check that Welcome screen is opened");
            var welcomeScreen = new WelcomeScreen();
            Assert.IsTrue(welcomeScreen.State.WaitForDisplayed(), "Welcome screen is not opened");

            _logger.Info("LogIn in app. Home screen is opened");
            var logInStep = new LogInStep();
            logInStep.LogIn();
            var homeAppScreen = new HomeAppScreen();
            Assert.IsTrue(homeAppScreen.State.WaitForDisplayed(), "Home App screen is not opened");

            _logger.Info("Tap 'Search' tab. Posts screen is opened");
            homeAppScreen.GoTo(NavigationTypes.search);
            var postsScreen = new PostsScreen();
            Assert.IsTrue(postsScreen.State.WaitForDisplayed(), "Posts Screen is not opened");

            _logger.Info("Get the current context");
            var currentContext = AqualityServices.Application.Driver.Context;
            Assert.NotNull(currentContext, "Null in context");

            _logger.Info("Check if there are other contexts");
            var currentContexts = AqualityServices.Application.Driver.Contexts;
            Assert.IsTrue(currentContexts.Count > 1, "We don't have others contexts");            

            _logger.Info("If those contexts are there, switch to them");
            var otherContexts = currentContexts.Except<string>(new List<string> { currentContext });
            foreach (var context in otherContexts) 
            {
                AqualityServices.Application.Driver.Context = context;
            }
        }
    }
}