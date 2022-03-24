/*
 * GameTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.17: Created
 *      Jeonghwan Ju, 2021.10.31: Updated
 *      Jeonghwan Ju, 2021.12.07: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    public class GameTest
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
        public void TC01_VerifyGameSearchAndViewDetails()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataSearchGameName = "Tic Tac Toe";
            string dataSearchDescription = "This is very fun game";
            
            string dataGameName = "Tic Tac Toe Game";
            string dataGameDescription = "Game Description: This is very fun game.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘Selecting Games’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameSelectingGamesXpath);

            ////////////////////////////////////////////////////////////////////////////////
            // 1. Search by 'Game Name'
            // Enter 'Search Keyword'
            utils.setInput(xpath.inputSelectingGamesSearchStringXpath, dataSearchGameName);

            // Click on ‘Search’ button
            utils.click(xpath.buttonSelectingGamesSearchXpath);

            // Validate if new ‘searched game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isDisplayed(xpath.textSelectingGamesGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            // Check 'Select' checkbox
            utils.checkCheckbox(xpath.checkboxSelectingGamesSelectXpath.Replace("{gameName}", dataGameName));

            // Click on ‘Click to see the geme details!’ button
            utils.click(xpath.buttonSelectingGamesClickToSeeGemeDetailsXpath);

            // Validate if new ‘searched game’ is displayed on the ‘Game Details’ page.
            Assert.That(utils.isDisplayed(xpath.textSelectingGameDetailsGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);
            Assert.That(utils.isDisplayed(xpath.textSelectingGameDetailsGameDescriptionXpath.Replace("{gameDescription}", dataGameDescription)), Is.True);

            // Click on ‘ the the prevous page’ button
            utils.click(xpath.buttonSelectingGameDetailsGoToThePrevousPageXpath);

            ////////////////////////////////////////////////////////////////////////////////
            // 2. Search by 'Game Description'
            // Enter 'Search Keyword'
            utils.setInput(xpath.inputSelectingGamesSearchStringXpath, dataGameDescription);

            // Click on ‘Search’ button
            utils.click(xpath.buttonSelectingGamesSearchXpath);

            // Validate if new ‘searched game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isDisplayed(xpath.textSelectingGamesGameDescriptionXpath.Replace("{gameDescription}", dataGameDescription)), Is.True);

            // Check 'Select' checkbox
            utils.checkCheckbox(xpath.checkboxSelectingGamesSelectXpath.Replace("{gameName}", dataGameName));

            // Click on ‘Click to see the geme details!’ button
            utils.click(xpath.buttonSelectingGamesClickToSeeGemeDetailsXpath);

            // Validate if new ‘searched game’ is displayed on the ‘Game Details’ page.
            Assert.That(utils.isDisplayed(xpath.textSelectingGameDetailsGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);
            Assert.That(utils.isDisplayed(xpath.textSelectingGameDetailsGameDescriptionXpath.Replace("{gameDescription}", dataGameDescription)), Is.True);

            // Click on ‘ the the prevous page’ button
            utils.click(xpath.buttonSelectingGameDetailsGoToThePrevousPageXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC02_VerifyGameSearchWithNonExistData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataSearchGameName = "Non-Exist Game";

            string dataGameName = "Tic Tac Toe Game";
            string dataGameDescription = "Game Description: This is very fun game.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Game’ and click ‘Selecting Games’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameSelectingGamesXpath);

            // Enter 'Search Keyword'
            utils.setInput(xpath.inputSelectingGamesSearchStringXpath, dataSearchGameName);

            // Click on ‘Search’ button
            utils.click(xpath.buttonSelectingGamesSearchXpath);

            // Validate if no ‘searched game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isNotExist(xpath.checkboxSelectingGamesSelectAllXpath), Is.True);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
