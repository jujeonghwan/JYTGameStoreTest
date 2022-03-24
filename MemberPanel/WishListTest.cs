/*
 * WishListTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.11.05: Created
 *      Jeonghwan Ju, 2021.12.08: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class WishListTest
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
        // Verify WishList Add with Valid Data
        public void TC01_VerifyWishListAddWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";

            // Go to ‘Home page’
            utils.goToUrl(testURL);

            // Validate if user lands on 'Main' page.
            Assert.That(utils.isDisplayed(xpath.textMainPageTitleXpath), Is.True);

            // Click on 'Login' link on the top menu bar
            utils.click(xpath.linkMenuLoginXpath);

            // Validate if user lands on 'Login' page.
            Assert.That(utils.isDisplayed(xpath.textLoginPageTitleXpath), Is.True);

            // Enter 'Email' and 'Password'
            utils.setInput(xpath.inputLoginEmailXpath, dataLoginEmail);
            utils.setInput(xpath.inputLoginPasswordXpath, dataLoginPassword);

            // Click on ‘Login’ button
            utils.click(xpath.buttonLoginLoginXpath);

            // Validate if use logged in successfully and user name displayed on the top menu on the page.
            Assert.That(utils.isDisplayed(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName)), Is.True);

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

            // Click on ‘Add to wish list!’ button
            utils.click(xpath.buttonGameDetailsAddToWishListXpath);

            // Validate if 'alert' message is displayed.
            // Assert.That(utils.acceptAlertMessage(dataWishListAddAlert), Is.True);

            // Validate if user lands on 'Wish List' page.
            Assert.That(utils.isDisplayed(xpath.textWishListPageTitleXpath), Is.True);

            // Validate if 'added Wish List' is displayed on the 'Wish List' page.
            Assert.That(utils.isDisplayed(xpath.textWishListGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Delete testing data

            // Click 'Delete' button
            utils.click(xpath.buttonWishListDeleteXpath.Replace("{gameName}", dataGameName));

            // Validate if user lands on 'Wish List Delete' page.
            Assert.That(utils.isDisplayed(xpath.textWishListDeletePageTitleXpath), Is.True);

            // Click 'Delete' button on the 'Delete' page
            utils.click(xpath.buttonWishListDeleteDeleteXpath);

            // Check Wish List is deleted on 'Wish List' page.
            Assert.IsTrue(utils.isNotExist(xpath.buttonWishListDeleteXpath.Replace("{gameName}", dataGameName)));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }
    }
}
