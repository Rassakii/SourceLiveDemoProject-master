using AventStack.ExtentReports;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SourceLiveDemoProject.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports extent;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;


        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net8.0", "TestResults");


        public static void ExtentReportInit()
        {
            var htmlReporter = new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Start();

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Application", "Orange");
            extent.AddSystemInfo("Browser", "Edge");
            extent.AddSystemInfo("OS", "Windows");
        }
        public static void ExtentReportTearDown()
        {
            extent.Flush();
        }
        public string AddScreenshot(IWebDriver driver, ScenarioContext scenariocontext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenariocontext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;

        }
    }
}

