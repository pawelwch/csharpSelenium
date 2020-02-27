using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SzkolenieCsharpSelenium
{
    public class WebTest
    {
        ChromeDriver driver;

        [Test]
        public void SearchGoogle()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Look4App");
            Thread.Sleep(1000);
            driver.FindElement(By.Name("btnK")).Click();
            Assert.That(driver.Title.Contains("Look4App"));
            driver.Quit();
        }

        [Test]
        public void CheckLook4AppChannelDescription()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.youtube.pl");
            driver.FindElement(By.Id("search")).SendKeys("look4app");
            driver.FindElement(By.Id("search-icon-legacy")).Click();
            String channelDescription = driver.FindElement(By.Id("description")).Text;
            StringAssert.Contains(channelDescription, "We do cutting-edge blockchain and web projects. We're in Top 5 Blockchain Companies according to Clutch.io.");
            driver.Quit();

        }
    }
}
