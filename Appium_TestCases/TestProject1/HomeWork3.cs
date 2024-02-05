using Aquality.Appium.Mobile.Applications;
using OpenQA.Selenium.Appium.Android;
using TestProject1.Enums;
using TestProject1.PageObject.MastodonPageObject;
using TestProject1.Steps;

namespace TestProject1
{
    public class HomeWork3 : BaseTest
    {
        private string searchText = "tests";

        [Test]
        public void TestCaseHomeWork3_1()
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

            _logger.Info("Scroll to post 4 with ScrollToElement() / scrollToElement()");
            postsScreen.ScrollToSpecificElement(4);

            _logger.Info("Go back to the first post using Swipe at the coordinates");
            postsScreen.SwipeToFirstPost();

            _logger.Info("Implement the swipe method to the 20th post in the feed of posts without using framework methods. Use the methods of Appium itself");
            /// Не выполнил так как фреймворк акволити конфликтует с драйвером аппиума
        }

        [Test]
        public void TestCaseHomeWork3_2()
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

            _logger.Info("Tap the search field by the position. Enter 'tests'. Search result is not empty");
            /// С какого-то момента клавиатура стала пропадать и после дебага симулятор телефона становился кирпичом
            /// поэтому дальше я написал код на понимание того, как эьто должно выглядеть
            postsScreen.TapSearch();
            Assert.IsTrue(AqualityServices.Application.Driver.IsKeyboardShown(), "Keyboard is not shown");

            driver.PressKeyCode(AndroidKeyCode.Enter);
            _logger.Info($"Keyboard in state {AqualityServices.Application.Driver.IsKeyboardShown()}");
            OpenKeyboardIfNotOpened(postsScreen);

            _logger.Info("Try closing it using the SendKeys() method and log the results (if it is closed or not)");
            postsScreen.CloseSearch();
            _logger.Info($"Keyboard in state {AqualityServices.Application.Driver.IsKeyboardShown()}");
            OpenKeyboardIfNotOpened(postsScreen);

            _logger.Info("Try closing it using the HideKeyboard() / hideKeyboard() method and log the results (if it is closed or not)");
            AqualityServices.Application.Driver.HideKeyboard();
            _logger.Info($"Keyboard in state {AqualityServices.Application.Driver.IsKeyboardShown()}");            

            _logger.Info("Enter some characters using keyboard interaction methods (e.g. pressKey())");
            foreach (var item in searchText)
            {
                driver.PressKeyCode(item);
            }
        }

        private void OpenKeyboardIfNotOpened(PostsScreen screen)
        {
            if (!AqualityServices.Application.Driver.IsKeyboardShown())
            {
                screen.TapSearch();
                Assert.IsTrue(AqualityServices.Application.Driver.IsKeyboardShown(), "Keyboard is not shown");
            }
        }
    }
}