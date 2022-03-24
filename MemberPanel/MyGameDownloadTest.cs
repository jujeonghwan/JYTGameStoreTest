/*
 * MyGameDownloadTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.12.08: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class MyGameDownloadTest
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
        // Verify Game Download
        public void TC01_VerifyGameDownload()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataGameName = "test";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘My Game’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameMyGameXpath);

            // Validate if user lands on 'My Game' page.
            Assert.That(utils.isDisplayed(xpath.textMyGamePageTitleXpath), Is.True);

            // Validate if the game is displayed on the ‘My Game’ page.
            Assert.That(utils.isDisplayed(xpath.textMyGameGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            // Click on ‘Download’ button
            utils.click(xpath.buttonMyGameDownloadXpath.Replace("{gameName}", dataGameName));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Game Download Failed
        public void TC02_VerifyGameDownloadFailed()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataGameName = "Cool";
            string dataGameDownloadFailedAlert = "Failed to download.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘My Game’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameMyGameXpath);

            // Validate if user lands on 'My Game' page.
            Assert.That(utils.isDisplayed(xpath.textMyGamePageTitleXpath), Is.True);

            // Validate if the game is displayed on the ‘My Game’ page.
            Assert.That(utils.isDisplayed(xpath.textMyGameGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            // Click on ‘Download’ button
            utils.click(xpath.buttonMyGameDownloadXpath.Replace("{gameName}", dataGameName));

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataGameDownloadFailedAlert), Is.True);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
    }
}
