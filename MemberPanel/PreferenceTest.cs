/*
 * PreferenceTest.cs
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
    class PreferenceTest
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
        // Verify Preference Checked with Valid Data
        public void TC01_VerifyPreferenceCheckedWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataPlatformChecked = "Android (MOBILE)";
            string dataCategoryChecked = "Platformer";

            string dataPreferenceSavesuccessfulAlert = "Your Preference has been successfully saved.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Preference’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserPreferenceXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Preference' page.
            Assert.That(utils.isDisplayed(xpath.textPreferencePageTitleXpath), Is.True);

            // Check 'Favorite Platform'
            utils.checkCheckbox(xpath.checkboxPreferencePlatformXpath.Replace("{platform}", dataPlatformChecked));

            // Check 'Favorite Category'
            utils.checkCheckbox(xpath.checkboxPreferenceCategoryXpath.Replace("{category}", dataCategoryChecked));

            // Click on ‘Save’ button on the Preference page.
            utils.click(xpath.buttonPreferenceSaveXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataPreferenceSavesuccessfulAlert), Is.True);

            // Validate Preference info on 'Preference' page.
            Assert.That(utils.getCheckboxChecked(xpath.checkboxPreferencePlatformXpath.Replace("{platform}", dataPlatformChecked)), Is.True);
            Assert.That(utils.getCheckboxChecked(xpath.checkboxPreferenceCategoryXpath.Replace("{category}", dataCategoryChecked)), Is.True);
            
            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Preference Unchecked with Valid Data
        public void TC01_VerifyPreferenceUncheckedWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataPlatformChecked = "Android (MOBILE)";
            string dataCategoryChecked = "Platformer";

            string dataPreferenceSavesuccessfulAlert = "Your Preference has been successfully saved.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Preference’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserPreferenceXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Preference' page.
            Assert.That(utils.isDisplayed(xpath.textPreferencePageTitleXpath), Is.True);

            // Uncheck 'Favorite Platform'
            utils.uncheckCheckbox(xpath.checkboxPreferencePlatformXpath.Replace("{platform}", dataPlatformChecked));

            // Uncheck 'Favorite Category'
            utils.uncheckCheckbox(xpath.checkboxPreferenceCategoryXpath.Replace("{category}", dataCategoryChecked));

            // Click on ‘Save’ button on the Preference page.
            utils.click(xpath.buttonPreferenceSaveXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataPreferenceSavesuccessfulAlert), Is.True);

            // Validate Preference info on 'Preference' page.
            Assert.That(utils.getCheckboxChecked(xpath.checkboxPreferencePlatformXpath.Replace("{platform}", dataPlatformChecked)), Is.False);
            Assert.That(utils.getCheckboxChecked(xpath.checkboxPreferenceCategoryXpath.Replace("{category}", dataCategoryChecked)), Is.False);

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
    }
}
