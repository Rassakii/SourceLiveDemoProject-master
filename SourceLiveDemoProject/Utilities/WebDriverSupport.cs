using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SourceLiveDemoProject.Utilities
{
    public class WebDriverSupport
    {
        private readonly IObjectContainer _objectContainer;
        public IWebDriver _driver;


        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }




        public void InitializeBrowser(string browser)
        {
            //test=  extent.CreateTest(TestContext.CurrentContext.Test.Name);
            switch (browser.ToLower())
            {
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    _driver = new ChromeDriver(chromeOptions);
                    break;
                case "edge":
                    EdgeOptions edgeOptions = new EdgeOptions();
                    _driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new ArgumentException("Unsupported browser: " + browser);
            }
            _objectContainer.RegisterInstanceAs(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void CloseApplicationUnderTest()
        {


            _driver?.Quit();

        }

    }
}

