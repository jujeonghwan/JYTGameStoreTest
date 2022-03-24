/*
 * SelectingGames.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Yumi Lee, Nov 09, 2021: Created
 *      Jeonghwan Ju, 2021.10.17: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;
using System.Threading;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class SelectingGames
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
        public void TC01_SelectingGames()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            
            //Arrange : Login to select a game
            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);
            utils.sleep(5);

            //Act : Selecting a game
            // driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.Id("dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Selecting Games")).Click();
            driver.FindElement(By.Id("1")).Click();
            driver.FindElement(By.CssSelector(".w-25")).Click();
            Thread.Sleep(3000);

            //Assert : Check if the clicked item is showing details
            Assert.That(driver.FindElement(By.CssSelector("tbody tr:nth-child(1) > td:nth-child(1)")).Text, Is.EqualTo("Wow"));

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

    }
}
