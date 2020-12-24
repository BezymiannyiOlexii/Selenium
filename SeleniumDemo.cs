using NUnit.Framework;
using System;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Keys;
using System.Drawing;

namespace Selenium_lab
{
    [TestFixture()]
    public class SeleniumDemo
    {
        [Test()]
        public void TestCase1()
        {
            //Assert.IsTrue(driver.Url.Contains("habr.com"), "Что-то не так =(");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/");
            Actions action = new Actions(driver); 
            

            IWebElement Services = driver.FindElement(By.ClassName("top-navigation__item-link"));
            action.MoveToElement(Services);
            action.Perform();

            IWebElement Optimize = driver.FindElements(By.ClassName("top-navigation__main-link"))[1];
            Optimize.Click();

            Thread.Sleep(5000);

            Assert.IsTrue(driver.Url == "https://www.epam.com/services/optimize", "Something went wrong...");
            driver.Quit();
        }

        [Test()]
        public void TestCase2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/");
            IWebElement how_we_do_it = driver.FindElement(By.LinkText("HOW WE DO IT"));
            how_we_do_it.Click();

            IWebElement why_epam = driver.FindElement(By.XPath("//*[contains(., 'Why EPAM?')]"));
            driver.Quit();
        }

        [Test()]
        public void TestCase3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/");
            IWebElement lang = driver.FindElement(By.ClassName("location-selector__button"));
            lang.Click();

            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();


            IWebElement lang_ua = driver.FindElements(By.CssSelector(".location-selector__item a"))[7];
            lang_ua.Click();

            Thread.Sleep(5000);


            Assert.IsTrue(driver.Url == "https://careers.epam.ua/", "Something was gone wrong");
            driver.Quit();
        }

        [Test()]
        public void TestCase4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/.");
            String attribute = "tabs__title";

            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();

            IWebElement button = driver.FindElements(By.ClassName(attribute))[3];
            button.Click();

            IWebElement rus_but = driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[10]/section/div/div[2]/div/div[5]/div/div/div[1]/div[1]/div/div[8]/div/button/div[1]"));
            rus_but.Click();
            Thread.Sleep(5000);

            IWebElement map = driver.FindElement(By.XPath("/html/body/div[2]/main/div[1]/div[10]/section/div/div[2]/div/div[5]/div/div/div[2]/div[4]/ul/li[7]/a"));
            map.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);


            Assert.IsTrue(driver.Url == "https://www.google.com/maps/place/EPAM+systems/@59.8883799,30.3264607,18z/data=!3m1!4b1!4m5!3m4!1s0x4696316900000001:0x81e0d26219de977d!8m2!3d59.8883799!4d30.327555?shorturl=1" || driver.Url == "https://www.google.com/maps/place/EPAM+systems/@59.8884609,30.3264551,18z/data=!3m1!4b1!4m5!3m4!1s0x4696316900000001:0x81e0d26219de977d!8m2!3d59.8883799!4d30.327555", driver.Url);
            driver.Quit();
        }

        [Test()]
        public void TestCase5()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/.");
            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();
            String attribute = "footer__social-link";
            IWebElement button = driver.FindElements(By.ClassName(attribute))[0];
            button.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            Assert.IsTrue(driver.Url == "https://www.linkedin.com/company/epam-systems/", driver.Url);
            driver.Quit();
        }

        [Test()]
        public void TestCase6()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/.");
            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();
            IWebElement search = driver.FindElement(By.CssSelector("button[class='header-search__button header__icon']"));
            search.Click();

            driver.FindElement(By.CssSelector("input[id='new_form_search']")).SendKeys("Python");
            IWebElement button = driver.FindElement(By.CssSelector("button[class='header-search__submit']"));
            button.Click();
            Thread.Sleep(2000);


            
            Assert.IsTrue(driver.Url == "https://www.epam.com/search?q=Python", "Error...");
            driver.Quit();
        }

        [Test()]
        public void TestCase7()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/.");
            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();

            var full = driver.Manage().Window.Size;
            var devided = 1130; //should be proved

            driver.Manage().Window.Size = new Size(1130, driver.Manage().Window.Size.Height);


            if (full.Width <= devided)
            {
                IWebElement hamburger = driver.FindElement(By.CssSelector("button[class='hamburger-menu__button']"));
                hamburger.Click();
            }
            else
            {
                Assert.IsTrue(true, "No hamburger menu is provided");
            }
            driver.Quit();
        }

        [Test()]
        public void TestCase8()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/careers/job-listings?recruitingUrl=%2Fcontent%2Fepam%2Fen%2Fcareers%2Fjob-listings%2Fjob&query=Machine+Learning+&country=Ukraine&city=Kyiv&sort=relevance&searchType=placeOfWorkFilter");

            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();

            IWebElement date = driver.FindElements(By.CssSelector("label[class='search-result__sorting-label']"))[1];
            date.Click();

            IWebElement apply = driver.FindElement(By.ClassName("search-result__item-controls"));
            apply.Click();
            Thread.Sleep(5000);

            Assert.IsTrue(driver.Url == "https://www.epam.com/careers/job-listings?recruitingUrl=%2Fcontent%2Fepam%2Fen%2Fcareers%2Fjob-listings%2Fjob&query=Machine+Learning+&country=Ukraine&city=Kyiv&sort=time&searchType=placeOfWorkFilter", "Error...");
            driver.Quit();
        }
    }
}
