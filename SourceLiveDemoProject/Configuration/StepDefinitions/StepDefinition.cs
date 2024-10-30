using SourceLiveDemoProject.Model;
using SourceLiveDemoProject.Pages;
using TechTalk.SpecFlow;

namespace SourceLiveDemoProject.Configuration.StepDefinitions
{
    [Binding]
    public class StepDefinition
    {
        BasePage _basePage;
        LogInPage _logInPage;
        ProductPage _productPage;
        CartPage _cartPage;
        CheckoutPage _checkoutPage;
        ScenarioContext _scenarioContext;

        public StepDefinition(ScenarioContext scenarioContext)
        {
            _basePage = scenarioContext.ScenarioContainer.Resolve<BasePage>();
            _logInPage = scenarioContext.ScenarioContainer.Resolve<LogInPage>();
            _productPage = scenarioContext.ScenarioContainer.Resolve<ProductPage>();
            _cartPage = scenarioContext.ScenarioContainer.Resolve<CartPage>();
            _checkoutPage = scenarioContext.ScenarioContainer.Resolve<CheckoutPage>();
            _scenarioContext = scenarioContext.ScenarioContainer.Resolve<ScenarioContext>();
        }

        [Given(@"Sourcedemo live is loaded succcesfully")]
        public void GivenSourcedemoLiveIsLoadedSucccesfully()
        {
            _basePage.LoadApplicationUnderTest();
            var user = new UserProfile();
            _scenarioContext.Set(user, "user");
        }
        [When(@"User logs in as a standard user")]
        public void WhenUserLogsInAsAStandardUser()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _logInPage.SignInAsStandardUser(user);
        }

        [Then(@"user is logged in succesfully")]
        public void ThenUserIsLoggedInSuccesfully()
        {
            Assert.IsTrue(_productPage.IsBagpackDisplayed());
            Assert.IsTrue(_productPage.IsBikeLightDisplayed());

            //why is this? are you trying to assert?
            _productPage.IsProductlabelDisplayed();
        }

        [When(@"User sorts product by price")]
        public void WhenUserSortsProductByPrice()
        {
            _productPage.SortByPriceLowToHigh();
        }

        [When(@"user proceeds to logout")]
        public void WhenUserProceedsToLogout()
        {
            _productPage.ClickMenuButton();
            _productPage.ClickLogoutButton();
        }

        [Then(@"signedout succesfully")]
        public void ThenSignedoutSuccesfully()
        {
            Assert.IsTrue(_logInPage.IsLoginButtonDisplayed());
            Assert.IsTrue(_logInPage.IsRobotImageDisplayed());
        }

        [When(@"User Removes the product in the cart")]
        public void WhenUserRemovesTheProductInTheCart()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _productPage.ClickCartIcon();
            _cartPage.RemoveItemsFromCart(user);
        }

        [Then(@"the products are removed succesfully")]
        public void ThenTheProductsAreRemovedSuccesfully()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            Assert.IsFalse(_cartPage.CheckProductVisibilityInCart(user).productOne);
            Assert.IsFalse(_cartPage.CheckProductVisibilityInCart(user).productTwo);
        }

        [When(@"the user adds sauce lab backpacks and saucel labs bike light to cart")]
        public void WhenTheUserAddsSauceLabBackpacksAndSaucelLabsBikeLightToCart()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _productPage.AddProductToCart(user);
        }

        [When(@"user proceeds  to checkout and finish")]
        public void WhenUserProceedsToCheckoutAndFinish()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _productPage.ClickCartIcon();
            _cartPage.ClickCheckout();
            _checkoutPage.FIlldetailsAndContinue(user);
        }

        [Then(@"the products are purchased succesfully")]
        public void ThenTheProductsArePurchasedSuccesfully()
        {
            Assert.IsTrue(_checkoutPage.IsPonyImageDispalyed());
            Assert.IsTrue(_checkoutPage.IsSuccessMessageDisplayed());
        }

        [When(@"User proceeds to checkout Information")]
        public void WhenUserProceedsToCheckoutInformation()
        {
            var user = _scenarioContext.Get<UserProfile>("user");
            _productPage.ClickCartIcon();
            _cartPage.ClickCheckout();
            _checkoutPage.FIlldetails(user);
        }

        [When(@"user cancels the transaction")]
        public void WhenUserCancelsTheTransaction()
        {
            _checkoutPage.ClickCancelButton();
        }

        [Then(@"Order is canceled Succesfully")]
        public void ThenOrderIsCanceledSuccesfully()
        {
            Assert.IsTrue(_productPage.IsBagpackDisplayed());
            Assert.IsTrue(_productPage.IsBikeLightDisplayed());
            _productPage.IsProductlabelDisplayed();
        }
    }
}
