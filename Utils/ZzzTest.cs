/*
 * ZzzTest.cs
 * JYTGameStore Automated Test Project (Practice)
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.17: Created
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using JYTGameStoreTest.Utils;

namespace JYTGameStoreTest
{
    /// <summary>
    /// Category Test (Employee Panel)
    /// </summary>
    [TestFixture]
    public class ZzzTest : TestingUtils
    {
        ////////////////////////////////////////////////////////////////////////////////
        // Web Driver
        private IWebDriver driver;

        ////////////////////////////////////////////////////////////////////////////////
        // URL
        private string testURL = Shared.BASE_URL;   // ex) https://localhost:44349

        ////////////////////////////////////////////////////////////////////////////////
        // XPath
        //#################### Employee Panel Main page ################################
        private string titleMainXpath = "/html/head/title[contains(text(),'Home Page - JYTGameStore')]";
        private string textMainWelcomeXpath = "/html/body/div/main/div/h1[contains(text(),'Welcome to the JYT Game store!')]";
        private string buttonMenuEmployeePanelXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]";
        // private string linkMenuEmployeePanelCategoryXpath = "/html/body/header/nav/div//div/a[contains(text(),'Category')]";
        private string linkMenuEmployeePanelCategoryXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]/following-sibling::div/a[contains(text(),'Category')]";

        //#################### Cateory List page #######################################
        private string buttonCateoryListCreateNewCategoryXpath = "//main/div/div/div/a[contains(text(),'Create New Category')]";
        private string textCateoryListCategoryNameXpath = "//table/tbody/tr/td[1][contains(text(),'{categoryName}')]";      // {categoryName} ex) 'Fun Game'
        private string buttonCateoryListEditXpath = "//table/tbody/tr/td[contains(text(),'{categoryName}')]/following-sibling::td/div/a[contains(text(),'Edit')]";
        private string buttonCateoryListDeleteXpath = "//table/tbody/tr/td[contains(text(),'{categoryName}')]/following-sibling::td/div/a[contains(text(),'Delete')]";

        // //table/tbody/tr/td[contains(text(),'Game Category Test')]/following-sibling::td/div/a[contains(text(),'Delete')]
        //#################### Cateory Add page ########################################
        private string inputCateoryAddCategoryNameXpath = "//input[@id='CategoryName']";
        private string buttonCateoryAddCreateXpath = "//form/div/div/input[@type='submit'][@value='Create']";
        private string errorCateoryAddCategoryNameXpath = "//form/div//span[contains(text(),'The Category Name field is required.')]";      
        
        //#################### Cateory Edit page #######################################
        private string inputCateoryEditCategoryNameXpath = "//input[@id='CategoryName']";
        private string errorCateoryEditCategoryNameXpath = "//form/div//span[contains(text(),'The Category Name field is required.')]";
        private string buttonCateoryEditUpdateXpath = "//form/div/div/input[@type='submit'][@value='Update']";
        private string buttonCateoryEditBackXpath = "//form/div/div/a[contains(text(),'Back')]";

        //#################### Cateory Delete page #####################################
        private string buttonCateoryDeteteDeteteXpath = "//form/div/div/input[@type='submit'][@value='Delete']";

        

        /// <summary>
        /// Setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            // testURL
            testURL = Shared.BASE_URL;
        }

        /// <summary>
        /// Tear Down Driver
        /// </summary>
        [TearDown]
        public void TearDownDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        // [Test]
        public void TC01_Zzz()
        {
            // Test Data
            string dataCategoryName = "Fun Game Add Test";

            TestingUtils utils = new TestingUtils(driver);

            // Go to ‘Employee Panel’ url(https://localhost:44349/)
            utils.goToUrl(testURL);

            // Click on ‘Employee Panel’ and click ‘Category’ link on the top menu bar
            utils.click(buttonMenuEmployeePanelXpath);
            utils.click(linkMenuEmployeePanelCategoryXpath);

            // Click on ‘Create New Category’ button
            utils.click(buttonCateoryListCreateNewCategoryXpath);

            // Enter ‘Category Name’
            utils.setInput(inputCateoryAddCategoryNameXpath, dataCategoryName);

            // Click on ‘Create’ button
            utils.click(buttonCateoryAddCreateXpath);
            
            // Validate if new ‘added category’ is displayed on the ‘Category List’ page.
            // ‘Fun Game’
            Assert.That(utils.isDisplayed(textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)), Is.True);

            // Delete Testing Data
            utils.click(buttonCateoryListDeleteXpath.Replace("{categoryName}", dataCategoryName));

            // Click 'Delete' button
            utils.click(buttonCateoryDeteteDeteteXpath);
            
            // Check category is deleted
            Assert.IsTrue(utils.isNotExist(textCateoryListCategoryNameXpath.Replace("{categoryName}", dataCategoryName)));

            // Close web browser.
            utils.close();
        }


    }
}

