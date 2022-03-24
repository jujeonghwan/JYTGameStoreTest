/*
 * EpCategoryTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.15: Created
 *      Jeonghwan Ju, 2021.10.17: Updated
 *      Jeonghwan Ju, 2021.10.31: Updated
 *      Jeonghwan Ju, 2021.11.11: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest
{
    /// <summary>
    /// Category Test (Employee Panel)
    /// </summary>
    [TestFixture]
    public class EpCategoryTest
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
        public void TC01_VerifyCategoryAddWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataCategoryName = "Fun Game Add Test";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game Category’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelCategoryXpath);

            // Click on ‘Create New Game Category’ button
            utils.click(xpath.buttonCateoryListCreateNewGameCategoryXpath);

            // Enter ‘Category Name’
            utils.setInput(xpath.inputCateoryAddCategoryNameXpath, dataCategoryName);

            // Click on ‘Create’ button
            utils.click(xpath.buttonCateoryAddCreateXpath);

            // Validate if new ‘added category’ is displayed on the ‘Game Category List’ page.
            Assert.That(utils.isDisplayed(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonCateoryListDeleteXpath.Replace("{categoryName}", dataCategoryName));

            // Click 'Delete' button
            utils.click(xpath.buttonCateoryDeteteDeteteXpath);

            // Check category is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC02_VerifyCategoryEditWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataCategoryName = "Fun Game Edit Test";
            string dataCategoryName2 = "Fun Game Edit Test2";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game Category’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelCategoryXpath);

            // Click on ‘Create New Game Category’ button
            utils.click(xpath.buttonCateoryListCreateNewGameCategoryXpath);

            // Enter ‘Category Name’ 
            utils.setInput(xpath.inputCateoryAddCategoryNameXpath, dataCategoryName);

            // Click on ‘Create’ button
            utils.click(xpath.buttonCateoryAddCreateXpath);

            // Validate if new ‘added category’ is displayed on the ‘Game Category List’ page.
            Assert.That(utils.isDisplayed(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)), Is.True);

            // Click 'Edit' button of Testing Data
            utils.click(xpath.buttonCateoryListEditXpath.Replace("{categoryName}", dataCategoryName));

            // Enter ‘Category Name’
            utils.setInput(xpath.inputCateoryEditCategoryNameXpath, dataCategoryName2);

            // Click 'Update' button
            utils.click(xpath.buttonCateoryEditUpdateXpath);

            // Validate if new ‘updated category’ is displayed on the ‘Category List’ page.
            Assert.That(utils.isDisplayed(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName2)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonCateoryListDeleteXpath.Replace("{categoryName}", dataCategoryName2));

            // Click 'Delete' button
            utils.click(xpath.buttonCateoryDeteteDeteteXpath);

            // Check category is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName2)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC03_VerifyCategoryDelete()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataCategoryName = "Fun Game Delete Test";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game Category’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelCategoryXpath);

            // Click on ‘Create New Game Category’ button
            utils.click(xpath.buttonCateoryListCreateNewGameCategoryXpath);

            // Enter ‘Category Name’ 
            utils.setInput(xpath.inputCateoryAddCategoryNameXpath, dataCategoryName);

            // Click on ‘Create’ button
            utils.click(xpath.buttonCateoryAddCreateXpath);

            // Validate if new ‘added category’ is displayed on the ‘Category List’ page.
            Assert.That(utils.isDisplayed(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonCateoryListDeleteXpath.Replace("{categoryName}", dataCategoryName));

            // Click 'Delete' button
            utils.click(xpath.buttonCateoryDeteteDeteteXpath);

            // Check category is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC04_VerifyCategoryAddWithInvalidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataCategoryName = "";           // blank data

            string errorCategoryNameRequired = "The Category Name field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game Category’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelCategoryXpath);

            // Click on ‘Create New Game Category’ button
            utils.click(xpath.buttonCateoryListCreateNewGameCategoryXpath);

            // Enter ‘Category Name’ 
            utils.setInput(xpath.inputCateoryAddCategoryNameXpath, dataCategoryName);

            // Click on ‘Create’ button
            utils.click(xpath.buttonCateoryAddCreateXpath);

            // Validate if error message is displayed on the ‘Category Add’ page.
            Assert.That(utils.getText(xpath.errorCateoryAddCategoryNameXpath), Is.EqualTo(errorCategoryNameRequired));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC05_VerifyCategoryEddWithInvalidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataCategoryName = "Fun Game Edit Test";
            string dataCategoryName2 = "";           // blank data

            string errorCategoryNameRequired = "The Category Name field is required.";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Game Category’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelCategoryXpath);

            // Click on ‘Create New Game Category’ button
            utils.click(xpath.buttonCateoryListCreateNewGameCategoryXpath);

            // Enter ‘Category Name’ 
            utils.setInput(xpath.inputCateoryAddCategoryNameXpath, dataCategoryName);

            // Click on ‘Create’ button
            utils.click(xpath.buttonCateoryAddCreateXpath);

            // Validate if new ‘added category’ is displayed on the ‘Category List’ page.
            Assert.That(utils.isDisplayed(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)), Is.True);

            // Click 'Edit' button of Testing Data
            utils.click(xpath.buttonCateoryListEditXpath.Replace("{categoryName}", dataCategoryName));

            // Enter ‘Category Name’
            utils.setInput(xpath.inputCateoryEditCategoryNameXpath, dataCategoryName2);

            // Click 'Update' button
            utils.click(xpath.buttonCateoryEditUpdateXpath);

            // Validate if error message is displayed on the ‘Category Edit’ page.
            Assert.That(utils.getText(xpath.errorCateoryEditCategoryNameXpath), Is.EqualTo(errorCategoryNameRequired));

            // Click 'Back' button
            utils.click(xpath.buttonCateoryEditBackXpath);

            // Delete Testing Data
            utils.click(xpath.buttonCateoryListDeleteXpath.Replace("{categoryName}", dataCategoryName));

            // Click 'Delete' button
            utils.click(xpath.buttonCateoryDeteteDeteteXpath);

            // Check category is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
    }
}

