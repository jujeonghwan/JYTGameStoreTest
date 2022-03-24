/*
 * LoginTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.11.11: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class LoginTest
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
        // Verify Member Login with Valid Data
        public void TC01_VerifyMemberLoginWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

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

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Employee Login with Valid Data
        public void TC02_VerifyEmployeeLoginWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            // Go to Main Page
            utils.goToMainPage();

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

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Member Login with Blank Data
        public void TC03_VerifyMemberLoginWithBlankData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = "";
            string dataLoginPassword = "";

            string errorEmailRequired = "The Email field is required.";
            string errorPasswordRequired = "The Password field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Click on 'Login' link on the top menu bar
            utils.click(xpath.linkMenuLoginXpath);

            // Validate if user lands on 'Login' page.
            Assert.That(utils.isDisplayed(xpath.textLoginPageTitleXpath), Is.True);

            // Enter 'Email' and 'Password'
            utils.setInput(xpath.inputLoginEmailXpath, dataLoginEmail);
            utils.setInput(xpath.inputLoginPasswordXpath, dataLoginPassword);

            // Click on ‘Login’ button
            utils.click(xpath.buttonLoginLoginXpath);

            // Validate if error message is displayed on the ‘Login’ page.
            Assert.That(utils.getText(xpath.errorLoginEmailXpath), Is.EqualTo(errorEmailRequired));
            Assert.That(utils.getText(xpath.errorLoginPasswordXpath), Is.EqualTo(errorPasswordRequired));

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Member Login With Non Exist Email
        public void TC04_VerifyMemberLoginWithNonExistEmail()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = "nonexistemail@email.com";
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string errorLoginSummary = "Invalid Email or Password";

            // Go to Main Page
            utils.goToMainPage();

            // Click on 'Login' link on the top menu bar
            utils.click(xpath.linkMenuLoginXpath);

            // Validate if user lands on 'Login' page.
            Assert.That(utils.isDisplayed(xpath.textLoginPageTitleXpath), Is.True);

            // Enter 'Email' and 'Password'
            utils.setInput(xpath.inputLoginEmailXpath, dataLoginEmail);
            utils.setInput(xpath.inputLoginPasswordXpath, dataLoginPassword);

            // Click on ‘Login’ button
            utils.click(xpath.buttonLoginLoginXpath);

            // Validate if error message is displayed on the ‘Login’ page.
            Assert.That(utils.getText(xpath.errorLoginSummaryXpath), Is.EqualTo(errorLoginSummary));

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Member Login With Wrong Password
        public void TC05_VerifyMemberLoginWithWrongPassword()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = "#Wrong-Password";

            string errorLoginSummary = "Invalid Email or Password";

            // Go to Main Page
            utils.goToMainPage();

            // Click on 'Login' link on the top menu bar
            utils.click(xpath.linkMenuLoginXpath);

            // Validate if user lands on 'Login' page.
            Assert.That(utils.isDisplayed(xpath.textLoginPageTitleXpath), Is.True);

            // Enter 'Email' and 'Password'
            utils.setInput(xpath.inputLoginEmailXpath, dataLoginEmail);
            utils.setInput(xpath.inputLoginPasswordXpath, dataLoginPassword);

            // Click on ‘Login’ button
            utils.click(xpath.buttonLoginLoginXpath);

            // Validate if error message is displayed on the ‘Login’ page.
            Assert.That(utils.getText(xpath.errorLoginSummaryXpath), Is.EqualTo(errorLoginSummary));

            // Close web browser.
            utils.close();
        }

    }
}
