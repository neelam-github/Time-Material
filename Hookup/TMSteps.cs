using OpenQA.Selenium.Chrome;
using SeleniumFirst.Helper;
using SeleniumFirst.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFirst.Hookup
{
    [Binding]
    public class TMSteps
    {
        [Given(@"I have logged in to the TM portal with sucessfully")]
        public void GivenIHaveLoggedInToTheTMPortalWithSucessfully()
        {
            //define driver
            CommonDriver.driver = new ChromeDriver();
            //object for login
            LogIn loginobj = new LogIn();
            loginobj.LoginStep(CommonDriver.driver);
        }
        
        [Given(@"I have navigated to the Time and Material page")]
        public void GivenIHaveNavigatedToTheTimeAndMaterialPage()
        {
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateTM(CommonDriver.driver);
        }
        
        [Then(@"I would be able to create a time record with valid details sucessfully")]
        public void ThenIWouldBeAbleToCreateATimeRecordWithValidDetailsSucessfully()
        {
            //object for TM page
            TMPage tmpageobj = new TMPage();
            tmpageobj.Create(CommonDriver.driver);

        }
    }
}
