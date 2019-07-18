using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.Pages
{
    class LogIn
    {
        private IWebDriver driver;

        public LogIn(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement username => driver.FindElement(By.Id("UserName"));
        IWebElement password => driver.FindElement(By.Id("Password"));
        IWebElement login => driver.FindElement(By.XPath("//input[@type='submit']"));
       

        public void LoginStep()
        {
           
          
        //Maximize the window
        driver.Manage().Window.Maximize();
            //Enter the URL
            // driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");
            driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));

            //Validate the page
            String myTitle1 = driver.Title;
            Console.WriteLine(myTitle1);
            Assert.That(myTitle1, Is.EqualTo("Log In - Dispatching System"));

            //Enter Username
            //username.SendKeys("hari");
            username.SendKeys(ExcelLib.ReadData(2, "username"));  


            //Enter password

            //password.SendKeys("123123");
            password.SendKeys(ExcelLib.ReadData(2, "password"));
            //Click on Login

            login.Click();

        }
    }
}
