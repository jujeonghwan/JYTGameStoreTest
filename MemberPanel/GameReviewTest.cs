/*
 * GameReviewTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.31: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class GameReviewTest
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
        // Verify Game Review Add with Valid Data
        public void TC01_VerifyGameReviewAddWithValidData()
        {
            // Test Data
            string dataUserName = "employee";
            string dataLoginEmail = "employee@employee.com";
            string dataLoginPassword = "Employee123!";
            string dataGameReview = "This game is awesome!";
            string dataGameReviewAddAlert = "The review has been successfully registered. It will be displayed after checking with the employees.";

            // Go to ‘Employee Panel’
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

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Enter 'Game Review'
            utils.setInput(xpath.textareaGameDetailsGameReviewXpath, dataGameReview);

            // Click on ‘Submit’ button
            utils.click(xpath.buttonGameDetailsGameReviewSubmitXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataGameReviewAddAlert), Is.True);

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Game Review Approve and Review Displayed
        public void TC02_VerifyGameReviewApproveAndReviewDisplayed()
        {
            // Test Data
            string dataUserName = "employee";
            string dataLoginEmail = "employee@employee.com";
            string dataLoginPassword = "Employee123!";
            string dataGameReview = "This game review need to be approved!";
            string dataGameReviewAddAlert = "The review has been successfully registered. It will be displayed after checking with the employees.";

            // Go to ‘Employee Panel’
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

            // Validate if user logged in successfully and user name displayed on the top menu on the page.
            Assert.That(utils.isDisplayed(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName)), Is.True);

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Enter 'Game Review'
            utils.setInput(xpath.textareaGameDetailsGameReviewXpath, dataGameReview);

            // Click on ‘Submit’ button
            utils.click(xpath.buttonGameDetailsGameReviewSubmitXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataGameReviewAddAlert), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Employee Panel - Review Game Reviews

            // Click on ‘Employee Panel’ and click ‘Review Game Review’ link on the top menu bar
            utils.click(xpath.buttonMenuEmployeePanelXpath);
            utils.click(xpath.linkMenuEmployeePanelReviewGameReviewXpath);

            // Validate if user lands on 'Review Game Reviews' page.
            Assert.That(utils.isDisplayed(xpath.textReviewGameReviewsPageTitleXpath), Is.True);

            // Validate if 'added Game Review' is displayed.
            Assert.That(utils.isDisplayed(xpath.textReviewGameReviewsGameReviewDescriptionXpath.Replace("{gameReview}", dataGameReview)), Is.True);

            // Check 'Select' checkbox
            utils.checkCheckbox(xpath.checkboxReviewGameReviewsSelectXpath.Replace("{gameReview}", dataGameReview));

            // Click on ‘Approve’ button
            utils.click(xpath.buttonReviewGameReviewsApproveXpath);

            // Validate if ‘Approved or not’ field has been changed to ‘Yes’
            Assert.That(utils.isDisplayed(xpath.textReviewGameReviewsApprovedOrNotYesXpath.Replace("{gameReview}", dataGameReview)), Is.True);

            ////////////////////////////////////////////////////////////////////////////////
            // Member Panel

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Validate if 'added Game Review' is displayed on the 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsGameReviewReviewXpath.Replace("{gameReview}", dataGameReview)), Is.True);

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Game Review Add with Blank Data
        public void TC03_VerifyGameReviewAddWithBlankData()
        {
            // Test Data
            string dataUserName = "employee";
            string dataLoginEmail = "employee@employee.com";
            string dataLoginPassword = "Employee123!";
            string dataGameReview = "";
            string dataGameReviewValidationAlert = "Please enter Game Review!";

            // Go to ‘Employee Panel’
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

            // Validate if user logged in successfully and user name displayed on the top menu on the page.
            Assert.That(utils.isDisplayed(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName)), Is.True);

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Enter 'Game Review' with blank
            utils.setInput(xpath.textareaGameDetailsGameReviewXpath, dataGameReview);

            // Click on ‘Submit’ button
            utils.click(xpath.buttonGameDetailsGameReviewSubmitXpath);

            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataGameReviewValidationAlert), Is.True);

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

    }
}
