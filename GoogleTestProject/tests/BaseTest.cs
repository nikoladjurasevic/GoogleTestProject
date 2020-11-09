using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleTestProject.tests
{
    public class BaseTest
    {
        String googleHomeUrl = "https://www.google.com";

        public IWebDriver openChromeDriver()
        {
            System.Console.WriteLine("Seting up Chrome Driver");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--disable-popup-blocking");
            options.AddArguments("--incognito");
            System.Console.WriteLine("openChromeDriver");
            IWebDriver driver = new ChromeDriver(options);
            driver.Url = googleHomeUrl;
            return driver;
        }



    }
}
