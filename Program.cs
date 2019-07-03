using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst
{

    class Program
    {
         static void Main(string[] args) { 

            //Launch Browser
            IWebDriver driver = new ChromeDriver();
            //Maximize the window
            driver.Manage().Window.Maximize();
            //Enter the URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");
            //Validate the page
            String myTitle1 = driver.Title;
            if (myTitle1 == "")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }

            //Enter Username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");
            //Enter password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");
            //Click on Login
            IWebElement login = driver.FindElement(By.XPath("//input[@type='submit']"));
            login.Click();
            //Validate the page
            String myTitle2 = driver.Title;
            if (myTitle2 == "")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }

            //Click on Create New Button
            IWebElement createNew = driver.FindElement(By.XPath(""));
            createNew.Click();
            //Page Validation
            String myTitle3 = driver.Title;
            if (myTitle3 == "")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }
            //Select Typecode
            IWebElement Typecode = driver.FindElement(By.Id(""));
            SelectElement select = new SelectElement(Typecode);
            //Enter Code
            IWebElement code = driver.FindElement(By.Id(""));
            code.SendKeys("");
            //Enter Description
            IWebElement description = driver.FindElement(By.Id(""));
            description.SendKeys("");
            //Enter PricePerUnit
            IWebElement PricePerUnit = driver.FindElement(By.Id(""));
            PricePerUnit.SendKeys("");
            //Select files
            IWebElement SelectFile = driver.FindElement(By.Id(""));
            SelectFile.SendKeys("");
            //Click on Download
            IWebElement download = driver.FindElement(By.XPath(""));
            download.Click();
            //Click on Save
            IWebElement save = driver.FindElement(By.XPath(""));
            save.Click();
            //Validate the Page and the new record is created sucessfully
            String myTitle4 = driver.Title;
            if (myTitle4 == "")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }



        }

    } 
}
