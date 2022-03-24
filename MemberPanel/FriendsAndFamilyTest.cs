/*
 * FriendsAndFamilyTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Yumi Lee, Nov 09, 2021: Created
 *      Jeonghwan Ju, 2021.12.07: Updated
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;
using System.Collections.Generic;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class FriendsAndFamilyTest
    {
        private IWebDriver driver;                  // Web Driver        
        private string testURL = Shared.BASE_URL;   // URL        
        private TestingUtils utils;                 // Testing Utils
        private CommonXpath xpath;                  // Common XPath

        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;


        // Setup
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            testURL = Shared.BASE_URL;
            utils = new TestingUtils(driver);
            xpath = new CommonXpath();

            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
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
        public void TC01_SearchFriendsAndFamilyAndAdd()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            //Assumption: there is no friends and family registered yet for member and employee
            //Arrange : Login to select a game

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);
            utils.sleep(5);

            //Act: Search and add a friend first
            driver.FindElement(By.CssSelector(".dropdown:nth-child(3) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Search your Friends and Family")).Click();
            driver.FindElement(By.Name("SearchString")).Click();
            driver.FindElement(By.Name("SearchString")).SendKeys("abc");
            driver.FindElement(By.CssSelector(".input-group-text")).Click();

            //Assert: Searching a friend failed
            // Assert.That(driver.FindElement(By.CssSelector("form:nth-child(5)")).Text, Is.EqualTo("There is no user ID for that search"));
            Assert.That(driver.FindElement(By.XPath("/html/body/div/main/form[2]")).Text, Is.EqualTo("There is no user ID for that search"));

            //Add a friend again
            driver.FindElement(By.Name("SearchString")).Click();
            driver.FindElement(By.Name("SearchString")).SendKeys("employee@employee.com");
            driver.FindElement(By.CssSelector(".input-group-text")).Click();

            //Assert: Friend searched
            Assert.That(driver.FindElement(By.CssSelector("td:nth-child(1)")).Text, Is.EqualTo("employee@employee.com"));
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.CssSelector(".dropdown:nth-child(3) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Friends and Family List")).Click();

            //Assert : Friedn added
            Assert.That(driver.FindElement(By.CssSelector("td:nth-child(1)")).Text, Is.EqualTo("employee@employee.com"));
            driver.FindElement(By.LinkText("Delete")).Click();

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }

        [Test]
        public void TC02_ShowingTheirWishList()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;

            //Assumption: There is no friends and family registered yet for member and employee
            //Arrange : Login to select a game

            // Go to Main Page
            utils.goToMainPage();

            // Login with member account
            utils.loginWithMemberAccount(dataLoginEmail, dataLoginPassword);
            utils.sleep(5);

            //Act: Search and add a friend first
            driver.FindElement(By.CssSelector(".dropdown:nth-child(3) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Search your Friends and Family")).Click();
            driver.FindElement(By.Name("SearchString")).Click();
            driver.FindElement(By.Name("SearchString")).SendKeys("employee@employee.com");
            driver.FindElement(By.CssSelector(".input-group-text")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.CssSelector(".dropdown:nth-child(6) > #dropdownMenuButton")).Click();
            driver.FindElement(By.CssSelector(".btn-link")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("employee@employee.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Employee123!");
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.CssSelector(".dropdown:nth-child(3) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Search your Friends and Family")).Click();
            driver.FindElement(By.Name("SearchString")).Click();
            driver.FindElement(By.Name("SearchString")).SendKeys("member@member.com");
            driver.FindElement(By.CssSelector(".input-group-text")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();

            //Assert : See friends and family's wish list
            Assert.That(driver.FindElement(By.LinkText("See Friends and family\'s wish list")).Text, Is.EqualTo("See Friends and family's wish list"));

            //Deleting the added friends and family list
            driver.FindElement(By.LinkText("See Friends and family\'s wish list")).Click();
            driver.FindElement(By.CssSelector(".dropdown:nth-child(3) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Friends and Family List")).Click();
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".dropdown:nth-child(7) > #dropdownMenuButton")).Click();
            // driver.FindElement(By.CssSelector(".dropdown:nth-child(6) > #dropdownMenuButton")).Click();
            driver.FindElement(By.CssSelector(".btn-link")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("member@member.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("Member123!");
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.CssSelector(".dropdown:nth-child(3) > #dropdownMenuButton")).Click();
            driver.FindElement(By.LinkText("Friends and Family List")).Click();
            driver.FindElement(By.LinkText("Delete")).Click();

            // logout
            utils.logoutAccount();

            // Close web browser.
            utils.close();
        }
    }
}
