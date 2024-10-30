using OpenQA.Selenium;
using SourceLiveDemoProject.Model;

namespace SourceLiveDemoProject.Pages
{
    public class CheckoutPage
    {

        public IWebDriver Driver;
        public CheckoutPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private IWebElement FirstNameTextfield => Driver.FindElement(By.Id("first-name"));
        private IWebElement LastNameTextField => Driver.FindElement(By.Id("last-name"));
        private IWebElement PostcodeTextField => Driver.FindElement(By.Id("postal-code"));
        private IWebElement ContinueButton => Driver.FindElement(By.XPath("//input[@class='btn_primary cart_button']"));
        private IWebElement FinishButton => Driver.FindElement(By.XPath("//a[@class='btn_action cart_button']"));
        private IWebElement PonyExpressImage => Driver.FindElement(By.XPath("//img[@class='pony_express']"));
        private IWebElement SuccessMessage => Driver.FindElement(By.XPath("//h2[@class='complete-header']"));
        private IWebElement RemoveFromCart(string itemname) => Driver.FindElement(By.XPath($"//div[@class='cart_item' and contains(.,'{itemname}')]//Button"));
        private IWebElement CancelButton => Driver.FindElement(By.XPath("//a[@class='cart_cancel_link btn_secondary']"));

        public void FIlldetailsAndContinue(UserProfile user)
        {
            FIlldetails(user);
            FinishButton.Click();
        }

        public bool IsPonyImageDispalyed()
        {
            return PonyExpressImage.Displayed;
        }
        public void FIlldetails(UserProfile user)
        {
            FirstNameTextfield.SendKeys(user.Firstname);
            LastNameTextField.SendKeys(user.Lastname);
            PostcodeTextField.SendKeys(user.PostCode);
            ContinueButton.Click();
        }
        public bool IsSuccessMessageDisplayed()
        {
            return SuccessMessage.Displayed;
        }
        public void ClickCancelButton()
        {
            CancelButton.Click();
        }
    }
}
