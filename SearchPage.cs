using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation
{
    public class SearchPage
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(@"C:\Users\Barahona\source\repos\TestAutomation\packages\Selenium.WebDriver.ChromeDriver.77.0.3865.4000\driver\win32",options,new TimeSpan(0,2,0));
            driver.Url = "https://giphy.com";
        }

        [Test]
        public void CheckShortLinkIsGenerated()
        {
            
            IWebElement searchElement = driver.FindElement(By.XPath("//input[@class='Input-sc-w75cdz fHIYrP']"));
            searchElement.SendKeys("bottle");
            IWebElement imageButton = driver.FindElement(By.XPath("//img[contains(@src,'search-icon.svg')]"));
            imageButton.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement imageResult =  wait.Until(drv => drv.FindElement(By.XPath("(//div[@class='_gifWrapper_15ggs_13']//img)[1]")));
            imageResult.Click();

            IWebElement copyLink = driver.FindElement(By.XPath("//span[text()='Copy link']"));
            copyLink.Click();

            IWebElement shortURL = driver.FindElement(By.XPath("(//input[@spellcheck='false'])[1]"));
            Assert.IsTrue(shortURL.Text != string.Empty);
        }

    }
}
