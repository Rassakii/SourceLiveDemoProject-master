using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SourceLiveDemoProject.Model;

namespace SourceLiveDemoProject.Pages
{
    public class ProductPage
    {
        public IWebDriver Driver;
        public ProductPage(IWebDriver driver)
        {
            Driver = driver;
        }
        private IWebElement BagpackPicture => Driver.FindElement(By.XPath("//img[@src='./img/sauce-backpack-1200x1500.jpg']"));
        private IWebElement BikeLightPicture => Driver.FindElement(By.XPath("//img[@src='./img/bike-light-1200x1500.jpg']"));
        private IWebElement ProductLabel => Driver.FindElement(By.XPath("//div[@class='product_label']"));
        private IWebElement AddtoCart(string itemname) => Driver.FindElement(By.XPath($"//div[@class='inventory_item' and contains(.,'{itemname}')]//button"));
        private IWebElement CartIcon => Driver.FindElement(By.XPath("//span[@class='fa-layers-counter shopping_cart_badge']"));
        private IWebElement SortDropdown => Driver.FindElement(By.XPath("//select[@class='product_sort_container']"));
        private IWebElement MenuButton => Driver.FindElement(By.XPath("//div[@class='bm-burger-button']"));
        private IWebElement LogoutButton => Driver.FindElement(By.XPath("//a[@id='logout_sidebar_link']"));

        public bool IsBagpackDisplayed()
        {
            return BagpackPicture.Displayed;
        }
        public bool IsBikeLightDisplayed()
        {
            return BikeLightPicture.Displayed;
        }
        public string GetProductLabelText()
        {
            return ProductLabel.Text;
        }
        public void AddProductToCart(UserProfile user)
        {
            AddtoCart(user.ProductOne).Click();
            AddtoCart(user.ProductTwo).Click();
        }
        public void ClickCartIcon()
        {
            CartIcon.Click();
        }
        public void SortByPriceLowToHigh()
        {
            SelectElement SortDropdown = new SelectElement(this.SortDropdown);
            SortDropdown.SelectByValue("lohi");
        }
        public void ClickMenuButton()
        {
            MenuButton.Click();
        }
        public void ClickLogoutButton()
        {
            LogoutButton.Click();
        }
    }
}
