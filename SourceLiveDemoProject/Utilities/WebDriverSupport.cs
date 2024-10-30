using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SourceLiveDemoProject.Configuration;

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

        public void InitializeBrowser(string browserName)
        {
            bool headless = ConfigurationManager.Headless;

            Action setupAction = browserName.ToLower() switch
            {
                "edge" => () => _driver = SetupEdgeDriver(headless),
                "chrome" => () => _driver = SetupChromeDriver(headless),
                "firefox" => () => _driver = SetupFirefoxDriver(headless),
                "mobile" => () => _driver = SetupMobileDriver(headless),
                _ => throw new ArgumentException($"Unknown browser: {browserName}")
            };

            setupAction.Invoke();
            _objectContainer.RegisterInstanceAs(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        IWebDriver SetupEdgeDriver(bool headless)
        {
            var options = new EdgeOptions();
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            if (headless) options.AddArgument("headless");
            return new EdgeDriver(options);
        }

        IWebDriver SetupChromeDriver(bool headless)
        {
            var options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            if (headless) options.AddArgument("headless");
            return new ChromeDriver(options);
        }

        IWebDriver SetupFirefoxDriver(bool headless)
        {
            var options = new FirefoxOptions();
            if (headless) options.AddArgument("-headless");
            return new FirefoxDriver(options);
        }

        IWebDriver SetupMobileDriver(bool headless)
        {
            var options = new ChromeOptions();
            options.EnableMobileEmulation(ConfigurationManager.MobileDeviceName);
            options.SetLoggingPreference(LogType.Performance, LogLevel.All);
            if (headless) options.AddArgument("headless");
            return new ChromeDriver(options);
        }

        public void CloseApplicationUnderTest()
        {
            _driver?.Quit();
        }

    }
}

