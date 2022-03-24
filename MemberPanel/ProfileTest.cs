/*
 * ProfileTest.cs
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
    class ProfileTest
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
        // Verify Profile with Valid Data
        public void TC01_VerifyProfileWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataFirstName = "Tom";
            string dataLastName = "Johnson";
            string dataGender = "Male";
            string dataDateOfBirth = "1999" + Keys.Tab + "1208";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Profile’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserProfileXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Profile' page.
            Assert.That(utils.isDisplayed(xpath.textProfilePageTitleXpath), Is.True);

            // Click on ‘Edit My Profile’ button on the Profile page.
            utils.click(xpath.buttonProfileEditMyProfileXpath);

            // Validate if user lands on 'Profile Edit' page.
            Assert.That(utils.isDisplayed(xpath.textProfileEditPageTitleXpath), Is.True);

            // Enter profile info
            utils.setInput(xpath.inputProfileEditFirstNameXpath, dataFirstName);
            utils.setInput(xpath.inputProfileEditLastNameXpath, dataLastName);
            utils.setSelectByText(xpath.selectProfileEditGenderXpath, dataGender);
            utils.setInput(xpath.inputProfileEditDateOfBirthXpath, dataDateOfBirth);

            // Click on ‘Save’ button on the Profile Edit page.
            utils.click(xpath.buttonProfileEditSaveXpath);
                        
            // Validate if user lands on 'Profile' page.
            Assert.That(utils.isDisplayed(xpath.textProfilePageTitleXpath), Is.True);

            // Validate profile info on 'Profile' page.
            Assert.That(utils.getInputValue(xpath.inputProfileFirstNameXpath).Equals(dataFirstName));
            Assert.That(utils.getInputValue(xpath.inputProfileLastNameXpath).Equals(dataLastName));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Profile Update with Valid Data
        public void TC02_VerifyProfileWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataFirstName = "James";
            string dataLastName = "Wilson";
            string dataGender = "Female";
            string dataDateOfBirth = "2010" + Keys.Tab + "1015";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Profile’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserProfileXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Profile' page.
            Assert.That(utils.isDisplayed(xpath.textProfilePageTitleXpath), Is.True);

            // Click on ‘Edit My Profile’ button on the Profile page.
            utils.click(xpath.buttonProfileEditMyProfileXpath);

            // Validate if user lands on 'Profile Edit' page.
            Assert.That(utils.isDisplayed(xpath.textProfileEditPageTitleXpath), Is.True);

            // Enter profile info
            utils.setInput(xpath.inputProfileEditFirstNameXpath, dataFirstName);
            utils.setInput(xpath.inputProfileEditLastNameXpath, dataLastName);
            utils.setSelectByText(xpath.selectProfileEditGenderXpath, dataGender);
            utils.setInput(xpath.inputProfileEditDateOfBirthXpath, dataDateOfBirth);

            // Click on ‘Save’ button on the Profile Edit page.
            utils.click(xpath.buttonProfileEditSaveXpath);

            // Validate if user lands on 'Profile' page.
            Assert.That(utils.isDisplayed(xpath.textProfilePageTitleXpath), Is.True);

            // Validate profile info on 'Profile' page.
            Assert.That(utils.getInputValue(xpath.inputProfileFirstNameXpath).Equals(dataFirstName));
            Assert.That(utils.getInputValue(xpath.inputProfileLastNameXpath).Equals(dataLastName));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
    }
}
