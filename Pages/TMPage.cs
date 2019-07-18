using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFirst.Pages
{
    class TMPage
    {
        private IWebDriver driver;

        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        IWebElement Typecode => driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
        IWebElement code => driver.FindElement(By.Id("Code"));
        IWebElement description => driver.FindElement(By.Id("Description"));
        IWebElement PricePerUnit => driver.FindElement(By.XPath("//input[@class = 'k-formatted-value k-input']"));
        IWebElement save => driver.FindElement(By.Id("SaveButton"));
        

        
        public void Create()
        {
            //Click on Create New Button
            IWebElement createNew = driver.FindElement(By.LinkText("Create New"));
            createNew.Click();

            //Validate the page
            String myTitle4 = driver.Title;
            Console.WriteLine(myTitle4);
            Assert.That(myTitle4, Is.EqualTo("Edit - Dispatching System"));

            Typecode.Click(); //Select Typecode
            code.SendKeys("neelam1"); //Enter Code
            description.SendKeys("my first record");  //Enter Description
            PricePerUnit.SendKeys("20.00");  //Enter PricePerUnit
            save.Click();
            Thread.Sleep(1000);


            //Validate the page
            String myTitle5 = driver.Title;
            Console.WriteLine(myTitle5);
            Assert.That(myTitle5, Is.EqualTo("Index - Dispatching System"));
           
        }

        //Validate the new record
        public void validate()
        {
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var rowcount = row.Count; //getting the number of rows.
            Console.WriteLine(rowcount);

            //getting the xpath of the record in 1st column.
            String beforeXPath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath = "]/td[1]";
            Thread.Sleep(3000);


            try
            {
                while (true)
                {

                    for (int i = 1; i <= rowcount; i++)
                    {
                        String actualXPath = beforeXPath + i + afterXPath;
                        IWebElement element = driver.FindElement(By.XPath(actualXPath));
                        String GetText = element.Text;
                        if (GetText == "neelam1")
                        {
                            Console.WriteLine("The record created successfully..Test Passed ");
                            return;

                        }


                    }

                    IWebElement next = driver.FindElement(By.XPath("//span[@class ='k-icon k-i-arrow-e']"));
                    next.Click();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test failed");
            }
        }


        public void Edit()
        {
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            //getting the number of rows.
            var rowcount = row.Count;
            Console.WriteLine(rowcount);

            String beforeXPath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath = "]/td[1]";
            Thread.Sleep(3000);

            try
            {
                while (true)
                {

                    for (int i = 1; i <= rowcount; i++)
                    {
                        String actualXPath = beforeXPath + i + afterXPath;
                        IWebElement element = driver.FindElement(By.XPath(actualXPath));
                        String GetText = element.Text;
                        if (GetText == "102")
                        {
                            Console.WriteLine("The record found successfully..Test Passed ");
                            description.SendKeys("edit");
                            save.Click();
                            return;

                        }


                    }

                    IWebElement next = driver.FindElement(By.XPath("//span[@class ='k-icon k-i-arrow-e']"));
                    next.Click();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("The record not found .... Test failed");
            }
        }

        public void ValidateEdit()
        {
            //getting the number of rows.
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var rowcount = row.Count;
            Console.WriteLine(rowcount);

            String beforeXPath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath = "]/td[1]";
            Thread.Sleep(3000);

            try
            {
                while (true)
                {

                    for (int i = 1; i <= rowcount; i++)
                    {
                        String actualXPath = beforeXPath + i + afterXPath;
                        IWebElement element = driver.FindElement(By.XPath(actualXPath));
                        String GetText = element.Text;
                        if (GetText == "102")
                        {
                            Console.WriteLine("The record found successfully..Test Passed ");
                            if (description.Text == "edit")
                            {
                                Console.WriteLine("Records edited sucessfully");
                                return;
                            }
                            

                        }


                    }

                    IWebElement next = driver.FindElement(By.XPath("//span[@class ='k-icon k-i-arrow-e']"));
                    next.Click();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("The record not found .... Test failed");
            }
        }

        public void Delete()
        {
            //getting the number of rows.
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var rowcount = row.Count;
            Console.WriteLine(rowcount);

            String beforeXPath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath = "]/td[1]";
            Thread.Sleep(3000);

            try
            {
                while (true)
                {

                    for (int i = 1; i <= rowcount; i++)
                    {
                        String actualXPath = beforeXPath + i + afterXPath;
                        IWebElement element = driver.FindElement(By.XPath(actualXPath));
                        String GetText = element.Text;
                        if (GetText == "5454")
                        {
                            Console.WriteLine("The record found successfully..Test Passed ");
                           

                         IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
                         deleteRecord.Click();

                            //handling Alerts popup
                            IAlert alert = driver.SwitchTo().Alert();
                            alert.Accept();
                            return;

                        }


                    }

                    IWebElement next = driver.FindElement(By.XPath("//span[@class ='k-icon k-i-arrow-e']"));
                    next.Click();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("The record not found .... Test failed");
            }
        }

        // Validate the record deleted.

        public void ValidateDelete()
        {
            //getting the number of rows
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var rowcount = row.Count;
            Console.WriteLine(rowcount);

            String beforeXPath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
            String afterXPath = "]/td[1]";
            Thread.Sleep(3000);
            try
            {
                while (true)
                {

                    for (int i = 1; i <= rowcount; i++)
                    {
                        String actualXPath = beforeXPath + i + afterXPath;
                        IWebElement element = driver.FindElement(By.XPath(actualXPath));
                        String GetText = element.Text;
                        if (GetText == "5454")
                        {
                            Console.WriteLine("The record not deleted sucessfully..Test failed");
                            return;




                        }


                    }

                    IWebElement next = driver.FindElement(By.XPath("//span[@class ='k-icon k-i-arrow-e']"));
                    next.Click();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("The record not found .... Test failed");
            }
        }





    }
}
