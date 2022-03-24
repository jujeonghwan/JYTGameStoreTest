/*
 * UserRegistrationTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.29: Created
 *      Jeonghwan Ju, 2021.10.31: Updated
 *      Jeonghwan Ju, 2021.12.08: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class UserRegistrationTest
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
        // Verify User Registration With Valid Data
        public void TC01_VerifyUserRegistrationWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME3;
            string dataEmail = Shared.MEMBER_LOGIN_EMAIL3;
            string dataPassword = Shared.MEMBER_LOGIN_PASSWORD3;
            string dataConfirmPassword = Shared.MEMBER_LOGIN_PASSWORD3;
            string dataCaptcha = "";
            string dataUserRegistrationSuccessAlert = "Please Confirm your email to login.";

            // Go to Main Page
            utils.goToMainPage();

            // Click on ‘Register’ link on the top menu bar
            utils.click(xpath.linkMenuRegisterXpath);

            // Validate if 'User Registration' page is displayed.
            Assert.That(utils.isDisplayed(xpath.titleUserRegistrationXpath), Is.True);

            // Enter 'User Registration' information
            utils.setInput(xpath.inputUserRegistrationUserNameXpath, dataUserName);
            utils.setInput(xpath.inputUserRegistrationEmailXpath, dataEmail);
            utils.setInput(xpath.inputUserRegistrationPasswordXpath, dataPassword);
            utils.setInput(xpath.inputUserRegistrationConfirmPasswordXpath, dataConfirmPassword);

            utils.sleep(5);
            
            dataCaptcha = utils.getPromptText("Please enter the Captcha.");
            utils.setInput(xpath.inputUserRegistrationCaptchaXpath, dataCaptcha);
            
            // Click on ‘Register’ button
            utils.click(xpath.buttonUserRegistrationRegisterXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataUserRegistrationSuccessAlert), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify User Registration With Blank Data
        public void TC02_VerifyUserRegistrationWithBlankData()
        {
            // Test Data
            string dataUserName = "";
            string dataEmail = "";
            string dataPassword = "";
            string dataConfirmPassword = "";
            string dataCaptcha = "";

            string errorUserNameRequired = "UserName is Required";
            string errorEmailRequired = "Email is Required";
            string errorPasswordRequired = "The Password field is required.";
            string errorConfirmPasswordRequired = "The Confirm password field is required.";
            string errorCaptchaRequired = "Please re-enter security code.";

            // string dataUserRegistrationSuccessAlert = "Please Confirm your email to login.";

            // Go to Main Page
            utils.goToMainPage();

            // Click on ‘Register’ link on the top menu bar
            utils.click(xpath.linkMenuRegisterXpath);

            // Validate if 'User Registration' page is displayed.
            Assert.That(utils.isDisplayed(xpath.titleUserRegistrationXpath), Is.True);

            // Enter 'User Registration' information
            utils.setInput(xpath.inputUserRegistrationUserNameXpath, dataUserName);
            utils.setInput(xpath.inputUserRegistrationEmailXpath, dataEmail);
            utils.setInput(xpath.inputUserRegistrationPasswordXpath, dataPassword);
            utils.setInput(xpath.inputUserRegistrationConfirmPasswordXpath, dataConfirmPassword);
            utils.setInput(xpath.inputUserRegistrationCaptchaXpath, dataCaptcha);

            // Click on ‘Register’ button
            utils.click(xpath.buttonUserRegistrationRegisterXpath);

            // Validate if error message is displayed on the ‘User Registration’ page.
            Assert.That(utils.getText(xpath.errorUserRegistrationUserNameXpath), Is.EqualTo(errorUserNameRequired));
            Assert.That(utils.getText(xpath.errorUserRegistrationEmailXpath), Is.EqualTo(errorEmailRequired));
            Assert.That(utils.getText(xpath.errorUserRegistrationPasswordXpath), Is.EqualTo(errorPasswordRequired));
            Assert.That(utils.getText(xpath.errorUserRegistrationConfirmPasswordXpath), Is.EqualTo(errorConfirmPasswordRequired));
            Assert.That(utils.getText(xpath.errorUserRegistrationCaptchaXpath), Is.EqualTo(errorCaptchaRequired));

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify User Registration With Duplicate User Name
        public void TC03_VerifyUserRegistrationWithDuplicateUserName()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataEmail = "newemail@outlook.com";
            string dataPassword = Shared.MEMBER_USER_NAME;
            string dataConfirmPassword = Shared.MEMBER_USER_NAME;
            string dataCaptcha = "";

            string errorUserNameRequired = dataUserName + " is already taken";

            // Go to Main Page
            utils.goToMainPage();

            // Click on ‘Register’ link on the top menu bar
            utils.click(xpath.linkMenuRegisterXpath);

            // Validate if 'User Registration' page is displayed.
            Assert.That(utils.isDisplayed(xpath.titleUserRegistrationXpath), Is.True);

            // Enter 'User Registration' information
            utils.setInput(xpath.inputUserRegistrationUserNameXpath, dataUserName);
            utils.setInput(xpath.inputUserRegistrationEmailXpath, dataEmail);
            utils.setInput(xpath.inputUserRegistrationPasswordXpath, dataPassword);
            utils.setInput(xpath.inputUserRegistrationConfirmPasswordXpath, dataConfirmPassword);
            utils.setInput(xpath.inputUserRegistrationCaptchaXpath, dataCaptcha);

            // Click on ‘Register’ button
            utils.click(xpath.buttonUserRegistrationRegisterXpath);

            // Validate if error message is displayed on the ‘User Registration’ page.
            Assert.That(utils.getText(xpath.errorUserRegistrationUserNameXpath), Is.EqualTo(errorUserNameRequired));
            
            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify User Registration With Duplicate Email
        public void TC04_VerifyUserRegistrationWithDuplicateEmail()
        {
            // Test Data
            string dataUserName = "NewUserName";
            string dataEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataPassword = Shared.MEMBER_USER_NAME;
            string dataConfirmPassword = Shared.MEMBER_USER_NAME;
            string dataCaptcha = "";

            string errorEmailRequired = dataEmail + " is already taken";

            // Go to Main Page
            utils.goToMainPage();

            // Click on ‘Register’ link on the top menu bar
            utils.click(xpath.linkMenuRegisterXpath);

            // Validate if 'User Registration' page is displayed.
            Assert.That(utils.isDisplayed(xpath.titleUserRegistrationXpath), Is.True);

            // Enter 'User Registration' information
            utils.setInput(xpath.inputUserRegistrationUserNameXpath, dataUserName);
            utils.setInput(xpath.inputUserRegistrationEmailXpath, dataEmail);
            utils.setInput(xpath.inputUserRegistrationPasswordXpath, dataPassword);
            utils.setInput(xpath.inputUserRegistrationConfirmPasswordXpath, dataConfirmPassword);
            utils.setInput(xpath.inputUserRegistrationCaptchaXpath, dataCaptcha);

            // Click on ‘Register’ button
            utils.click(xpath.buttonUserRegistrationRegisterXpath);

            // Validate if error message is displayed on the ‘User Registration’ page.
            Assert.That(utils.getText(xpath.errorUserRegistrationEmailXpath), Is.EqualTo(errorEmailRequired));

            // Close web browser.
            utils.close();
        }

    }
}
