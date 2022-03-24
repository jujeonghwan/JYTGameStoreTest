/*
 * CommonXpath.cs
 * Shared Variables
 * 
 *  Revision History
 *      Jeonghwan Ju, 2021.10.31: Created
 *      Jeonghwan Ju, 2021.12.07: Updated
 *      Jeonghwan Ju, 2021.12.08: Updated
 */

namespace JYTGameStoreTest.Utils
{
    ////////////////////////////////////////////////////////////////////////////////
    // XPath

    public class CommonXpath
    {
        ////////////////////////////////////////////////////////////////////////////////
        // Top Menu
        
        //#################### Top Menu Link ###########################################
        public string linkMenuLoginXpath = "/html/body/header/nav/div/div/a[contains(text(),'Login')]";
        public string linkMenuRegisterXpath = "/html/body/header/nav/div/div/a[contains(text(),'Register')]";

        public string buttonMenuGameXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Game')]";
        public string linkMenuGameSelectingGamesXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Game')]/following-sibling::div/a[contains(text(),'Selecting Games')]";
        public string linkMenuGameGameListXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Game')]/following-sibling::div/a[contains(text(),'Game List')]";
        public string linkMenuGameMyGameXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Game')]/following-sibling::div/a[contains(text(),'My Game')]";

        public string buttonMenuEmployeePanelXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]";
        public string linkMenuEmployeePanelEventXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]/following-sibling::div/a[contains(text(),'Event')]";
        public string linkMenuEmployeePanelGameXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]/following-sibling::div/a[contains(text(),'Game')]";
        public string linkMenuEmployeePanelCategoryXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]/following-sibling::div/a[contains(text(),'Category')]";
        public string linkMenuEmployeePanelReportsXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]/following-sibling::div/a[contains(text(),'Reports')]";
        public string linkMenuEmployeePanelReviewGameReviewXpath = "//button[@id='dropdownMenuButton'][contains(text(),'Employee Panel')]/following-sibling::div/a[contains(text(),'Review Game Review')]";

        public string buttonMenuUserXpath = "//button[@id='dropdownMenuButton'][contains(text(),'{userName}')]";
        public string buttonMenuUserForLogoutXpath = "//div[@id='memberMenu']/button[@id='dropdownMenuButton']";
        public string linkMenuUserProfileXpath = "//button[@id='dropdownMenuButton'][contains(text(),'{userName}')]/following-sibling::div/a[contains(text(),'Profile')]";
        public string linkMenuUserPreferenceXpath = "//button[@id='dropdownMenuButton'][contains(text(),'{userName}')]/following-sibling::div/a[contains(text(),'Preference')]";
        public string linkMenuUserAddressXpath = "//button[@id='dropdownMenuButton'][contains(text(),'{userName}')]/following-sibling::div/a[contains(text(),'Address')]";
        public string linkMenuUserCreditCardsXpath = "//button[@id='dropdownMenuButton'][contains(text(),'{userName}')]/following-sibling::div/a[contains(text(),'Credit Cards')]";
        public string linkMenuUserLogoutXpath = "//form/button[contains(text(),'Logout')]";
        
        ////////////////////////////////////////////////////////////////////////////////
        // Main Page
        //#################### Main page ###############################################
        public string titleMainXpath = "/html/head/title[contains(text(),'Home Page - JYTGameStore')]";
        public string textMainPageTitleXpath = "/html/body/div/main//div/h1[contains(text(),'Welcome to the JYT Game store!')]";
        
        ////////////////////////////////////////////////////////////////////////////////
        // User Registration & Login

        //#################### User Registration page ##################################
        public string titleUserRegistrationXpath = "/html/body/div/main/ol/span[contains(text(),'User Registration')]";
        public string inputUserRegistrationUserNameXpath = "//form/div/input[@id='UserName']";
        public string inputUserRegistrationEmailXpath = "//form/div/input[@id='Email']";
        public string inputUserRegistrationPasswordXpath = "//form/div/input[@id='Password']";
        public string inputUserRegistrationConfirmPasswordXpath = "//form/div/input[@id='ConfirmPassword']";
        public string inputUserRegistrationCaptchaXpath = "//form//div/input[@id='DNTCaptchaInputText']";
        public string buttonUserRegistrationRegisterXpath = "//form/button[@type='submit'][contains(text(),'Register')]";

        public string errorUserRegistrationUserNameXpath = "//form/div//span[@id='UserName-error']";
        public string errorUserRegistrationEmailXpath = "//form/div//span[@id='Email-error']";
        public string errorUserRegistrationPasswordXpath = "//form/div//span[@id='Password-error']";
        public string errorUserRegistrationConfirmPasswordXpath = "//form/div//span[@id='ConfirmPassword-error']";
        public string errorUserRegistrationCaptchaXpath = "//form/div//span[@id='DNTCaptchaInputText-error']";
        
        //#################### Login page ##############################################
        public string textLoginPageTitleXpath = "/html/body/div/main/div/div/h2[contains(text(),'Login')]";
        public string inputLoginEmailXpath = "//form/div/input[@id='Email']";
        public string inputLoginPasswordXpath = "//form/div/input[@id='Password']";
        public string buttonLoginLoginXpath = "//form/button[@type='submit'][contains(text(),'Login')]";

        public string errorLoginSummaryXpath = "//form/div[@data-valmsg-summary='true']/ul/li";
        public string errorLoginEmailXpath = "//form/div//span[@id='Email-error']";
        public string errorLoginPasswordXpath = "//form/div//span[@id='Password-error']";

        ////////////////////////////////////////////////////////////////////////////////
        // Game

        //#################### Selecting Games List page ###############################
        public string inputSelectingGamesSearchStringXpath = "//form/div/input[@name='SearchString']";
        public string buttonSelectingGamesSearchXpath = "//form/div//input[@type='submit'][@value='Search']";
        public string checkboxSelectingGamesSelectAllXpath = "//table/tbody/tr/td[1]/input[@type='checkbox'][@name='AreChecked']";     // All Checkbox
        public string checkboxSelectingGamesSelectXpath = "//table/tbody/tr/td[2][contains(text(),'{gameName}')]/ancestor::tr//td/input[@type='checkbox']";
        public string textSelectingGamesGameNameXpath = "//table/tbody/tr/td[2][contains(text(),'{gameName}')]";
        public string textSelectingGamesGameDescriptionXpath = "//table/tbody/tr/td[3][contains(text(),'{gameDescription}')]";
        public string buttonSelectingGamesClickToSeeGemeDetailsXpath = "//form/input[@type='submit'][@value='Click to see the geme details!']";

        //#################### Selecting Game Details page #############################
        public string textSelectingGameDetailsGameNameXpath = "//table/tbody/tr/td[1][contains(text(),'{gameName}')]";
        public string textSelectingGameDetailsGameDescriptionXpath = "//table/tbody/tr/td[2][contains(text(),'{gameDescription}')]";
        public string buttonSelectingGameDetailsGoToThePrevousPageXpath = "//main/div//a[contains(text(),'Go the the prevous page')]";

        //#################### Game List page ##########################################
        public string textGameListPageTitleXpath = "/html/body/div/main/div/div/h2[contains(text(),'Game List')]";
        public string linkGameListGameNameFirstXpath = "//table/tbody/tr[1]/td/a/b";

        //#################### Game Details page #######################################
        public string textGameDetailsPageTitleXpath = "/html/body/div/main/ol/span[contains(text(),'Game Details')]";        
        public string textGameDetailsGameNameXpath = "/html/body/div/main/div//div[contains(text(),'Game Name')]/following-sibling::div";
        public string textGameDetailsOverallRatingXpath = "/html/body/div/main/div//div[contains(text(),'Overall Rating')]/following-sibling::div";
        public string textGameDetailsOverallRatingNoRatingsYetXpath = "/html/body/div/main/div//div[contains(text(),'No ratings yet')]";

        public string radioGameDetailsGameRatingXpath = "//form/label/input[@type='radio'][@value='{gameRating}']";
        public string buttonGameDetailsRateXpath = "//form/input[@type='submit'][@value='Rate!']";        
        public string buttonGameDetailsAddToWishListXpath = "/html/body/div/main/div//div/a[contains(text(),'Add to wish list!')]";
        public string buttonGameDetailsAddToCartXpath = "/html/body/div/main/div//div/a[contains(text(),'Add to Cart')]";
        
        public string textareaGameDetailsGameReviewXpath = "//form/div/textarea[@id='ReviewTextArea']";
        public string buttonGameDetailsGameReviewSubmitXpath = "//form/div/input[@type='submit'][@value='Submit']";
        public string textGameDetailsGameReviewReviewXpath = "//table/tbody/tr/td[contains(text(),'{gameReview}')]";

        //#################### My Game page ############################################
        public string textMyGamePageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'My Game')]";
        public string textMyGameGameNameXpath = "//table/tbody/tr/td[2]/a/b[contains(text(),'{gameName}')]";
        public string buttonMyGameDownloadXpath = "//table/tbody/tr/td[2]/a/b[contains(text(),'{gameName}')]/ancestor::td/following-sibling::td/a[contains(text(),'Download')]";

        //#################### Wish List page ##########################################
        public string textWishListPageTitleXpath = "/html/body/div/main/ol/span[contains(text(),'Wish List')]";
        public string textWishListGameNameXpath = "//table/tbody/tr/td[contains(text(),'{gameName}')]";
        public string buttonWishListDeleteXpath = "//table/tbody/tr/td[contains(text(),'{gameName}')]/following-sibling::td/a[contains(text(),'Delete')]";

        //#################### Wish List Delete page ###################################
        public string textWishListDeletePageTitleXpath = "/html/body/div/main/ol/span[contains(text(),'Delete')]";        
        public string buttonWishListDeleteDeleteXpath = "//form/input[@type='submit'][@value='Delete']";

        //#################### Cart page ###############################################
        public string textCartPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Cart')]";        
        public string textCartGameNameXpath = "//table/tbody/tr/td/a[contains(text(),'{gameName}')]";        
        public string buttonCartDeleteXpath = "//table/tbody/tr/td/a[contains(text(),'{gameName}')]/ancestor::td/following-sibling::td/a[contains(text(),'Delete')]";
        public string buttonCartProceedToCheckoutXpath = "//form/div/div/input[@type='submit'][@value='Proceed to Checkout']";

        //#################### Checkout page ###########################################
        public string textCheckoutPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Checkout')]";
        public string radioCheckoutPhysicalShippingXpath = "//form/div/div/div/input[@type='radio'][@name='IsPhysicalShipping'][@value='{isPhysicalShipping}']";    // 1:Yes 0:No
        public string selectCheckoutXpathCreditCardIdXpath = "//select[@id='CreditCardId']";
        public string buttonCheckoutPlaceYourOrderXpath = "//form/div/div/input[@type='submit'][@value='Place your order']";

        public string errorCheckoutIsPhysicalShippingXpath = "//form/div/div/div/span[@data-valmsg-for='IsPhysicalShipping']/span[@id='IsPhysicalShipping-error']";
        public string errorCheckoutCreditCardXpath = "//form/div/div/div/span[@data-valmsg-for='CreditCardId']/span[@id='CreditCardId-error']";
        
        //#################### Your Orders page ########################################
        public string textOrdersPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Your Orders')]";
        public string linkOrdersOrderNumberFirstXpath = "//table/tbody/tr[1]/td[3]/a";

        //#################### Order Details page ######################################
        public string textOrderDetailsPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Order Details')]";

        ////////////////////////////////////////////////////////////////////////////////
        // Member

        //#################### Profile page ############################################
        public string textProfilePageTitleXpath = "/html/body/div/main/ol/span[contains(text(),'Profile')]";
        public string buttonProfileEditMyProfileXpath = "//form/div/a[contains(text(),'Edit My Profile')]";
        public string inputProfileFirstNameXpath = "//form/div/div/input[@id='FirstName']";
        public string inputProfileLastNameXpath = "//form/div/div/input[@id='LastName']";
        public string selectProfileGenderXpath = "//form/div/select[@id='Gender']";
        public string inputProfileDateOfBirthXpath = "//form/div/input[@id='DOB']";

        //#################### Profile Edit page #######################################
        public string textProfileEditPageTitleXpath = "/html/body/div/main/ol/span[contains(text(),'Edit')]";
        public string inputProfileEditFirstNameXpath = "//form/div/div/input[@id='FirstName']";
        public string inputProfileEditLastNameXpath = "//form/div/div/input[@id='LastName']";
        public string selectProfileEditGenderXpath = "//form/div/select[@id='Gender']";
        public string inputProfileEditDateOfBirthXpath = "//form/div/input[@id='DOB']";
        public string buttonProfileEditSaveXpath = "//form/div/input[@type='submit'][@value='Save']";

        //#################### Preference page #########################################
        public string textPreferencePageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),' Preference')]";
        public string checkboxPreferencePlatformXpath = "//form/div/div/label[contains(text(),'{platform}')]/ancestor::div/input[@type='checkbox']";
        public string checkboxPreferenceCategoryXpath = "//form/div/div/label[contains(text(),'{category}')]/ancestor::div/input[@type='checkbox']";
        public string buttonPreferenceSaveXpath = "//form/div/div/input[@type='submit'][@value='Save']";

        //#################### Address page ############################################
        public string textAddressPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Address')]";
        
        public string inputAddressMailingStreetAddressXpath = "//form/div/div/div/input[@id='MailingStreetAddress']";
        public string inputAddressMailingStreetAddress2Xpath = "//form/div/div/div/input[@id='MailingStreetAddress2']";
        public string inputAddressMailingCityXpath = "//form/div/div/div/input[@id='MailingCity']";
        public string selectAddressMailingProvinceCodeXpath = "//form/div/div/div/select[@id='MailingProvinceCode']";
        public string inputAddressMailingPostalCodeXpath = "//form/div/div/div/input[@id='MailingPostalCode']";

        public string checkboxAddressMailingShippingSameXpath = "//form/div/div/div/input[@id='MailingShippingSame']";

        public string inputAddressShippingStreetAddressXpath = "//form/div/div/div/input[@id='ShippingStreetAddress']";
        public string inputAddressShippingStreetAddress2Xpath = "//form/div/div/div/input[@id='ShippingStreetAddress2']";
        public string inputAddressShippingCityXpath = "//form/div/div/div/input[@id='ShippingCity']";        
        public string selectAddressShippingProvinceCodeXpath = "//form/div/div/div/select[@id='ShippingProvinceCode']";        
        public string inputAddressShippingPostalCodeXpath = "//form/div/div/div/input[@id='ShippingPostalCode']";
        
        public string buttonAddressEditAddressXpath = "//form/div/div/input[@type='submit'][@value='Edit Address']";

        //#################### Address Edit page #######################################
        public string textAddressEditPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Address')]";

        public string inputAddressEditMailingStreetAddressXpath = "//form/div/div/div/input[@id='MailingStreetAddress']";
        public string inputAddressEditMailingStreetAddress2Xpath = "//form/div/div/div/input[@id='MailingStreetAddress2']";
        public string inputAddressEditMailingCityXpath = "//form/div/div/div/input[@id='MailingCity']";
        public string selectAddressEditMailingProvinceCodeXpath = "//form/div/div/div/select[@id='MailingProvinceCode']";
        public string inputAddressEditMailingPostalCodeXpath = "//form/div/div/div/input[@id='MailingPostalCode']";

        public string checkboxAddressEditMailingShippingSameXpath = "//form/div/div/div/input[@id='MailingShippingSame']";

        public string inputAddressEditShippingStreetAddressXpath = "//form/div/div/div/input[@id='ShippingStreetAddress']";
        public string inputAddressEditShippingStreetAddress2Xpath = "//form/div/div/div/input[@id='ShippingStreetAddress2']";
        public string inputAddressEditShippingCityXpath = "//form/div/div/div/input[@id='ShippingCity']";
        public string selectAddressEditShippingProvinceCodeXpath = "//form/div/div/div/select[@id='ShippingProvinceCode']";
        public string inputAddressEditShippingPostalCodeXpath = "//form/div/div/div/input[@id='ShippingPostalCode']";

        public string buttonAddressEditSaveAddressXpath = "//form/div/div/input[@type='submit'][@value='Save Address']";

        public string errorAddressEditMailingStreetAddressXpath = "//form/div//span[@id='MailingStreetAddress-error']";
        public string errorAddressEditMailingCityXpath = "//form/div//span[@id='MailingCity-error']";
        public string errorAddressEditMailingPostalCodeXpath = "//form/div//span[@id='MailingPostalCode-error']";
        public string errorAddressEditShippingStreetAddressXpath = "//form/div//span[@id='ShippingStreetAddress-error']";
        public string errorAddressEditShippingCityXpath = "//form/div//span[@id='ShippingCity-error']";
        public string errorAddressEditShippingPostalCodeXpath = "//form/div//span[@id='ShippingPostalCode-error']";

        //#################### Credit Card List page ###################################
        public string textCreditCardPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Credit Card')]";
        public string buttonCreditCardAddCreditCardXpath = "//form/div/div/a[contains(text(),'Add Credit Card')]";
        public string textCreditCardCreditCardNumberXpath = "//table/tbody/tr/td[contains(text(),'{creditCardNumber}')]";
        public string buttonCreditCardEditXpath = "//table/tbody/tr/td[contains(text(),'{creditCardNumber}')]/following-sibling::td/a[contains(text(),'Edit')]";
        public string buttonCreditCardDeleteXpath = "//table/tbody/tr/td[contains(text(),'{creditCardNumber}')]/following-sibling::td/a[contains(text(),'Delete')]";
        
        //#################### Credit Card Add page ####################################
        public string textCreditCardAddPageTitleXpath = "/html/body/div/main/div/div/div/h2[contains(text(),'Add New Credit Card')]";
        public string inputCreditCardAddCreditCardNumberXpath = "//form//div/input[@id='CCNumber']";
        public string inputCreditCardAddExpireMonthXpath = "//form//div/input[@id='CCMonth']";
        public string inputCreditCardAddExpireYearXpath = "//form//div/input[@id='CCYear']";
        public string inputCreditCardAddPinXpath = "//form//div/input[@id='CCPIN']";
        public string buttonCreditCardAddAddCreditCardXpath = "//form/div/div/input[@type='submit'][@value='Add Credit Card']";

        public string errorCreditCardAddCreditCardNumberXpath = "//form/div//span[@id='CCNumber-error']";
        public string errorCreditCardAddExpireMonthXpath = "//form/div//span[@id='CCMonth-error']";
        public string errorCreditCardAddExpireYearXpath = "//form/div//span[@id='CCYear-error']";
        public string errorCreditCardAddPinXpath = "//form/div//span[@id='CCPIN-error']";

        public string errorCreditCardAddCreditCardNumberValidationXpath = "//form/div//span[@data-valmsg-for='CCNumber']";        
        public string errorCreditCardAddExpireMonthValidationXpath = "//form/div//span[@data-valmsg-for='CCMonth']";        
        public string errorCreditCardAddExpireYearValidationXpath = "//form/div//span[@data-valmsg-for='CCYear']";
        public string errorCreditCardAddPinValidationXpath = "//form/div//span[@data-valmsg-for='CCPIN']";

        //#################### Credit Card Edit page ###################################
        public string textCreditCardEditPageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Edit Credit Card')]";
        public string inputCreditCardEditCreditCardNumberXpath = "//form//div/input[@id='CCNumber']";
        public string inputCreditCardEditExpireMonthXpath = "//form//div/input[@id='CCMonth']";
        public string inputCreditCardEditExpireYearXpath = "//form//div/input[@id='CCYear']";
        public string inputCreditCardEditPinXpath = "//form//div/input[@id='CCPIN']";
        public string buttonCreditCardEditSaveCreditCardXpath = "//form/div/div/input[@type='submit'][@value='Save Credit Card']";

        //#################### Credit Card Delete page #################################
        public string textCreditCardDeletePageTitleXpath = "/html/body/div/main/div/ol/span[contains(text(),'Delete Credit Card')]";
        public string buttonCreditCardDeleteDeleteCreditCardXpath = "//form/div/div/input[@type='submit'][@value='Delete Credit Card']";



        ////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
        /// 
        /// Employee Panel
        /// 
        ////////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////////
        // Event (Employee Panel)

        //#################### Event List page #########################################
        public string buttonEventListCreateNewEventXpath = "/html/body/div/main/div/a[contains(text(),'Create New Event')]";
        public string textEventListEventNameXpath = "//table/tbody/tr/td[1]/a[contains(text(),'{eventName}')]";      // {eventName}
        public string buttonEventListEditXpath = "//table/tbody/tr/td/a[contains(text(),'{eventName}')]/ancestor::td/following-sibling::td/a[contains(text(),'Edit')]";
        public string buttonEventListDeleteXpath = "//table/tbody/tr/td/a[contains(text(),'{eventName}')]/ancestor::td/following-sibling::td/a[contains(text(),'Delete')]";

        //#################### Event New page ##########################################
        public string inputEventNewNameXpath = "//input[@id='Name']";
        public string inputEventNewDescriptionXpath = "//textarea[@id='Description']";
        public string inputEventNewStartDateXpath = "//input[@id='StartDate']";
        public string inputEventNewEndDateXpath = "//input[@id='EndDate']";
        public string inputEventNewPublishDateXpath = "//input[@id='PublishDate']";
        public string inputEventNewPublisherXpath = "//input[@id='Publisher']";

        public string buttonEventNewCreateXpath = "//form/div/input[@type='submit'][@value='Create']";

        public string errorEventNewNameXpath = "//form/div//span[@id='Name-error']";
        public string errorEventNewDescriptionXpath = "//form/div//span[@id='Description-error']";
        public string errorEventNewStartDateXpath = "//form/div//span[@id='StartDate-error']";
        public string errorEventNewEndDateXpath = "//form/div//span[@id='EndDate-error']";
        public string errorEventNewPublishDateXpath = "//form/div//span[@id='PublishDate-error']";
        public string errorEventNewPublisherXpath = "//form/div//span[@id='Publisher-error']";

        //#################### Event Edit page #########################################
        public string inputEventEditNameXpath = "//input[@id='Name']";
        public string inputEventEditDescriptionXpath = "//textarea[@id='Description']";
        public string inputEventEditStartDateXpath = "//input[@id='StartDate']";
        public string inputEventEditEndDateXpath = "//input[@id='EndDate']";
        public string inputEventEditPublishDateXpath = "//input[@id='PublishDate']";
        public string inputEventEditPublisherXpath = "//input[@id='Publisher']";

        public string buttonEventEditSaveXpath = "//form/div/input[@type='submit'][@value='Save']";
        public string buttonEventEditBackToListXpath = "//form/div/a[contains(text(),'Back to List')]";

        public string errorEventEditNameXpath = "//form/div//span[@id='Name-error'][contains(text(),'This field is required.')]";
        public string errorEventEditDescriptionXpath = "//form/div//span[@id='Description-error'][contains(text(),'This field is required.')]";
        public string errorEventEditStartDateXpath = "//form/div//span[@id='StartDate-error'][contains(text(),'The Start Date field is required.')]";
        public string errorEventEditEndDateXpath = "//form/div//span[@id='EndDate-error'][contains(text(),'The End Date field is required.')]";
        public string errorEventEditPublishDateXpath = "//form/div//span[@id='PublishDate-error'][contains(text(),'The Publish Date field is required.')]";
        public string errorEventEditPublisherXpath = "//form/div//span[@id='Publisher-error'][contains(text(),'This field is required.')]";

        //#################### Event Delete page #######################################
        public string buttonEventDeteteDeteteXpath = "//form/input[@type='submit'][@value='Delete']";

        ////////////////////////////////////////////////////////////////////////////////
        // Game (Employee Panel)

        //#################### Game List page ##########################################
        public string buttonGameListCreateNewEventXpath = "/html/body/div/main/div/div/a[contains(text(),'Create a new game')]";
        public string textGameListGameNameXpath = "//table/tbody/tr/td[2]/b[contains(text(),'{gameName}')]";
        public string buttonGameListEditXpath = "//table/tbody/tr/td/b[contains(text(),'{gameName}')]/ancestor::td/following-sibling::td/div/a[contains(text(),'Edit')]";
        public string buttonGameListDeleteXpath = "//table/tbody/tr/td/b[contains(text(),'{gameName}')]/ancestor::td/following-sibling::td/div/a[contains(text(),'Delete')]";
        public string buttonGameListDownloadReportXpath = "//table/tbody/tr/td/b[contains(text(),'{gameName}')]/ancestor::td/following-sibling::td/div/a[contains(text(),'Download Report')]";

        //#################### Game Add page ###########################################
        public string inputGameAddGameNameXpath = "//input[@id='GameName']";
        public string selectGameAddGameCategoryXpath = "//select[@id='CategoryID']";
        public string inputGameAddPriceXpath = "//input[@id='Price']";
        public string inputGameAddGameImageXpath = "//input[@id='ImageUpload']";
        public string inputGameAddGameDescriptionXpath = "//textarea[@id='GameDescription']";
        
        public string buttonGameAddCreateGameXpath = "//form/div//input[@type='submit'][@value='Create a game']";
        public string buttonGameAddCancelXpath = "//form/div//a[contains(text(),'Cancel')]";

        public string errorGameAddGameNameXpath = "//form/div//span[@id='GameName-error']";
        public string errorGameAddGameDescriptionXpath = "//form/div//span[@id='GameDescription-error']";

        //#################### Game Edit page ##########################################
        public string inputGameEditGameNameXpath = "//input[@id='GameName']";
        public string inputGameEditGameDescriptionXpath = "//textarea[@id='GameDescription']";

        public string buttonGameEditCreateGameXpath = "//form/div//input[@type='submit'][@value='Edit a game']";
        public string buttonGameEditCancelXpath = "//form/div//a[contains(text(),'Cancel')]";

        public string errorGameEditGameNameXpath = "//form/div//span[@id='GameName-error']";
        public string errorGameEditGameDescriptionXpath = "//form/div//span[@id='GameDescription-error']";

        //#################### Game Delete page ########################################
        public string buttonGameDeteteDeteteGameXpath = "//form/div//input[@type='submit'][@value='Delete a game']";
        public string buttonGameDeteteCancelXpath = "//form/div//a[contains(text(),'Cancel')]";

        ////////////////////////////////////////////////////////////////////////////////
        // Game Category (Employee Panel)

        //#################### Cateory List page #######################################
        public string buttonCateoryListCreateNewGameCategoryXpath = "//main/div/div/div/a[contains(text(),'Create New Game Category')]";
        public string textCateoryListCategoryNameXpath = "//table/tbody/tr/td[1][contains(text(),'{categoryName}')]";      // {categoryName} ex) 'Fun Game'
        public string buttonCateoryListEditXpath = "//table/tbody/tr/td[contains(text(),'{categoryName}')]/following-sibling::td/div/a[contains(text(),'Edit')]";
        public string buttonCateoryListDeleteXpath = "//table/tbody/tr/td[contains(text(),'{categoryName}')]/following-sibling::td/div/a[contains(text(),'Delete')]";

        //#################### Cateory Add page ########################################
        public string inputCateoryAddCategoryNameXpath = "//input[@id='CategoryName']";
        public string buttonCateoryAddCreateXpath = "//form/div/div/input[@type='submit'][@value='Create']";
        public string errorCateoryAddCategoryNameXpath = "//form/div//span[@id='CategoryName-error']";

        //#################### Cateory Edit page #######################################
        public string inputCateoryEditCategoryNameXpath = "//input[@id='CategoryName']";
        public string buttonCateoryEditUpdateXpath = "//form/div/div/input[@type='submit'][@value='Update']";
        public string buttonCateoryEditBackXpath = "//form/div/div/a[contains(text(),'Back')]";
        public string errorCateoryEditCategoryNameXpath = "//form/div//span[@id='CategoryName-error']";

        //#################### Cateory Delete page #####################################
        public string buttonCateoryDeteteDeteteXpath = "//form/div/div/input[@type='submit'][@value='Delete']";

        ////////////////////////////////////////////////////////////////////////////////
        // Reports (Employee Panel)

        //#################### Reports page ############################################
        public string textReportsPageTitleXpath = "/html/body/div/main/div/h1[contains(text(),'JYT GAME STORE Reports')]";
        public string linkReportsReportGamesXpath = "/html/body/div/main/div/a[contains(text(),'Report Games')]";
        public string linkReportsReportEventsXpath = "/html/body/div/main/div/a[contains(text(),'Report Events')]";
        public string linkReportsDownloadMembersReportXpath = "/html/body/div/main/div/a[contains(text(),'Download Members Report')]";
        public string linkReportsDownloadWishlistReportXpath = "/html/body/div/main/div/a[contains(text(),'Download Wishlist Report')]";
        public string linkReportsDownloadOrdersReportXpath = "/html/body/div/main/div/a[contains(text(),'Download Orders Report')]";
        public string linkReportsDownloadSalesReportXpath = "/html/body/div/main/div/a[contains(text(),'Download Sales Report')]";
        public string linkReportsDownloadDetailMemberReportXpath = "/html/body/div/main/div/a[contains(text(),'Download Detail Member Report')]";
        public string linkReportsDownloadDetailGameReportXpath = "/html/body/div/main/div/a[contains(text(),'Download Detail Game Report')]";

        //#################### Games Report page #######################################
        public string textGamesReportTitleXpath = "/html/body/div/main//div[contains(text(),'Games Report')]";
        public string buttonGamesReportDownloadPdfXpath = "/html/body/div/main/a[contains(text(),'Download PDF')]";

        //#################### Events Report page ######################################
        public string textEventsReportTitleXpath = "/html/body/div/main//div[contains(text(),'Events Report')]";
        public string buttonEventsReportDownloadPdfXpath = "/html/body/div/main/a[contains(text(),'Download PDF')]";
        
        ////////////////////////////////////////////////////////////////////////////////
        // Review Game Review (Employee Panel)

        //#################### Review Game Reviews page ################################
        public string textReviewGameReviewsPageTitleXpath = "/html/body/div/main/ol/span[contains(text(),'Review Game Reviews')]";
        public string checkboxReviewGameReviewsSelectXpath = "//table/tbody/tr/td[contains(text(),'{gameReview}')]/ancestor::tr//td/input[@type='checkbox']";
        public string textReviewGameReviewsGameReviewDescriptionXpath = "//table/tbody/tr/td[contains(text(),'{gameReview}')]";
        public string textReviewGameReviewsApprovedOrNotYesXpath = "//table/tbody/tr/td[contains(text(),'{gameReview}')]/ancestor::tr//td/div[contains(text(),'Approved')]";
        public string textReviewGameReviewsApprovedOrNotNoXpath = "//table/tbody/tr/td[contains(text(),'{gameReview}')]/ancestor::tr//td/div[contains(text(),'Not Yet Reviewed')]";
        public string buttonReviewGameReviewsApproveXpath = "//form/input[@type='submit'][@value='Approve']";

    }
}
