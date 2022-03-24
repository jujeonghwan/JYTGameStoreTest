/*
 * EpApproveReviewGames.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Yumi Lee, Nov 09, 2021: Created
 *      Jeonghwan Ju, 2021.11.11: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;
using System.Threading;

namespace JYTGameStoreTest.EmployeePanel
{
    [TestFixture]
    class EpApproveReviewGames
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
        // Verify Game Review Approve function
        public void TC01_ApproveReviewGames()
        {
            // Arrange
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            string dataUserName2 = Shared.EMPLOYEE_USER_NAME;
            string dataLoginEmail2 = Shared.EMPLOYEE_LOGIN_EMAIL;
            string dataLoginPassword2 = Shared.EMPLOYEE_LOGIN_PASSWORD;

            string dataGameReview = "Game Review";
            string dataGameReviewAddAlert = "The review has been successfully registered. It will be displayed after checking with the employees.";

            //Act : Creating a new review            
            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);    
            
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);
            utils.click(xpath.linkGameListGameNameFirstXpath);
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);
            utils.setInput(xpath.textareaGameDetailsGameReviewXpath, dataGameReview);
            utils.click(xpath.buttonGameDetailsGameReviewSubmitXpath);
            // Validate if 'alert' message is displayed.
            Assert.That(utils.acceptAlertMessage(dataGameReviewAddAlert), Is.True);
            Thread.Sleep(5000);

            // logout
            utils.logoutAccount();      

            //Assert
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            //Act: Approving review games for the new created review
            // Go to Main Page
            utils.goToMainPage();

            // Login with employee account
            utils.loginWithEmployeeAccount(dataLoginEmail2, dataLoginPassword2);

            driver.FindElement(By.CssSelector(".dropdown:nth-child(6) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Review Game Reviews")).Click();
            driver.FindElement(By.CssSelector(".pb-3")).Click();
            string selectedElement = driver.FindElement(By.CssSelector("tbody tr:nth-child(1) > td:nth-child(2)")).Text;
            Thread.Sleep(3000);
            driver.FindElement(By.Id(selectedElement)).Click();
            // driver.FindElement(By.CssSelector(".w-25")).Click();
            driver.FindElement(By.XPath("/html/body/div/main/form[2]/input[1]")).Click();
            // /html/body/div/main/form[2]/table/tbody/tr[1]/td[6]/div
            // /html/body/div/main/form[2]/input[1]
            driver.FindElement(By.CssSelector(".dropdown:nth-child(6) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Review Game Reviews")).Click();

            //Assert    
            Assert.That(driver.FindElement(By.CssSelector("tbody tr:nth-child(1) > td:nth-child(6)")).Text, Is.EqualTo("Approved"));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
