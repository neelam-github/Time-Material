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
using SeleniumFirst.Pages;
using SeleniumFirst.Helper;

namespace SeleniumFirst
{
    [TestFixture]
    class Program
    {


        static void Main(string[] args)
        { }
            [SetUp]
        public void LogIn()
        {
            // Populate Data from excel
            ExcelLib.PopulateInCollection(@"C:\Users\Neelam\Documents\Visual Studio 2019\Projects\SeleniumFirst\SeleniumFirst\Data\data.xlsx", "TM");

            //define driver
            CommonDriver.driver = new ChromeDriver();
            //object for login
            LogIn loginobj = new LogIn(CommonDriver.driver);
            loginobj.LoginStep();

            //object for Homepage
            HomePage homepageobj = new HomePage(CommonDriver.driver);
            homepageobj.NavigateTM();
        }
        [Test]
        public void Create()
        {
            //object for TM page
            TMPage tmpageobj = new TMPage(CommonDriver.driver);
            tmpageobj.Create();
            tmpageobj.validate();

        }
        [Test]
        public void Edit()
        {
            TMPage tmpageobj = new TMPage(CommonDriver.driver);
            tmpageobj.Edit();
            tmpageobj.ValidateEdit();
            
        }
        [Test]
        public void Delete()
        {
            TMPage tmpageobj = new TMPage(CommonDriver.driver);
            tmpageobj.Delete();
            tmpageobj.ValidateDelete();
        }

       
        [TearDown]
        public void Finish()
        {
            CommonDriver.driver.Quit();
        }

       
            
           
          

            

           
        }
  } 

