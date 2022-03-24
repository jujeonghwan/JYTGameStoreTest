/*
 * OrdersTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.12.01: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class OrdersTest
    {
        private IWebDriver driver;                  // Web Driver        
        private string testURL = Shared.BASE_URL;   // URL        
        private TestingUtils utils;                 // Testing Utils
        private CommonXpath xpath;                  // Common XPath

        // Setup
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            testURL = Shared.BASE_URL;
            utils = new TestingUtils(driver);
            xpath = new CommonXpath();
        }

        // Tear Down
        [TearDown]
        public void TearDownDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [Test]
        // Verify Order Physical Shipping Yes with Valid Data
        public void TC01_VerifyOrderPhysicalShippingYesWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";
            string dataIsPhysicalShipping = "1";        // Yes
            string dataIsCreditCardId = "****-3333-****-5555";
            string dataOrderPlacedAlert = "Your order has been successfully placed.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Get 'Game Name' from the page.
            dataGameName = utils.getText(xpath.textGameDetailsGameNameXpath);

            // Click on ‘Add to Cart’ button
            utils.click(xpath.buttonGameDetailsAddToCartXpath);

            // Validate if user lands on 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartPageTitleXpath), Is.True);

            // Validate if 'added game' is displayed on the 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Proceed to Checkout

            // Click 'Proceed to Checkout' button on the Cart page.
            utils.click(xpath.buttonCartProceedToCheckoutXpath);

            // Validate if user lands on 'Checkout' page.
            Assert.That(utils.isDisplayed(xpath.textCheckoutPageTitleXpath), Is.True);

            // Click on ‘Physical Shipping’ radio button on the Checkout page.
            utils.checkRadio(xpath.radioCheckoutPhysicalShippingXpath.Replace("{isPhysicalShipping}", dataIsPhysicalShipping));
            
            // Select 'Credit Card'
            utils.setSelectByText(xpath.selectCheckoutXpathCreditCardIdXpath, dataIsCreditCardId);

            // Click on ‘Place your order’ button
            utils.click(xpath.buttonCheckoutPlaceYourOrderXpath);

            // Validate if 'alert' message is displayed. (Your order has been successfully placed.)
            Assert.That(utils.acceptAlertMessage(dataOrderPlacedAlert), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Your Orders 

            // Validate if user lands on 'Your Orders' page.
            Assert.That(utils.isDisplayed(xpath.textOrdersPageTitleXpath), Is.True);

            // Click on ‘first’ Order number link.
            utils.click(xpath.linkOrdersOrderNumberFirstXpath);

            ////////////////////////////////////////////////////////////////////////////////
            // Order Details

            // Validate if user lands on 'Order Details' page.
            Assert.That(utils.isDisplayed(xpath.textOrderDetailsPageTitleXpath), Is.True);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Order Physical Shipping No with Valid Data
        public void TC02_VerifyOrderPhysicalShippingNoWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";
            string dataIsPhysicalShipping = "0";        // No
            string dataIsCreditCardId = "****-3333-****-5555";
            string dataOrderPlacedAlert = "Your order has been successfully placed.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Get 'Game Name' from the page.
            dataGameName = utils.getText(xpath.textGameDetailsGameNameXpath);

            // Click on ‘Add to Cart’ button
            utils.click(xpath.buttonGameDetailsAddToCartXpath);

            // Validate if user lands on 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartPageTitleXpath), Is.True);

            // Validate if 'added game' is displayed on the 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Proceed to Checkout

            // Click 'Proceed to Checkout' button on the Cart page.
            utils.click(xpath.buttonCartProceedToCheckoutXpath);

            // Validate if user lands on 'Checkout' page.
            Assert.That(utils.isDisplayed(xpath.textCheckoutPageTitleXpath), Is.True);

            // Click on ‘Physical Shipping’ radio button on the Checkout page.
            utils.checkRadio(xpath.radioCheckoutPhysicalShippingXpath.Replace("{isPhysicalShipping}", dataIsPhysicalShipping));

            // Select 'Credit Card'
            utils.setSelectByText(xpath.selectCheckoutXpathCreditCardIdXpath, dataIsCreditCardId);

            // Click on ‘Place your order’ button
            utils.click(xpath.buttonCheckoutPlaceYourOrderXpath);

            // Validate if 'alert' message is displayed. (Your order has been successfully placed.)
            Assert.That(utils.acceptAlertMessage(dataOrderPlacedAlert), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Your Orders 

            // Validate if user lands on 'Your Orders' page.
            Assert.That(utils.isDisplayed(xpath.textOrdersPageTitleXpath), Is.True);

            // Click on ‘first’ Order number link.
            utils.click(xpath.linkOrdersOrderNumberFirstXpath);

            ////////////////////////////////////////////////////////////////////////////////
            // Order Details

            // Validate if user lands on 'Order Details' page.
            Assert.That(utils.isDisplayed(xpath.textOrderDetailsPageTitleXpath), Is.True);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Order with Physical Shipping Not Selected
        public void TC03_VerifyOrderWithPhaysicalShippingNotSelected()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";
            string dataIsPhysicalShipping = "";        // Not Selected
            string dataIsCreditCardId = "****-3333-****-5555";

            string errorIsPhysicalShippingInvalid = "The Physical Shipping field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Get 'Game Name' from the page.
            dataGameName = utils.getText(xpath.textGameDetailsGameNameXpath);

            // Click on ‘Add to Cart’ button
            utils.click(xpath.buttonGameDetailsAddToCartXpath);

            // Validate if user lands on 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartPageTitleXpath), Is.True);

            // Validate if 'added game' is displayed on the 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Proceed to Checkout

            // Click 'Proceed to Checkout' button on the Cart page.
            utils.click(xpath.buttonCartProceedToCheckoutXpath);

            // Validate if user lands on 'Checkout' page.
            Assert.That(utils.isDisplayed(xpath.textCheckoutPageTitleXpath), Is.True);

            // Click on ‘Physical Shipping’ radio button on the Checkout page.
            // utils.checkRadio(xpath.radioCheckoutPhysicalShippingXpath.Replace("{isPhysicalShipping}", dataIsPhysicalShipping));

            // Select 'Credit Card'
            utils.setSelectByText(xpath.selectCheckoutXpathCreditCardIdXpath, dataIsCreditCardId);

            // Click on ‘Place your order’ button
            utils.click(xpath.buttonCheckoutPlaceYourOrderXpath);

            // Validate if error message is displayed on the ‘Checkout’ page. (The Physical Shipping field is required.)
            Assert.That(utils.getText(xpath.errorCheckoutIsPhysicalShippingXpath), Is.EqualTo(errorIsPhysicalShippingInvalid));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Order with Credit Card Not Selected
        public void TC04_VerifyOrderWithCreditCardNotSelected()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";
            string dataIsPhysicalShipping = "1";        // Yes
            string dataIsCreditCardId = "";

            string errorCreditCardInvalid = "The Credit Card field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Get 'Game Name' from the page.
            dataGameName = utils.getText(xpath.textGameDetailsGameNameXpath);

            // Click on ‘Add to Cart’ button
            utils.click(xpath.buttonGameDetailsAddToCartXpath);

            // Validate if user lands on 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartPageTitleXpath), Is.True);

            // Validate if 'added game' is displayed on the 'Cart' page.
            Assert.That(utils.isDisplayed(xpath.textCartGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Proceed to Checkout

            // Click 'Proceed to Checkout' button on the Cart page.
            utils.click(xpath.buttonCartProceedToCheckoutXpath);

            // Validate if user lands on 'Checkout' page.
            Assert.That(utils.isDisplayed(xpath.textCheckoutPageTitleXpath), Is.True);

            // Click on ‘Physical Shipping’ radio button on the Checkout page.
            utils.checkRadio(xpath.radioCheckoutPhysicalShippingXpath.Replace("{isPhysicalShipping}", dataIsPhysicalShipping));

            // Select 'Credit Card'
            // utils.setSelectByText(xpath.selectCheckoutXpathCreditCardIdXpath, dataIsCreditCardId);

            // Click on ‘Place your order’ button
            utils.click(xpath.buttonCheckoutPlaceYourOrderXpath);

            // Validate if error message is displayed on the ‘Checkout’ page. (The Credit Card field is required.)
            Assert.That(utils.getText(xpath.errorCheckoutCreditCardXpath), Is.EqualTo(errorCreditCardInvalid));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
