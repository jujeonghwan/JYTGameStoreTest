/*
 * GameRatingTest.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.11.05: Created
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.MemberPanel
{
    [TestFixture]
    class GameRatingTest
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
        // Verify Game Rating with Valid Data
        public void TC01_VerifyGameRatingAddWithValidData()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameRating = "4";

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

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Select 'Game Rating' radio button.
            utils.checkRadio(xpath.radioGameDetailsGameRatingXpath.Replace("{gameRating}", dataGameRating));

            // Click on ‘Rate!’ button
            utils.click(xpath.buttonGameDetailsRateXpath);

            // Validate if 'No ratings yet' text is gone and show 'Overall Rating'
            Assert.IsTrue(utils.isNotExist(xpath.textGameDetailsOverallRatingNoRatingsYetXpath));

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Game Rating with Do Not Choose Rating
        public void TC02_VerifyGameRatingWithDoNotChooseRating()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            // string dataGameRating = "";
            string dataGameRatingDoNotChooseAlert = "Please select a rating";

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

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // Do not choose 'Game Rating' radio button. (No Action)
            // utils.checkRadio(xpath.radioGameDetailsGameRatingXpath.Replace("{gameRating}", dataGameRating));

            // Click on ‘Rate!’ button
            utils.click(xpath.buttonGameDetailsRateXpath);

            // Validate if 'alert' message is displayed. (Please select a rating)
            Assert.That(utils.acceptAlertMessage(dataGameRatingDoNotChooseAlert), Is.True);

            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            utils.click(xpath.buttonMenuUserXpath.Replace("{userName}", dataUserName));
            utils.click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(utils.isDisplayed(xpath.linkMenuLoginXpath), Is.True);

            // Close web browser.
            utils.close();
        }

        [Test]
        // Verify Game Rating is changed 
        public void TC03_VerifyGameRatingIsChanged()
        {
            // Test Data
            string dataUserName = Shared.MEMBER_USER_NAME;
            string dataLoginEmail = Shared.MEMBER_LOGIN_EMAIL;
            string dataLoginPassword = Shared.MEMBER_LOGIN_PASSWORD;
            string dataGameRating = "5";
            string dataGameRating2 = "1";
            string dataGameRatingValue = "";
            string dataGameRatingValue2 = "";

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

            // Click on ‘Game’ and click ‘Game List’ link on the top menu bar
            utils.click(xpath.buttonMenuGameXpath);
            utils.click(xpath.linkMenuGameGameListXpath);

            // Validate if user lands on 'Game List' page.
            Assert.That(utils.isDisplayed(xpath.textGameListPageTitleXpath), Is.True);

            // Click on ‘Game Name’ link on the first Game Name.
            utils.click(xpath.linkGameListGameNameFirstXpath);

            // Validate if user lands on 'Game Details' page.
            Assert.That(utils.isDisplayed(xpath.textGameDetailsPageTitleXpath), Is.True);

            // 1st 'Grame Rating'
            // Select 'Game Rating' radio button.
            utils.checkRadio(xpath.radioGameDetailsGameRatingXpath.Replace("{gameRating}", dataGameRating));

            // Click on ‘Rate!’ button
            utils.click(xpath.buttonGameDetailsRateXpath);

            // Validate if 'No ratings yet' text is gone and show 'Overall Rating'
            Assert.IsTrue(utils.isNotExist(xpath.textGameDetailsOverallRatingNoRatingsYetXpath));

            // Get current Overall Rating value
            dataGameRatingValue = utils.getText(xpath.textGameDetailsOverallRatingXpath);

            // 2nd 'Grame Rating'
            // Select 'Game Rating' radio button.
            utils.checkRadio(xpath.radioGameDetailsGameRatingXpath.Replace("{gameRating}", dataGameRating2));

            // Click on ‘Rate!’ button
            utils.click(xpath.buttonGameDetailsRateXpath);

            // Get changed Overall Rating value
            dataGameRatingValue2 = utils.getText(xpath.textGameDetailsOverallRatingXpath);

            // Validate if 'Overall Rating' is changed.
            Assert.That(dataGameRatingValue != dataGameRatingValue2, Is.True);

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
