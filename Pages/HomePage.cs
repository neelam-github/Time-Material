using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTM()
        {
            //Validate the page
            String myTitle2 = driver.Title;
            Console.WriteLine(myTitle2);
            Assert.That(myTitle2, Is.EqualTo("Dashboard - Dispatching System"));
           // if (myTitle2 == "Dashboard - Dispatching System")
           // {
            //    Console.WriteLine("The testcase passed");
            //
           // else
            //{
            //    Console.WriteLine("The test case failed");
           // }

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
            Assert.That(myTitle3, Is.EqualTo("Index - Dispatching System"));
            // if (myTitle3 == "Index - Dispatching System")
            //{
            //  Console.WriteLine("The testcase passed");
            //}
            //else
            //{
            // Console.WriteLine("The test case failed");
            //}
        }

    }
}
