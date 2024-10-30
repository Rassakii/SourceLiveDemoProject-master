using OpenQA.Selenium;
using SourceLiveDemoProject.Model;

namespace SourceLiveDemoProject.Pages
{

    public class LogInPage
    {
        public IWebDriver Driver;
        public LogInPage(IWebDriver driver)
        {
            Driver = driver;
        }
        private IWebElement UserNameTextfield => Driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordTextfield => Driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton => Driver.FindElement(By.XPath("//input[@class='btn_action']"));
        private IWebElement RobotImage => Driver.FindElement(By.XPath("//img[@class='bot_column']"));


        public void SignInAsStandardUser(UserProfile user)
        {
            UserNameTextfield.SendKeys(user.StandardUsername);
            PasswordTextfield.SendKeys(user.Password);
            LoginButton.Click();
        }
        public bool IsRobotImageDisplayed()
        {
            return RobotImage.Displayed;
        }
        public bool IsLoginButtonDisplayed()
        {
            return LoginButton.Displayed;
        }
    }
}
