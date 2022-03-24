/*
 * EpGameTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.16: Created
 *      Jeonghwan Ju, 2021.10.17: Updated
 *      Jeonghwan Ju, 2021.10.31: Updated
 *      Jeonghwan Ju, 2021.11.11: Updated
 *      Jeonghwan Ju, 2021.12.07: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.EmployeePanel
{
    [TestFixture]
    public class EpGameTest
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
        public void TC01_VerifyGameCreateWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataGameName = "Star Craft Game";
            string dataGameCategory = "Sandbox";
            string dataPrice = "19.9";
            string dataGameDescription = "This is new good game.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelGameXpath);

            // Click on ‘Create a New Game’ button
            utils.click(xpath.buttonGameListCreateNewEventXpath);

            // Enter ‘Game’ info
            utils.setInput(xpath.inputGameAddGameNameXpath, dataGameName);
            utils.setSelectByText(xpath.selectGameAddGameCategoryXpath, dataGameCategory);
            utils.setInput(xpath.inputGameAddPriceXpath, dataPrice);
            utils.setInput(xpath.inputGameAddGameDescriptionXpath, dataGameDescription);

            // Click on ‘Create a game’ button
            utils.click(xpath.buttonGameAddCreateGameXpath);

            // Validate if new ‘added game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isDisplayed(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonGameListDeleteXpath.Replace("{gameName}", dataGameName));

            // Click 'Delete a game' button
            utils.click(xpath.buttonGameDeteteDeteteGameXpath);

            // Check game is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC02_VerifyGameCreateWithInvalidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataGameName = "";           // blank data
            string dataGameCategory = "";
            string dataPrice = "";
            string dataGameDescription = "";

            string errorGameNameRequired = "The Game Name field is required.";
            string errorGameDescriptionRequired = "The Game Description field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelGameXpath);

            // Click on ‘Create a New Game’ button
            utils.click(xpath.buttonGameListCreateNewEventXpath);

            // Enter ‘Game’ info
            utils.setInput(xpath.inputGameAddGameNameXpath, dataGameName);
            utils.setSelectByText(xpath.selectGameAddGameCategoryXpath, dataGameCategory);
            utils.setInput(xpath.inputGameAddPriceXpath, dataPrice);
            utils.setInput(xpath.inputGameAddGameDescriptionXpath, dataGameDescription);

            // Click on ‘Create a game’ button
            utils.click(xpath.buttonGameAddCreateGameXpath);

            // Validate if error message is displayed on the ‘Game Add’ page.
            Assert.That(utils.getText(xpath.errorGameAddGameNameXpath), Is.EqualTo(errorGameNameRequired));
            Assert.That(utils.getText(xpath.errorGameAddGameDescriptionXpath), Is.EqualTo(errorGameDescriptionRequired));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC03_VerifyGameEditWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataGameName = "Star Craft";
            string dataGameCategory = "Sandbox";
            string dataPrice = "21";
            string dataGameDescription = "This is new good game.";

            string dataGameName2 = "Star Craft2";
            string dataGameCategory2 = "Multiplayer online battle arena (MOBA)";
            string dataPrice2 = "33";
            string dataGameDescription2 = "This is new good game2.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelGameXpath);

            // Click on ‘Create a New Game’ button
            utils.click(xpath.buttonGameListCreateNewEventXpath);

            // Enter ‘Game’ info (new)
            utils.setInput(xpath.inputGameAddGameNameXpath, dataGameName);
            utils.setSelectByText(xpath.selectGameAddGameCategoryXpath, dataGameCategory);
            utils.setInput(xpath.inputGameAddPriceXpath, dataPrice);
            utils.setInput(xpath.inputGameAddGameDescriptionXpath, dataGameDescription);

            // Click on ‘Create a game’ button
            utils.click(xpath.buttonGameAddCreateGameXpath);

            // Validate if new ‘added game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isDisplayed(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);

            // Click 'Edit' button on the ‘Game List’ page.
            utils.click(xpath.buttonGameListEditXpath.Replace("{gameName}", dataGameName));

            // Enter ‘Game’ info (edit)
            utils.setInput(xpath.inputGameAddGameNameXpath, dataGameName2);
            utils.setSelectByText(xpath.selectGameAddGameCategoryXpath, dataGameCategory2);
            utils.setInput(xpath.inputGameAddPriceXpath, dataPrice2);
            utils.setInput(xpath.inputGameAddGameDescriptionXpath, dataGameDescription2);

            // Click 'Edit a game' button
            utils.click(xpath.buttonGameEditCreateGameXpath);

            // Validate if new ‘updated game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isDisplayed(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName2)), Is.True);
            
            // Delete Testing Data
            utils.click(xpath.buttonGameListDeleteXpath.Replace("{gameName}", dataGameName2));

            // Click 'Delete a game' button
            utils.click(xpath.buttonGameDeteteDeteteGameXpath);

            // Check game is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName2)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC04_VerifyGameDelete()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataGameName = "Star Craft Delete";
            string dataGameCategory = "Sandbox";
            string dataPrice = "21";
            string dataGameDescription = "This is new good game. (Delete)";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelGameXpath);

            // Click on ‘Create a New Game’ button
            utils.click(xpath.buttonGameListCreateNewEventXpath);

            // Enter ‘Game’ info
            utils.setInput(xpath.inputGameAddGameNameXpath, dataGameName);
            utils.setSelectByText(xpath.selectGameAddGameCategoryXpath, dataGameCategory);
            utils.setInput(xpath.inputGameAddPriceXpath, dataPrice);
            utils.setInput(xpath.inputGameAddGameDescriptionXpath, dataGameDescription);

            // Click on ‘Create a game’ button
            utils.click(xpath.buttonGameAddCreateGameXpath);

            // Validate if new ‘added game’ is displayed on the ‘Game List’ page.
            Assert.That(utils.isDisplayed(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName)), Is.True);
            
            // Delete Testing Data
            utils.click(xpath.buttonGameListDeleteXpath.Replace("{gameName}", dataGameName));

            // Click 'Delete a game' button
            utils.click(xpath.buttonGameDeteteDeteteGameXpath);

            // Check game is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textGameListGameNameXpath.Replace("{gameName}", dataGameName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
