/*
 * CreditCardTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.11.08: Created
 *      Jeonghwan Ju, 2021.11.11: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class CreditCardTest
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
        // Verify Credit Card Add with Valid Data
        public void TC01_VerifyCreditCardAddWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "1234567890123452";
            string dataCCMonth = "04";
            string dataCCYear = "23";
            string dataCCPin = "123";
            
            string maskedCreditCardNumber = utils.getMaskedCreditCardNumber(dataCCNumber, "-");

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

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Validate if added 'Credit Card' is displayed on 'Credit Card' list page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Delete testing data

            // Click 'Delete' button
            utils.click(xpath.buttonCreditCardDeleteXpath.Replace("{creditCardNumber}", maskedCreditCardNumber));

            // Validate if user lands on 'Delete Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardDeletePageTitleXpath), Is.True);

            // Click 'Delete' button on the 'Delete' page
            utils.click(xpath.buttonCreditCardDeleteDeleteCreditCardXpath);

            // Check credit card is deleted on 'Credit Card List' page.
            Assert.IsTrue(utils.isNotExist(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber)));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Credit Card Edit with Valid Data
        public void TC02_VerifyCreditCardEditWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "1234567890123452";
            string dataCCMonth = "04";
            string dataCCYear = "23";
            string dataCCPin = "123";

            string dataCCNumber2 = "5678901234567898";
            string dataCCMonth2 = "09";
            string dataCCYear2 = "24";
            string dataCCPin2 = "456";

            string maskedCreditCardNumber = utils.getMaskedCreditCardNumber(dataCCNumber, "-");
            string maskedCreditCardNumber2 = utils.getMaskedCreditCardNumber(dataCCNumber2, "-");

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

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Validate if added 'Credit Card' is displayed on 'Credit Card' list page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Edit data

            // Click 'Edit' button
            utils.click(xpath.buttonCreditCardEditXpath.Replace("{creditCardNumber}", maskedCreditCardNumber));

            // Validate if user lands on 'Edit Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardEditPageTitleXpath), Is.True);

            // Enter credit card into for edit
            utils.setInput(xpath.inputCreditCardEditCreditCardNumberXpath, dataCCNumber2);
            utils.setInput(xpath.inputCreditCardEditExpireMonthXpath, dataCCMonth2);
            utils.setInput(xpath.inputCreditCardEditExpireYearXpath, dataCCYear2);
            utils.setInput(xpath.inputCreditCardEditPinXpath, dataCCPin2);

            // Click on ‘Save Credit Card’ button
            utils.click(xpath.buttonCreditCardEditSaveCreditCardXpath);

            // Validate if edited 'Credit Card' is displayed on 'Credit Card' list page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber2)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Delete testing data

            // Click 'Delete' button
            utils.click(xpath.buttonCreditCardDeleteXpath.Replace("{creditCardNumber}", maskedCreditCardNumber2));

            // Validate if user lands on 'Delete Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardDeletePageTitleXpath), Is.True);

            // Click 'Delete' button on the 'Delete' page
            utils.click(xpath.buttonCreditCardDeleteDeleteCreditCardXpath);

            // Check credit card is deleted on 'Credit Card List' page.
            Assert.IsTrue(utils.isNotExist(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber2)));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Credit Card Delete
        public void TC03_VerifyCreditCardDelete()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "1234567890123452";
            string dataCCMonth = "04";
            string dataCCYear = "23";
            string dataCCPin = "123";

            string maskedCreditCardNumber = utils.getMaskedCreditCardNumber(dataCCNumber, "-");

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

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Validate if added 'Credit Card' is displayed on 'Credit Card' list page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Delete testing data

            // Click 'Delete' button
            utils.click(xpath.buttonCreditCardDeleteXpath.Replace("{creditCardNumber}", maskedCreditCardNumber));

            // Validate if user lands on 'Delete Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardDeletePageTitleXpath), Is.True);

            // Click 'Delete' button on the 'Delete' page
            utils.click(xpath.buttonCreditCardDeleteDeleteCreditCardXpath);

            // Check credit card is deleted on 'Credit Card List' page.
            Assert.IsTrue(utils.isNotExist(xpath.textCreditCardCreditCardNumberXpath.Replace("{creditCardNumber}", maskedCreditCardNumber)));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Credit Card Add with Blank Card Info
        public void TC04_VerifyCreditCardAddWithBlankCardInfo()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "";
            string dataCCMonth = "";
            string dataCCYear = "";
            string dataCCPin = "";

            string errorCreditCardNumberRequired = "The Credit Card # field is required.";
            string errorExpiryMonthRequired = "The Expiry Month field is required.";
            string errorExpiryYearRequired = "The Expiry Year field is required.";
            string errorPinRequired = "The PIN field is required.";

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

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);

            // Validate if error message is displayed on the ‘Credit Card Add’ page.
            Assert.That(utils.getText(xpath.errorCreditCardAddCreditCardNumberXpath), Is.EqualTo(errorCreditCardNumberRequired));
            Assert.That(utils.getText(xpath.errorCreditCardAddExpireMonthXpath), Is.EqualTo(errorExpiryMonthRequired));
            Assert.That(utils.getText(xpath.errorCreditCardAddExpireYearXpath), Is.EqualTo(errorExpiryYearRequired));
            Assert.That(utils.getText(xpath.errorCreditCardAddPinXpath), Is.EqualTo(errorPinRequired));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Credit Card Add with Invalid Credit Card Number
        public void TC05_VerifyCreditCardAddWithInvalidCreditCardNumber()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "1234567890129999";
            string dataCCMonth = "04";
            string dataCCYear = "23";
            string dataCCPin = "123";

            string errorCreditCardNumberInvalid = "The Credit Card # field is not a valid credit card number.";            

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

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);

            // Validate if error message is displayed on the ‘Credit Card Add’ page.
            Assert.That(utils.getText(xpath.errorCreditCardAddCreditCardNumberValidationXpath), Is.EqualTo(errorCreditCardNumberInvalid));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Credit Card Add with Past Expiry Month Year
        public void TC06_VerifyCreditCardAddWithPastExpiryMonthYear()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "1234567890123452";
            string dataCCMonth = "06";
            string dataCCYear = "19";
            string dataCCPin = "123";

            string errorExpiryYearInvalid = "Please check the year again";

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

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);

            // Validate if error message is displayed on the ‘Credit Card Add’ page.
            Assert.That(utils.getText(xpath.errorCreditCardAddExpireYearValidationXpath), Is.EqualTo(errorExpiryYearInvalid));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Credit Card Add with Character Instead Number
        public void TC07_VerifyCreditCardAddWithPastExpiryMonthYear()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataCCNumber = "ABCDEFGHIJKLMNOP";
            string dataCCMonth = "QR";
            string dataCCYear = "ST";
            string dataCCPin = "UVW";

            string errorCreditCardNumberInvalid = "The Credit Card # field is not a valid credit card number.";
            string errorExpiryMonthInvalid = "Please check the month again";
            string errorExpiryYearInvalid = "Please check the year again";
            string errorPinInvalid = "Your PIN is the 3 digits behind your card";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Credit Cards’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserCreditCardsXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardPageTitleXpath), Is.True);

            // Click on ‘Add Credit Card’ button on the Credit Card list page.
            utils.click(xpath.buttonCreditCardAddCreditCardXpath);

            // Validate if user lands on 'Add New Credit Card' page.
            Assert.That(utils.isDisplayed(xpath.textCreditCardAddPageTitleXpath), Is.True);

            // Enter credit card into.
            utils.setInput(xpath.inputCreditCardAddCreditCardNumberXpath, dataCCNumber);
            utils.setInput(xpath.inputCreditCardAddExpireMonthXpath, dataCCMonth);
            utils.setInput(xpath.inputCreditCardAddExpireYearXpath, dataCCYear);
            utils.setInput(xpath.inputCreditCardAddPinXpath, dataCCPin);

            // Click on ‘Add Credit Card’ button
            utils.setFocus(xpath.buttonCreditCardAddAddCreditCardXpath);
            utils.click(xpath.buttonCreditCardAddAddCreditCardXpath);
            
            // Validate if error message is displayed on the ‘Credit Card Add’ page.            
            Assert.That(utils.getText(xpath.errorCreditCardAddCreditCardNumberValidationXpath), Is.EqualTo(errorCreditCardNumberInvalid));
            Assert.That(utils.getText(xpath.errorCreditCardAddExpireMonthValidationXpath), Is.EqualTo(errorExpiryMonthInvalid));
            Assert.That(utils.getText(xpath.errorCreditCardAddExpireYearValidationXpath), Is.EqualTo(errorExpiryYearInvalid));
            Assert.That(utils.getText(xpath.errorCreditCardAddPinValidationXpath), Is.EqualTo(errorPinInvalid));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
