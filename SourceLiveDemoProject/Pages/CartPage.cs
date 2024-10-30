using OpenQA.Selenium;
using SourceLiveDemoProject.Model;

namespace SourceLiveDemoProject.Pages
{
    public class CartPage
    {
        public IWebDriver Driver;
        public CartPage(IWebDriver driver)
        {
            Driver = driver;
        }
        private IWebElement CheckoutButton => Driver.FindElement(By.XPath("//a[@class='btn_action checkout_button']"));
        private IWebElement RemoveButton(string itemname) => Driver.FindElement(By.XPath($"//div[@class='cart_item' and contains(.,'{itemname}')]//Button"));
        private IWebElement ProductInCart(string itemname) => Driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and contains(.,'{itemname}')]"));

        public void ClickCheckout()
        {
            CheckoutButton.Click();
        }

        public void RemoveItemsFromCart(UserProfile user)
        {
            RemoveButton(user.ProductOne).Click();
            RemoveButton(user.ProductTwo).Click();
        }

        public (bool productOne, bool productTwo) CheckProductVisibilityInCart(UserProfile user)
        {
            bool isProductOneVisible;
            bool isProductTwoVisible;

            try
            {
                isProductOneVisible = ProductInCart(user.ProductOne).Displayed;
            }
            catch (NoSuchElementException)
            {
                isProductOneVisible = false;
            }

            try
            {
                isProductTwoVisible = ProductInCart(user.ProductTwo).Displayed;
            }
            catch (NoSuchElementException)
            {
                isProductTwoVisible = false;
            }

            return (isProductOneVisible, isProductTwoVisible);
        }
    }
}
