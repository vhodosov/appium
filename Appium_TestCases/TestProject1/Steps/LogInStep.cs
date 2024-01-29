using TestProject1.PageObject.MastodonPageObject;

namespace TestProject1.Steps
{
    public class LogInStep
    {
        public LogInStep() 
        {
            this.SiteUrl = SiteUrlString;
        }
        public string SiteUrl { get; private set; }

        private readonly string Email = "vlad3339kryt@gmail.com";
        private readonly string Password = "2143658709oI";
        private readonly string SiteUrlString = "mastodon.social";

        public void LogIn()
        {
            var welcomeScreen = new WelcomeScreen();
            Assert.IsTrue(welcomeScreen.State.WaitForDisplayed(), "Welcome screen is not opened");
            welcomeScreen.ClickLogIn();

            var welcomeSiteSearchScreen = new WelcomeSiteSearchScreen();
            Assert.IsTrue(welcomeSiteSearchScreen.State.WaitForDisplayed(), "welcomeSiteSearchScreen is not opened");
            welcomeSiteSearchScreen.SetUrlToSearch(SiteUrl);
            welcomeSiteSearchScreen.ClickRadioButtonByText(SiteUrl);
            welcomeSiteSearchScreen.ClickNextButton();

            var logInScreen = new LogInScreen();
            if (logInScreen.State.WaitForDisplayed())
            {
                logInScreen.SetEmail(Email);
                logInScreen.SetPassword(Password);
                logInScreen.ClickLogIn();
            }            

            var authorizationRequiredScreen = new AuthorizationRequiredScreen();
            Assert.IsTrue(authorizationRequiredScreen.State.WaitForDisplayed(), "AuthorizationRequiredScreen is not opened");
            authorizationRequiredScreen.ClickAuthorize();

            var grantPermissionScreen = new GrantPermissionScreen();
            Assert.IsTrue(grantPermissionScreen.State.WaitForDisplayed(), "GrantPermissionScreen is not opened");
            grantPermissionScreen.ClickAllow();
        }
    }
}
