/*
 * TestingUtils.cs
 * JYTGameStore Automated Test Project
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.17: Created
 *      Jeonghwan Ju, 2021.12.08: Updated
 */
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest.Utils
{
    public class TestingUtils
    {
        ////////////////////////////////////////////////////////////////////////////////
        // Web Driver
        private IWebDriver driver;                  // Web Driver  
        private WebDriverWait wait;
        private CommonXpath xpath;                  // Common XPath

        // Constructor
        public TestingUtils()
        {
        }

        public TestingUtils(IWebDriver driver)
        {
            this.driver = driver;
            xpath = new CommonXpath();
        }

        // Testing Methods
        public void goToUrl(string url)
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
        }

        public void setFocus(string xPath)
        {
            Thread.Sleep(1000);
            this.driver.FindElement(By.XPath(xPath)).SendKeys("");
            Thread.Sleep(1000);
        }

        public void setInput(string xPath, string inputValue)
        {
            this.driver.FindElement(By.XPath(xPath)).Clear();
            this.driver.FindElement(By.XPath(xPath)).SendKeys(inputValue);
            Thread.Sleep(1000);
        }

        public string getInputValue(string xPath)
        {
            Thread.Sleep(1000);
            return this.driver.FindElement(By.XPath(xPath)).GetAttribute("value").Trim();
        }

        public void setSelectByText(string xPath, string inputValue)
        {            
            click(xPath);                                                       // Click '<select>'            
            click(xPath + "/option[contains(text(),'" + inputValue + "')]");    // Click '<option>'
            Thread.Sleep(1000);
        }

        public void checkCheckbox(string xPath)
        {
            if (!this.driver.FindElement(By.XPath(xPath)).Selected)
            {
                this.driver.FindElement(By.XPath(xPath)).Click();
            }
        }

        public void uncheckCheckbox(string xPath)
        {
            if (this.driver.FindElement(By.XPath(xPath)).Selected)
            {
                this.driver.FindElement(By.XPath(xPath)).Click();
            }
        }

        public bool getCheckboxChecked(string xPath)
        {
            Thread.Sleep(1000);
            return this.driver.FindElement(By.XPath(xPath)).Selected;
        }

        public void checkRadio(string xPath)
        {
            if (!this.driver.FindElement(By.XPath(xPath)).Selected)
            {
                this.driver.FindElement(By.XPath(xPath)).Click();
            }
        }

        public void click(string xPath)
        {
            Thread.Sleep(1000);
            this.driver.FindElement(By.XPath(xPath)).Click();
            Thread.Sleep(1000);
        }

        public string getText(string xPath)
        {
            Thread.Sleep(1000);
            return driver.FindElement(By.XPath(xPath)).Text.Trim();
        }

        public bool isDisplayed(string xPath)
        {
            Thread.Sleep(1000);
            return driver.FindElement(By.XPath(xPath)).Displayed;
        }

        public bool isExist(string xPath)
        {
            Thread.Sleep(1000);
            return (driver.FindElements(By.XPath(xPath)).Count > 0);
        }

        public bool isNotExist(string xPath)
        {
            Thread.Sleep(1000);
            return (driver.FindElements(By.XPath(xPath)).Count <= 0);            
        }

        public void sleep(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public string getPromptText(string question)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor) driver;
            jsExecutor.ExecuteScript("window.promptResponse = prompt('" + question + "');");
            Thread.Sleep(15000);
            string resultText = (string)jsExecutor.ExecuteScript("return window.promptResponse;");
            return resultText;
        }

        public bool acceptAlertMessage(string message)
        {
            Thread.Sleep(3000);
            string alertText = driver.SwitchTo().Alert().Text;
            if (message != alertText)
            {
                return false;
            }
            Thread.Sleep(3000);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            return true;
        }

        public void close()
        {
            this.driver.Close();
            Thread.Sleep(1000);
        }

        ////////////////////////////////////////////////////////////////////////////////
        // User Methods

        // Get Masked Credit Card Number
        public string getMaskedCreditCardNumber(string creditCardNumber, string delemiter = "")
        {
            string result = "";
            if (creditCardNumber.Length >= 8)
            {
                result += "****" + delemiter + creditCardNumber.Substring(4, 4) + delemiter;
            }

            if (creditCardNumber.Length >= 16)
            {
                result += "****" + delemiter + creditCardNumber.Substring(12, 4);
            }
            return result;
        }

        // Go to Main Page
        public void goToMainPage(string url = Shared.BASE_URL)
        {
            // Go to ‘Home page’
            goToUrl(url);

            // Validate if user lands on 'Main' page.
            Assert.That(isDisplayed(xpath.textMainPageTitleXpath), Is.True);
        }

        // Login with member account
        public void loginWithMemberAccount(string memberEmail, string memberPassword)
        {
            // Click on 'Login' link on the top menu bar
            click(xpath.linkMenuLoginXpath);

            // Validate if user lands on 'Login' page.
            Assert.That(isDisplayed(xpath.textLoginPageTitleXpath), Is.True);

            // Enter 'Email' and 'Password'
            setInput(xpath.inputLoginEmailXpath, memberEmail);
            setInput(xpath.inputLoginPasswordXpath, memberPassword);

            // Click on ‘Login’ button
            click(xpath.buttonLoginLoginXpath);

            // Check 'Login' is deleted on the top menu bar
            Assert.IsTrue(isNotExist(xpath.linkMenuLoginXpath));
        }

        // Login with employee account
        public void loginWithEmployeeAccount(string employeeEmail, string employeePassword)
        {
            // Click on 'Login' link on the top menu bar
            click(xpath.linkMenuLoginXpath);

            // Validate if user lands on 'Login' page.
            Assert.That(isDisplayed(xpath.textLoginPageTitleXpath), Is.True);

            // Enter 'Email' and 'Password'
            setInput(xpath.inputLoginEmailXpath, employeeEmail);
            setInput(xpath.inputLoginPasswordXpath, employeePassword);

            // Click on ‘Login’ button
            click(xpath.buttonLoginLoginXpath);

            // Check 'Login' is deleted on the top menu bar
            Assert.IsTrue(isNotExist(xpath.linkMenuLoginXpath));
        }

        // Logout account
        public void logoutAccount()
        {
            // Click on ‘User Name link on the top menu bar and click on 'Logout' link on the sub menu.
            click(xpath.buttonMenuUserForLogoutXpath);
            click(xpath.linkMenuUserLogoutXpath);

            // Validate if 'Login' link link is displayed on the top menu.
            Assert.That(isDisplayed(xpath.linkMenuLoginXpath), Is.True);
        }

    }
}
