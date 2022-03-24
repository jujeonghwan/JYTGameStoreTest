/*
 * EpEventTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.16: Created
 *      Jeonghwan Ju, 2021.10.17: Updated
 *      Jeonghwan Ju, 2021.10.31: Updated
 *      Jeonghwan Ju, 2021.11.11: Updated
 *      Jeonghwan Ju, 2021.12.07: Updated
 */
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.EmployeePanel
{
    [TestFixture]
    public class EpEventTest
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
        public void TC01_VerifyEventCreateWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataName = "Event Add Test";
            string dataDescription = "Event Descripton Test";
            string dataStartDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MMdd") + "0900A";
            string dataEndDate = DateTime.Now.ToString("yyyy") + Keys.Tab + "12311000P";
            string dataPublishDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MMdd") + "0900A";
            string dataPublisher = "Bob";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Event’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelEventXpath);

            // Click on ‘Create New Event’ button
            utils.click(xpath.buttonEventListCreateNewEventXpath);

            // Enter ‘Event’ info
            utils.setInput(xpath.inputEventNewNameXpath, dataName);
            utils.setInput(xpath.inputEventNewDescriptionXpath, dataDescription);
            utils.setInput(xpath.inputEventNewStartDateXpath, dataStartDate);
            utils.setInput(xpath.inputEventNewEndDateXpath, dataEndDate);
            utils.setInput(xpath.inputEventNewPublishDateXpath, dataPublishDate);
            utils.setInput(xpath.inputEventNewPublisherXpath, dataPublisher);

            // Click on ‘Create’ button
            utils.click(xpath.buttonEventNewCreateXpath);

            // Validate if new ‘added event’ is displayed on the ‘Event List’ page.
            Assert.That(utils.isDisplayed(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonEventListDeleteXpath.Replace("{eventName}", dataName));

            // Click 'Delete' button
            utils.click(xpath.buttonEventDeteteDeteteXpath);

            // Check event is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC02_VerifyEventEditWithValidData()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataName = "Event Edit Test";
            string dataDescription = "Event Edit Descripton Test";
            string dataStartDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MM") + "010900A";
            string dataEndDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MM") + "251159P";
            string dataPublishDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MM") + "010900A";
            string dataPublisher = "Bob";

            string dataName2 = "Event Edit Test2";
            string dataDescription2 = "Event Edit Descripton Test2";
            string dataStartDate2 = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MM") + "020900A";
            string dataEndDate2 = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MM") + "281159P";
            string dataPublishDate2 = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MM") + "020900A";
            string dataPublisher2 = "Bob2";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Event’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelEventXpath);

            // Click on ‘Create New Event’ button
            utils.click(xpath.buttonEventListCreateNewEventXpath);

            // Enter ‘Event’ info (New data)
            utils.setInput(xpath.inputEventNewNameXpath, dataName);
            utils.setInput(xpath.inputEventNewDescriptionXpath, dataDescription);
            utils.setInput(xpath.inputEventNewStartDateXpath, dataStartDate);
            utils.setInput(xpath.inputEventNewEndDateXpath, dataEndDate);
            utils.setInput(xpath.inputEventNewPublishDateXpath, dataPublishDate);
            utils.setInput(xpath.inputEventNewPublisherXpath, dataPublisher);

            // Click on ‘Create’ button
            utils.click(xpath.buttonEventNewCreateXpath);

            // Validate if new ‘added event’ is displayed on the ‘Event List’ page.
            Assert.That(utils.isDisplayed(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName)), Is.True);

            // Edit Testing Data
            utils.click(xpath.buttonEventListEditXpath.Replace("{eventName}", dataName));

            // Enter ‘Event’ info (Edit data)
            utils.setInput(xpath.inputEventEditNameXpath, dataName2);
            utils.setInput(xpath.inputEventEditDescriptionXpath, dataDescription2);
            utils.setInput(xpath.inputEventEditStartDateXpath, dataStartDate2);
            utils.setInput(xpath.inputEventEditEndDateXpath, dataEndDate2);
            utils.setInput(xpath.inputEventEditPublishDateXpath, dataPublishDate2);
            utils.setInput(xpath.inputEventEditPublisherXpath, dataPublisher2);

            // Click 'Save' button
            utils.click(xpath.buttonEventEditSaveXpath);

            // Validate if new ‘edited event’ is displayed on the ‘Event List’ page.
            Assert.That(utils.isDisplayed(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName2)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonEventListDeleteXpath.Replace("{eventName}", dataName2));

            // Click 'Delete' button
            utils.click(xpath.buttonEventDeteteDeteteXpath);

            // Check event is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName2)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC03_VerifyEventDelete()
        {
            // Test Data
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataName = "Event Delete Test";
            string dataDescription = "Event Delete Descripton Test";
            string dataStartDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MMdd") + "0900A";
            string dataEndDate = DateTime.Now.ToString("yyyy") + Keys.Tab + "12311000P";
            string dataPublishDate = DateTime.Now.ToString("yyyy") + Keys.Tab + DateTime.Now.ToString("MMdd") + "0900A";
            string dataPublisher = "Bob Delete";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Event’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelEventXpath);

            // Click on ‘Create New Event’ button
            utils.click(xpath.buttonEventListCreateNewEventXpath);

            // Enter ‘Event’ info
            utils.setInput(xpath.inputEventNewNameXpath, dataName);
            utils.setInput(xpath.inputEventNewDescriptionXpath, dataDescription);
            utils.setInput(xpath.inputEventNewStartDateXpath, dataStartDate);
            utils.setInput(xpath.inputEventNewEndDateXpath, dataEndDate);
            utils.setInput(xpath.inputEventNewPublishDateXpath, dataPublishDate);
            utils.setInput(xpath.inputEventNewPublisherXpath, dataPublisher);

            // Click on ‘Create’ button
            utils.click(xpath.buttonEventNewCreateXpath);

            // Validate if new ‘added event’ is displayed on the ‘Event List’ page.
            Assert.That(utils.isDisplayed(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName)), Is.True);

            // Delete Testing Data
            utils.click(xpath.buttonEventListDeleteXpath.Replace("{eventName}", dataName));

            // Click 'Delete' button
            utils.click(xpath.buttonEventDeteteDeteteXpath);

            // Check event is deleted
            Assert.IsTrue(utils.isNotExist(xpath.textEventListEventNameXpath.Replace("{eventName}", dataName)));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC04_VerifyEventCreateWithInvalidData()
        {
            // Test Data (blank data)
            string dataUserName = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataName = "";
            string dataDescription = "";
            string dataStartDate = "";
            string dataEndDate = "";
            string dataPublishDate = "";
            string dataPublisher = "";

            string errorNameRequired = "Event Name is Required";
            string errorDescriptionRequired = "Description is Required";
            string errorStartDateRequired = "Start Date is Required";
            string errorEndDateRequired = "End Date is Required";
            string errorPublishDateRequired = "Publish Date is Required";
            string errorPublisherRequired = "Post By is Required";

            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail, dataLoginPassword);

            // Click on ‘Employee Panel’ and click ‘Event’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelEventXpath);

            // Click on ‘Create New Event’ button
            utils.click(xpath.buttonEventListCreateNewEventXpath);

            // Enter ‘Event’ info
            utils.setInput(xpath.inputEventNewNameXpath, dataName);
            utils.setInput(xpath.inputEventNewDescriptionXpath, dataDescription);
            utils.setInput(xpath.inputEventNewStartDateXpath, dataStartDate);
            utils.setInput(xpath.inputEventNewEndDateXpath, dataEndDate);
            utils.setInput(xpath.inputEventNewPublishDateXpath, dataPublishDate);
            utils.setInput(xpath.inputEventNewPublisherXpath, dataPublisher);

            // Click on ‘Create’ button
            utils.click(xpath.buttonEventNewCreateXpath);

            // Validate if error message is displayed on the ‘Event New’ page.
            Assert.That(utils.getText(xpath.errorEventNewNameXpath), Is.EqualTo(errorNameRequired));
            Assert.That(utils.getText(xpath.errorEventNewDescriptionXpath), Is.EqualTo(errorDescriptionRequired));

            Assert.That(utils.getText(xpath.errorEventNewStartDateXpath), Is.EqualTo(errorStartDateRequired));
            Assert.That(utils.getText(xpath.errorEventNewEndDateXpath), Is.EqualTo(errorEndDateRequired));
            Assert.That(utils.getText(xpath.errorEventNewPublishDateXpath), Is.EqualTo(errorPublishDateRequired));
            Assert.That(utils.getText(xpath.errorEventNewPublisherXpath), Is.EqualTo(errorPublisherRequired));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
        
    }
}
