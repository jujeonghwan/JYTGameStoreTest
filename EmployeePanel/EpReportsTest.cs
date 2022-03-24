/*
 * EpReportsTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.12.08: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.EmployeePanel
{
    [TestFixture]
    class EpReportsTest
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
        // Verify Games Report
        public void TC01_VerifyGamesReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Report Games’ link on the 'Reports' page.
            utils.click(xpath.linkReportsReportGamesXpath);

            // Validate if user lands on 'Games Report' page.
            Assert.That(utils.isDisplayed(xpath.textGamesReportTitleXpath), Is.True);

            // Click on ‘Download PDF’ button on the 'Games Report' page.
            utils.click(xpath.buttonGamesReportDownloadPdfXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Events Report
        public void TC02_VerifyEventsReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Events Games’ link on the 'Reports' page.
            utils.click(xpath.linkReportsReportEventsXpath);

            // Validate if user lands on 'Events Report' page.
            Assert.That(utils.isDisplayed(xpath.textEventsReportTitleXpath), Is.True);

            // Click on ‘Download PDF’ button on the 'Events Report' page.
            utils.click(xpath.buttonGamesReportDownloadPdfXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Download Members Report
        public void TC03_VerifyDownloadMembersReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Download Members Report’ link on the 'Reports' page.
            utils.click(xpath.linkReportsDownloadMembersReportXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Download Wishlist Report
        public void TC04_VerifyDownloadWishlistReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Download Wishlist Report’ link on the 'Reports' page.
            utils.click(xpath.linkReportsDownloadWishlistReportXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Download Orders Report
        public void TC05_VerifyDownloadOrdersReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Download Orders Report’ link on the 'Reports' page.
            utils.click(xpath.linkReportsDownloadOrdersReportXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Download Sales Report
        public void TC06_VerifyDownloadOrdersReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Download Sales Report’ link on the 'Reports' page.
            utils.click(xpath.linkReportsDownloadSalesReportXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Download Detail Member Report
        public void TC07_VerifyDownloadDetailMemberReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Download Detail Member Report’ link on the 'Reports' page.
            utils.click(xpath.linkReportsDownloadDetailMemberReportXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Download Detail Game Report
        public void TC08_VerifyDownloadDetailGameReport()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Reports’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReportsXpath);

            // Validate if user lands on 'Reports' page.
            Assert.That(utils.isDisplayed(xpath.textReportsPageTitleXpath), Is.True);

            // Click on ‘Download Detail Game Report’ link on the 'Reports' page.
            utils.click(xpath.linkReportsDownloadDetailGameReportXpath);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }



    }
}
