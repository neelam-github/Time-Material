using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;

namespace SeleniumFirst
{

    class Program
    {
        static void Main(string[] args)
        {

            //Launch Browser
            IWebDriver driver = new ChromeDriver();
            //Maximize the window
            driver.Manage().Window.Maximize();
            //Enter the URL
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");

            //Validate the page
            String myTitle1 = driver.Title;
            Console.WriteLine(myTitle1);

            if (myTitle1 == "Log In - Dispatching System")
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
            Console.WriteLine(myTitle2);
            if (myTitle2 == "Dashboard - Dispatching System")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }

            // navigate to time and material page
            IWebElement admin = driver.FindElement(By.XPath("//a[@role = 'button']"));
            admin.Click();
            IWebElement TimeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeAndMaterial.Click();

            //System.Threading.Thread.Sleep(5000);
            //select2.SelectByText("Time & Materials");

            //Validate the page
            String myTitle3 = driver.Title;
            Console.WriteLine(myTitle3);
            if (myTitle3 == "Index - Dispatching System")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }
            //Click on Create New Button
            IWebElement createNew = driver.FindElement(By.LinkText("Create New"));
            createNew.Click();
            //Validate the page
            String myTitle4 = driver.Title;
            Console.WriteLine(myTitle4);
            if (myTitle4 == "Edit - Dispatching System")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }
            //Select Typecode
            IWebElement Typecode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            Typecode.Click();

            //Enter Code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("neelam1");

            //Enter Description
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("my first record");

            //Enter PricePerUnit
            //IWebElement PricePerUnit = driver.FindElement(By.XPath("//input[@type = 'text']"));
            //PricePerUnit.SendKeys("20.00");

            //Select files
            //IWebElement SelectFile = driver.FindElement(By.Id("files"));
            //SelectFile.SendKeys("C:\\Users\\Neelam\\Documents\\test");
            //SelectFile.Click();
            //AutoItX3 autoIt = new AutoItX3();
            //autoIt.WinActivate("Open");
            //autoIt.Send("C:\\Users\\Neelam\\Documents\\test");
            //Thread.Sleep(1000);
            //autoIt.Send("Enter");
          

            //Click on Save
            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();
            Thread.Sleep(1000);
            //Validate the page
            String myTitle5 = driver.Title;
            Console.WriteLine(myTitle5);
            if (myTitle5 == "Index - Dispatching System")
            {
                Console.WriteLine("The testcase passed");
            }
            else
            {
                Console.WriteLine("The test case failed");
            }

            Thread.Sleep(1000);
            //Navigate to last page
            //IWebElement LastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            //LastPage.Click();

            //Validate the new record

            //getting the number of rows.
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            int rowcount = row.Count;
            //*[@id="tmsGrid"]/div[3]/table/tbody/tr[1]/td[1] 
            //*[@id="tmsGrid"]/div[3]/table/tbody/tr[8]/td[1]
            //*[@id="tmsGrid"]/div[3]/table/tbody/tr[5]/td[1]

            String beforeXPath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath = "]/td[1]";
            for (int i = 1; i <= rowcount; i++)
            {
                String actualXPath = beforeXPath + i + afterXPath;
                IWebElement element = driver.FindElement(By.XPath(actualXPath));
                String GetText = element.Text;
                if (GetText == "neelam1")
                {
                    Console.WriteLine("The record created successfully..Test Passed ");
                }
                else
                {
                    
                    IWebElement arrow = driver.FindElement(By.XPath("//span[@class = 'k-icon k-i-arrow-e']"));
                    arrow.Click();
                   // Console.WriteLine("The record is not created sucessfully....Test Failed");
                }
                
            }

            //Edit Details:

            IList<IWebElement> row1 = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            int rowcount1 = row.Count;

            String beforeXPath1 = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath1 = "]/td[1]";
            for (int i = 1; i <= rowcount1; i++)
            {
                String actualXPath = beforeXPath1 + i + afterXPath1;
                IWebElement element = driver.FindElement(By.XPath(actualXPath));
                String GetText = element.Text;
                if (GetText == "CodeXXX")
                {
                    IWebElement edit = driver.FindElement(By.XPath("//a[@class= 'k-button k-button-icontext k-grid-Edit']"));
                    edit.Click();

                    String myTitle6 = driver.Title;
                    if(myTitle6=="Edit - Dispatching System")
                    {
                        IWebElement price = driver.FindElement(By.XPath("//input[@class = 'k-formatted-value k-input']"));
                        price.SendKeys("12");
                        IWebElement save1 = driver.FindElement(By.Id("SaveButton"));
                        save1.Click();
                    }
                    else { Console.WriteLine("Page Error"); }
                    
                }
                else
                {

                    IWebElement arrow = driver.FindElement(By.XPath("//span[@class = 'k-icon k-i-arrow-e']"));
                    arrow.Click();
                    // Console.WriteLine("The record is not created sucessfully....Test Failed");
                }

            }
           // Validate the change


        }
    } 
}
