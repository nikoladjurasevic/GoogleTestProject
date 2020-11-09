using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleTestProject.pages
{
    class GoogleSearchPage
    {
        //String sGoogleUrl = "http://www.google.com";

        [FindsBy(How = How.CssSelector, Using = "#hplogo")]
        private IWebElement logoLocator;

        [FindsBy(How = How.Name, Using ="q")]
        private IWebElement searchFieldLocator;

        [FindsBy(How = How.XPath, Using = "//div[@class='FPdoLc tfB0Bf']//input[@name='btnK']")]
        private IWebElement googleSearchButtonLocator;

        [FindsBy(How = How.XPath, Using = "//div[@class='FPdoLc tfB0Bf']//input[@name='btnI']")]
        private IWebElement imfeelingLuckyButtonLocator;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'mail.google')]")]
        private IWebElement gmailLinkLocator;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'imghp')]")]
        private IWebElement imagesLinkLocator;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'about/products')]")]
        private IWebElement appsLocator;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'accounts.google.com/ServiceLogin')]")]
        private IWebElement signInButtonLocator;

        [FindsBy(How = How.LinkText, Using = "Search Results")]
        private IWebElement searchResultsSectionLocator;

        protected IWebDriver driver = null;
        protected WebDriverWait wait;

        public GoogleSearchPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public Boolean isLogoPresent()
        {
            System.Console.WriteLine("isLogoPresent()");
            return isElementPresent(logoLocator);
        }

        public Boolean isSearchFieldPresent()
        {
            System.Console.WriteLine("isSearchFieldPresent()");
            return isElementPresent(searchFieldLocator);
        }

        public Boolean isGoogleSearchButtonPresent()
        {
            System.Console.WriteLine("isGoogleSearchButtonPresent()");
            return isElementPresent(googleSearchButtonLocator);
        }

        public String getSearchButtonText()
        {
            System.Console.WriteLine("getSearchButtonText()");
            return getValueFromLocator(googleSearchButtonLocator);
        }

        public Boolean isImFeelingLuckyButtonPreent()
        {
            System.Console.WriteLine("isImFeelingLuckyButtonPreent()");
            return isElementPresent(imfeelingLuckyButtonLocator);
        }

        public String getImFeelingLuckyButtonTextx()
        {
            System.Console.WriteLine("getSearchButtonText()");
            return getValueFromLocator(imfeelingLuckyButtonLocator);
        }

        public Boolean isImagesLinkPresent()
        {
            System.Console.WriteLine("isImagesLinkPresent()");
            return isElementPresent(imagesLinkLocator);
        }

        public String getImagesLinkText()
        {
            System.Console.WriteLine("getImagesLinkText()");
            return getTextFromLocator(imagesLinkLocator);
        }

        public Boolean isGmailLinkPresent()
        {
            System.Console.WriteLine("isGmailLinkPresent()");
            return isElementPresent(gmailLinkLocator);
        }

        public String getGmailLinkText()
        {
            System.Console.WriteLine("getGmailLinkText()");
            return getTextFromLocator(gmailLinkLocator);
        }

        public Boolean isApplicationsPresent()
        {
            System.Console.WriteLine("isApplicationsPresent()");
            return isElementPresent(appsLocator);
        }

        public Boolean isSignInButtonPresent()
        {
            System.Console.WriteLine("isSignInButtonPresent()");
            return isElementPresent(signInButtonLocator);
        }

        public String getSignInButtonText()
        {
            System.Console.WriteLine("getSignInButtonText()");
            return getTextFromLocator(signInButtonLocator);
        }

        private Boolean isElementPresent (IWebElement element)
        {
            System.Console.WriteLine("isElementPresent()");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,2));
            Boolean bIsPresent = element.Displayed;
            return bIsPresent;
        }

        public String getTextFromLocator(IWebElement element)
        {
            System.Console.WriteLine("getTextFromLocator");
            String sText = element.Text;
            return sText;
        }

        public String getValueFromLocator(IWebElement element)
        {
            String sValue = element.GetAttribute("value");
            return sValue;
        }

        public void checkUrl(String url)
        {
            System.Console.WriteLine("checkUrl( " + url + " )");
            String sCurrentUrl = driver.Url;
            Assert.True(sCurrentUrl.Contains(url) , "Expected to contain: " + url + ". Actual: " + sCurrentUrl);
        }

        public void enterSearchText(String text)
        {
            System.Console.WriteLine("enterSearchText ( " + text + " )");
            Assert.IsTrue(isSearchFieldPresent(), "Search field is NOT present");
            searchFieldLocator.Click();
            searchFieldLocator.Clear();
            searchFieldLocator.SendKeys(text);
            searchFieldLocator.SendKeys(Keys.Tab);
        }

        public void clickGoogleSearchButton()
        {
            System.Console.WriteLine("clickGoogleSearchButton");
            Assert.IsTrue(isGoogleSearchButtonPresent(), "Google Search button is NOT present");
            googleSearchButtonLocator.Click();
        }

        public List<IWebElement> getSearchResultsWebLocators()
        {
            System.Console.WriteLine("getSearchResultsWebLocators");
            List<IWebElement> elements = driver.FindElement(By.Id("search")).FindElements(By.ClassName("g")).ToList();
            return elements;
        }

        public IWebElement getFirstResultLocator()
        {
            System.Console.WriteLine("getFirstResultLocator");
            List<IWebElement> elements = getSearchResultsWebLocators();
            IWebElement element = elements[0].FindElement(By.XPath("//div[@class='rc']/div/a"));
            return element;
        }

        public String getLinkFromFirstResult()
        {
            System.Console.WriteLine("getLinkFromFirstResult");
            IWebElement element = getFirstResultLocator();
            String sURL = element.GetAttribute("href");
            return sURL;
        } 

        public GoogleSearchPage clickOnLinkInFirstResult()
        {
            System.Console.WriteLine("getLinkFromFirstResult");
            IWebElement element = getFirstResultLocator();
            element.Click();
            return this;
        }
    }
}
