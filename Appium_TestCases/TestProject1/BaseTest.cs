using Aquality.Appium.Mobile.Applications;
using Aquality.Selenium.Core.Logging;
using OpenQA.Selenium.Appium.Android;

namespace TestProject1
{   
    public abstract class BaseTest
    {
        protected Logger _logger = Logger.Instance;
        protected AndroidDriver driver;
        private readonly string appId = "org.joinmastodon.android";
        private readonly string browserId = "com.opera.browser";

        [SetUp]
        public void Setup()
        {
            driver = new(AqualityServices.ApplicationProfile.DriverSettings.AppiumOptions);
            //AqualityServices.Application.Driver.ActivateApp(appId);
        }

        [TearDown]
        public void Test1()
        {
            AqualityServices.Application.Quit();
            AqualityServices.Application.Driver.TerminateApp(appId);
            AqualityServices.Application.Driver.TerminateApp(browserId);
        }
    }
}