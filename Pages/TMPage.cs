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
        public void Create(IWebDriver driver)
        {
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
            IWebElement PricePerUnit = driver.FindElement(By.XPath("//input[@class = 'k-formatted-value k-input']"));
            PricePerUnit.SendKeys("20.00");

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
            IWebElement LastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            LastPage.Click();

            //Validate the new record

            //getting the number of rows.
            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var rowcount = row.Count;
            Console.WriteLine(rowcount);

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
                    Console.WriteLine("The record is not created sucessfully....Test Failed");
                }

            }


        }
        public void Edit(IWebDriver driver)
        {
            //Edit Records
            IList<IWebElement> pagination = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[4]/ul/li"));
            var NoOfPages = pagination.Count;
            Console.WriteLine(NoOfPages);
            for (var j = 1; j <= NoOfPages; j++)
            {
                String beforePath = "//*[@id='tmsGrid']/div[4]/ul/li[";
                String afterPath = "]/a";
                String actual = beforePath + j + afterPath;
                IWebElement element1 = driver.FindElement(By.XPath(actual));
                element1.Click();


                //getting the number of rows.
                IList<IWebElement> row1 = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
                var rowcount1 = row1.Count;
                Console.WriteLine(rowcount1);
                String beforeXPath1 = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[";
                String afterXPath1 = "]/td[1]";
                for (int k = 1; k <= rowcount1; k++)
                {
                    String actualXPath = beforeXPath1 + k + afterXPath1;
                    IWebElement element = driver.FindElement(By.XPath(actualXPath));
                    String GetText = element.Text;
                    if (GetText == "neelam1")
                    {
                        IWebElement edit = driver.FindElement(By.XPath("//a[@class= 'k-button k-button-icontext k-grid-Edit']"));
                        edit.Click();

                        String myTitle6 = driver.Title;
                        Assert.That(myTitle6, Is.EqualTo("Edit - Dispatching System"));
                        // if (myTitle6 == "Edit - Dispatching System")
                        //{
                        IWebElement price = driver.FindElement(By.XPath("//input[@class = 'k-formatted-value k-input']"));
                        price.SendKeys("12");
                        IWebElement save1 = driver.FindElement(By.Id("SaveButton"));
                        save1.Click();


                    }
                }
            }
        }
        public void Delete(IWebDriver driver)
        {

        }

    }          
}