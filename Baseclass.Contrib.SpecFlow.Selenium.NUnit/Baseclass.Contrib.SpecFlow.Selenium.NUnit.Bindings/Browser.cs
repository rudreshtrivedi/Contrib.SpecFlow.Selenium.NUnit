using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings
{
    [Binding]
    public class Browser
    {
        IWebDriver driver;
        ScenarioContext _scenarioContext;
        public Browser(IWebDriver Current,ScenarioContext scenarioContext)
        {
            driver = Current;
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Current
        {
            get
            {
                return (IWebDriver)_scenarioContext["Driver"];
            }
        }

        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {

            driver.Manage().Window.Maximize();
            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];
            driver.Navigate().GoToUrl(string.Format("{0}{1}", baseUrl, url));
        }
    }
}
