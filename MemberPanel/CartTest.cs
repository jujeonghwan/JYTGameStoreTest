/*
 * CartTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.11.05: Created
 *      Jeonghwan Ju, 2021.11.11: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class CartTest
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
        // Verify Cart Add with Valid Data
        public void TC01_VerifyCartAddWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";
            string dataCartDeleteConfirmAlert = "Are you sure to delete this game in the cart?";

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
            // Delete testing data

            // Click 'Delete' button on the Cart page.
            utils.click(xpath.buttonCartDeleteXpath.Replace("{gameName}", dataGameName));

            // Validate if 'alert' message is displayed. (Are you sure to delete this game in the cart?)
            Assert.That(utils.acceptAlertMessage(dataCartDeleteConfirmAlert), Is.True);

            // Check the game is deleted on 'Cart' page.
            Assert.IsTrue(utils.isNotExist(xpath.textCartGameNameXpath.Replace("{gameName}", dataGameName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Cart Delete with Valid Data
        public void TC02_VerifyCartDeleteWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameName = "";
            string dataCartDeleteConfirmAlert = "Are you sure to delete this game in the cart?";

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
            // Delete testing data

            // Click 'Delete' button on the Cart page.
            utils.click(xpath.buttonCartDeleteXpath.Replace("{gameName}", dataGameName));

            // Validate if 'alert' message is displayed. (Are you sure to delete this game in the cart?)
            Assert.That(utils.acceptAlertMessage(dataCartDeleteConfirmAlert), Is.True);

            // Check the game is deleted on 'Cart' page.
            Assert.IsTrue(utils.isNotExist(xpath.textCartGameNameXpath.Replace("{gameName}", dataGameName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
