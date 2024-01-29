using Aquality.Appium.Mobile.Applications;
using Aquality.Selenium.Core.Logging;

namespace TestProject1
{   
    public abstract class BaseTest
    {
        protected Logger _logger = Logger.Instance;
        private readonly string appId = "org.joinmastodon.android";

        [SetUp]
        public void Setup()
        {
            AqualityServices.Application.Driver.ActivateApp(appId);
        }

        [TearDown]
        public void Test1()
        {
            AqualityServices.Application.Quit();
            AqualityServices.Application.Driver.TerminateApp(appId);
        }
    }
}