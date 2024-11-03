using AventStack.ExtentReports;
using OpenQA.Selenium;
using SourceLiveDemoProject.Configuration;
using TechTalk.SpecFlow;

namespace SourceLiveDemoProject.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports extent;
        [ThreadStatic]
        public static ExtentTest _feature;
        [ThreadStatic]
        public static ExtentTest _scenario;

        //public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        //public static String testResultPath = dir.Replace("bin\\Debug\\net8.0", "Reports");
        public static String testResultPath = @"TestResults";

        public static void ExtentReportInit()
        {
            if (!Directory.Exists(testResultPath))
                Directory.CreateDirectory(testResultPath);

            string reportFileName = $"AutomationStatusReport_{ConfigurationManager.BrowserName}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.html";
            string fullReportPath = Path.Combine(testResultPath, reportFileName);

            var htmlReporter = new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(fullReportPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Start();

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
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