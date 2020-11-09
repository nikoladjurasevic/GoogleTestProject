using GoogleTestProject.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GoogleTestProject.tests 
{
    public class Tests : BaseTest
    {
        IWebDriver driver = null;
        [SetUp]

        public void Setup()
        {
             driver = openChromeDriver();
        }


        [Test]
        public void TestLogoPresence()
        {
            System.Console.WriteLine("TestLogoPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isLogoPresent(), "Logo is not present");
            Assert.Pass();
        }

        [Test]
        public void TestSearchFieldPresence()
        {
            System.Console.WriteLine("TestSearchFieldPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isSearchFieldPresent(), "Search field is not present");
            Assert.Pass();
        }

        [Test]
        public void TestGoogleSearchButtonPresence()
        {
            System.Console.WriteLine("TestGoogleSearchButtonPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isGoogleSearchButtonPresent(), "Google Search button is not present");
            String sButtonText = googleSearchPage.getSearchButtonText();
            Assert.True(sButtonText.Equals("Google претрага"));
            Assert.Pass();
        }

        [Test]
        public void TestImFeelingLuckyButtonPresence()
        {
            System.Console.WriteLine("TestImFeelingLuckyButtonPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isImFeelingLuckyButtonPreent(), "Im Feeling Lucky button is not present");
            String sButtonText = googleSearchPage.getImFeelingLuckyButtonTextx();
            Assert.True(sButtonText.Equals("Из прве руке"));
            Assert.Pass();
        }

        [Test]
        public void TestimagesLinkPresence()
        {
            System.Console.WriteLine("TestimagesLinkPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isImagesLinkPresent(), "Images link is not present");
            String sButtonText = googleSearchPage.getImagesLinkText();
            Assert.True(sButtonText.Equals("Слике"));
            Assert.Pass();
        }

        [Test]
        public void TestGmailLinkPresence()
        {
            System.Console.WriteLine("TestGmailLinkPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isGmailLinkPresent(), "Gmail link is not present");
            String sButtonText = googleSearchPage.getGmailLinkText();
            Assert.True(sButtonText.Equals("Gmail"));
            Assert.Pass();
        }

        [Test]
        public void TestApplicationsPresence()
        {
            System.Console.WriteLine("TestAppsPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isApplicationsPresent(), "Applications are not present");
            Assert.Pass();
        }

        [Test]
        public void TestSignInButtonPresence()
        {
            System.Console.WriteLine("TestSignInButtonPresence");
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            Assert.True(googleSearchPage.isSignInButtonPresent(), "Sign in Button is not present");
            String sButtonText = googleSearchPage.getSignInButtonText();
            Assert.True(sButtonText.Equals("Пријавите се"));
            Assert.Pass();
        }

        [Test]
        public void TestSearchForShowingTime()
        {
            System.Console.WriteLine("TestSearchForShowingTime");
            String sShowingTimeURL = "https://www.showingtime.com/";
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(driver);
            googleSearchPage.enterSearchText("ShowingTime");
            
            googleSearchPage.clickGoogleSearchButton();
            googleSearchPage.checkUrl("search");
          
            String sUrl = googleSearchPage.getLinkFromFirstResult();
            Assert.True(sUrl.Contains(sShowingTimeURL), "Wrong Url: Expected: " + sShowingTimeURL + ". Actual: " + sUrl);

            googleSearchPage.clickOnLinkInFirstResult();
            googleSearchPage.checkUrl(sShowingTimeURL);

            Assert.Pass();
        }


        [TearDown]
        public void closeBrower()
        {
            driver.Quit();
        }
    }
}