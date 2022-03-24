/*
 * AddressTest.cs
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
    class AddressTest
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
        // Verify Address Save with Valid Data
        public void TC01_VerifyAddressSaveWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataMailingStreetAddress = "321";
            string dataMailingStreetAddress2 = "Unit 4";
            string dataMailingCity = "Waterloo";
            string dataMailingProvince = "Ontario";
            string dataMailingPostalCode = "N2L0A2";

            bool dataMailingShippingSame = false;

            string dataShippingStreetAddress = "555";
            string dataShippingStreetAddress2 = "Unit 55";
            string dataShippingCity = "Kitchener";
            string dataShippingProvince = "Ontario";
            string dataShippingPostalCode = "N5N5N5";

            string dataAddressSavesuccessfulAlert = "Your Address has been successfully saved.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Address’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserAddressXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Address' page.
            Assert.That(utils.isDisplayed(xpath.textAddressPageTitleXpath), Is.True);

            // Click on ‘Edit Address’ button on the Address page.
            utils.click(xpath.buttonAddressEditAddressXpath);

            // Validate if user lands on 'Address Edit' page.
            Assert.That(utils.isDisplayed(xpath.textAddressEditPageTitleXpath), Is.True);

            // Enter Address info
            utils.setInput(xpath.inputAddressEditMailingStreetAddressXpath, dataMailingStreetAddress);
            utils.setInput(xpath.inputAddressEditMailingStreetAddress2Xpath, dataMailingStreetAddress2);
            utils.setInput(xpath.inputAddressEditMailingCityXpath, dataMailingCity);
            utils.setSelectByText(xpath.selectAddressEditMailingProvinceCodeXpath, dataMailingProvince);
            utils.setInput(xpath.inputAddressEditMailingPostalCodeXpath, dataMailingPostalCode);

            utils.uncheckCheckbox(xpath.checkboxAddressEditMailingShippingSameXpath);

            utils.setInput(xpath.inputAddressEditShippingStreetAddressXpath, dataShippingStreetAddress);
            utils.setInput(xpath.inputAddressEditShippingStreetAddress2Xpath, dataShippingStreetAddress2);
            utils.setInput(xpath.inputAddressEditShippingCityXpath, dataShippingCity);
            utils.setSelectByText(xpath.selectAddressEditShippingProvinceCodeXpath, dataShippingProvince);
            utils.setInput(xpath.inputAddressEditShippingPostalCodeXpath, dataShippingPostalCode);

            // Click on ‘Save Address’ button on the 'Address Edit' page.
            utils.click(xpath.buttonAddressEditSaveAddressXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataAddressSavesuccessfulAlert), Is.True);

            // Validate if user lands on 'Address' page.
            Assert.That(utils.isDisplayed(xpath.textAddressPageTitleXpath), Is.True);

            // Validate Address info on 'Address' page.
            Assert.That(utils.getInputValue(xpath.inputAddressMailingStreetAddressXpath).Equals(dataMailingStreetAddress));
            Assert.That(utils.getInputValue(xpath.inputAddressMailingStreetAddress2Xpath).Equals(dataMailingStreetAddress2));
            Assert.That(utils.getInputValue(xpath.inputAddressMailingCityXpath).Equals(dataMailingCity));
            Assert.That(utils.getInputValue(xpath.inputAddressMailingPostalCodeXpath).Equals(dataMailingPostalCode));

            Assert.That(utils.getInputValue(xpath.inputAddressShippingStreetAddressXpath).Equals(dataShippingStreetAddress));
            Assert.That(utils.getInputValue(xpath.inputAddressShippingStreetAddress2Xpath).Equals(dataShippingStreetAddress2));
            Assert.That(utils.getInputValue(xpath.inputAddressShippingCityXpath).Equals(dataShippingCity));
            Assert.That(utils.getInputValue(xpath.inputAddressShippingPostalCodeXpath).Equals(dataShippingPostalCode));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Address Save with Same Mailing and Shipping
        public void TC02_VerifyAddressSaveWithSameMailingAndShipping()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataMailingStreetAddress = "321";
            string dataMailingStreetAddress2 = "Unit 4";
            string dataMailingCity = "Waterloo";
            string dataMailingProvince = "Ontario";
            string dataMailingPostalCode = "N2L0A2";

            bool dataMailingShippingSame = true;

            string dataShippingStreetAddress = dataMailingStreetAddress;
            string dataShippingStreetAddress2 = dataMailingStreetAddress2;
            string dataShippingCity = dataMailingCity;
            string dataShippingProvince = dataMailingProvince;
            string dataShippingPostalCode = dataMailingPostalCode;

            string dataAddressSavesuccessfulAlert = "Your Address has been successfully saved.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Address’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserAddressXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Address' page.
            Assert.That(utils.isDisplayed(xpath.textAddressPageTitleXpath), Is.True);

            // Click on ‘Edit Address’ button on the Address page.
            utils.click(xpath.buttonAddressEditAddressXpath);

            // Validate if user lands on 'Address Edit' page.
            Assert.That(utils.isDisplayed(xpath.textAddressEditPageTitleXpath), Is.True);

            // Enter Address info
            utils.setInput(xpath.inputAddressEditMailingStreetAddressXpath, dataMailingStreetAddress);
            utils.setInput(xpath.inputAddressEditMailingStreetAddress2Xpath, dataMailingStreetAddress2);
            utils.setInput(xpath.inputAddressEditMailingCityXpath, dataMailingCity);
            utils.setSelectByText(xpath.selectAddressEditMailingProvinceCodeXpath, dataMailingProvince);
            utils.setInput(xpath.inputAddressEditMailingPostalCodeXpath, dataMailingPostalCode);

            utils.checkCheckbox(xpath.checkboxAddressEditMailingShippingSameXpath);

            /*
            utils.setInput(xpath.inputAddressEditShippingStreetAddressXpath, dataShippingStreetAddress);
            utils.setInput(xpath.inputAddressEditShippingStreetAddress2Xpath, dataShippingStreetAddress2);
            utils.setInput(xpath.inputAddressEditShippingCityXpath, dataShippingCity);
            utils.setSelectByText(xpath.selectAddressEditShippingProvinceCodeXpath, dataShippingProvince);
            utils.setInput(xpath.inputAddressEditShippingPostalCodeXpath, dataShippingPostalCode);
            */

            // Click on ‘Save Address’ button on the 'Address Edit' page.
            utils.click(xpath.buttonAddressEditSaveAddressXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataAddressSavesuccessfulAlert), Is.True);

            // Validate if user lands on 'Address' page.
            Assert.That(utils.isDisplayed(xpath.textAddressPageTitleXpath), Is.True);

            // Validate Address info on 'Address' page.
            Assert.That(utils.getInputValue(xpath.inputAddressMailingStreetAddressXpath).Equals(dataMailingStreetAddress));
            Assert.That(utils.getInputValue(xpath.inputAddressMailingStreetAddress2Xpath).Equals(dataMailingStreetAddress2));
            Assert.That(utils.getInputValue(xpath.inputAddressMailingCityXpath).Equals(dataMailingCity));
            Assert.That(utils.getInputValue(xpath.inputAddressMailingPostalCodeXpath).Equals(dataMailingPostalCode));

            Assert.That(utils.getInputValue(xpath.inputAddressShippingStreetAddressXpath).Equals(dataShippingStreetAddress));
            Assert.That(utils.getInputValue(xpath.inputAddressShippingStreetAddress2Xpath).Equals(dataShippingStreetAddress2));
            Assert.That(utils.getInputValue(xpath.inputAddressShippingCityXpath).Equals(dataShippingCity));
            Assert.That(utils.getInputValue(xpath.inputAddressShippingPostalCodeXpath).Equals(dataShippingPostalCode));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Address Save with Blank Data
        public void TC03_VerifyAddressSaveWithBlankData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataMailingStreetAddress = "";
            string dataMailingStreetAddress2 = "";
            string dataMailingCity = "";
            string dataMailingProvince = "Ontario";
            string dataMailingPostalCode = "";

            bool dataMailingShippingSame = false;

            string dataShippingStreetAddress = "";
            string dataShippingStreetAddress2 = "";
            string dataShippingCity = "";
            string dataShippingProvince = "Ontario";
            string dataShippingPostalCode = "";

            string errorMailingStreetAddressRequired = "The Street Address field is required.";
            string errorMailingCityRequired = "The City field is required.";
            string errorMailingPostalCodeRequired = "The Postal Code field is required.";

            string errorShippingStreetAddressRequired = "The Street Address field is required.";
            string errorShippingCityRequired = "The City field is required.";
            string errorShippingPostalCodeRequired = "The Postal Code field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Member name’ and click ‘Address’ link on the top menu bar
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserAddressXpath.Replace("{userName}", dataUserName));

            // Validate if user lands on 'Address' page.
            Assert.That(utils.isDisplayed(xpath.textAddressPageTitleXpath), Is.True);

            // Click on ‘Edit Address’ button on the Address page.
            utils.click(xpath.buttonAddressEditAddressXpath);

            // Validate if user lands on 'Address Edit' page.
            Assert.That(utils.isDisplayed(xpath.textAddressEditPageTitleXpath), Is.True);

            // Enter Address info
            utils.setInput(xpath.inputAddressEditMailingStreetAddressXpath, dataMailingStreetAddress);
            utils.setInput(xpath.inputAddressEditMailingStreetAddress2Xpath, dataMailingStreetAddress2);
            utils.setInput(xpath.inputAddressEditMailingCityXpath, dataMailingCity);
            utils.setSelectByText(xpath.selectAddressEditMailingProvinceCodeXpath, dataMailingProvince);
            utils.setInput(xpath.inputAddressEditMailingPostalCodeXpath, dataMailingPostalCode);

            utils.uncheckCheckbox(xpath.checkboxAddressEditMailingShippingSameXpath);

            utils.setInput(xpath.inputAddressEditShippingStreetAddressXpath, dataShippingStreetAddress);
            utils.setInput(xpath.inputAddressEditShippingStreetAddress2Xpath, dataShippingStreetAddress2);
            utils.setInput(xpath.inputAddressEditShippingCityXpath, dataShippingCity);
            utils.setSelectByText(xpath.selectAddressEditShippingProvinceCodeXpath, dataShippingProvince);
            utils.setInput(xpath.inputAddressEditShippingPostalCodeXpath, dataShippingPostalCode);

            // Click on ‘Save Address’ button on the 'Address Edit' page.
            utils.click(xpath.buttonAddressEditSaveAddressXpath);

            // Validate if error message is displayed on the 'Address Edit' page.
            Assert.That(utils.getText(xpath.errorAddressEditMailingStreetAddressXpath), Is.EqualTo(errorMailingStreetAddressRequired));
            Assert.That(utils.getText(xpath.errorAddressEditMailingCityXpath), Is.EqualTo(errorMailingCityRequired));
            Assert.That(utils.getText(xpath.errorAddressEditMailingPostalCodeXpath), Is.EqualTo(errorMailingPostalCodeRequired));

            Assert.That(utils.getText(xpath.errorAddressEditShippingStreetAddressXpath), Is.EqualTo(errorShippingStreetAddressRequired));
            Assert.That(utils.getText(xpath.errorAddressEditShippingCityXpath), Is.EqualTo(errorShippingCityRequired));
            Assert.That(utils.getText(xpath.errorAddressEditShippingPostalCodeXpath), Is.EqualTo(errorShippingPostalCodeRequired));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
    }
}
