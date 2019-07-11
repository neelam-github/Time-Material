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
        public void LoginStep(IWebDriver driver)
        {
           
          
        //Maximize the window
        driver.Manage().Window.Maximize();
            //Enter the URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");

        //Validate the page
        String myTitle1 = driver.Title;
        Console.WriteLine(myTitle1);
            Assert.That(myTitle1, Is.EqualTo("Log In - Dispatching System"));
                
           // if (myTitle1 == "Log In - Dispatching System")
            //{
              //  Console.WriteLine("The testcase passed");
            //}
            //else
            //{
              //  Console.WriteLine("The test case failed");
            //}

//Enter Username
IWebElement username = driver.FindElement(By.Id("UserName"));
username.SendKeys("hari");
            //Enter password
            IWebElement password = driver.FindElement(By.Id("Password"));
password.SendKeys("123123");
            //Click on Login
            IWebElement login = driver.FindElement(By.XPath("//input[@type='submit']"));
login.Click();

        }
    }
}
