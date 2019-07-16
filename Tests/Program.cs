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
            //define driver
            CommonDriver.driver = new ChromeDriver();
            //object for login
            LogIn loginobj = new LogIn();
            loginobj.LoginStep(CommonDriver.driver);

            //object for Homepage
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateTM(CommonDriver.driver);
        }
        [Test]
        public void Create()
        {
            //object for TM page
            TMPage tmpageobj = new TMPage();
            tmpageobj.Create(CommonDriver.driver);
            tmpageobj.validate(CommonDriver.driver);

        }
        [Test]
        public void Edit()
        {
            TMPage tmpageobj = new TMPage();
            tmpageobj.Edit(CommonDriver.driver);
            
        }
        [Test]
        public void Del()
        {
            TMPage tmpageobj = new TMPage();
            tmpageobj.Delete(CommonDriver.driver);
        }

       
        [TearDown]
        public void Finish()
        {
            CommonDriver.driver.Quit();
        }

       
            
           
          

            

           
        }
  } 

