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
        public IWebDriver Enter()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/");
            return (driver);

        }

        [Test()]
        public void RedirectToOptimize()
        {

            IWebDriver driver = Enter();
            Actions action = new Actions(driver);

            IWebElement Services = driver.FindElement(By.ClassName("top-navigation__item-link"));
            action.MoveToElement(Services);
            action.Perform();

            IWebElement Optimize = driver.FindElements(By.ClassName("top-navigation__main-link"))[1];
            Optimize.Click();

            Thread.Sleep(3000);

            Assert.IsTrue(driver.Url == "https://www.epam.com/services/optimize", "Something went wrong...");
            driver.Quit();
        }

        [Test()]
        public void FindingInfoAboutEpam()
        {
            IWebDriver driver = Enter();
            IWebElement how_we_do_it = driver.FindElement(By.LinkText("HOW WE DO IT"));
            how_we_do_it.Click();

            IWebElement why_epam = driver.FindElement(By.XPath("//*[contains(., 'Why EPAM?')]"));
            driver.Quit();
        }

        [Test()]
        public void ChangingLanguage()
        {
            IWebDriver driver = Enter();
            IWebElement lang = driver.FindElement(By.ClassName("location-selector__button"));
            lang.Click();

            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();

            Thread.Sleep(2000);

            IWebElement lang_ua = driver.FindElements(By.CssSelector(".location-selector__item a"))[7];
            lang_ua.Click();


            Thread.Sleep(3000);

            Assert.IsTrue(driver.Url == "https://careers.epam.ua/", "Something was gone wrong");
            driver.Quit();
        }

        [Test()]
        public void FindOnMaps()
        {
            IWebDriver driver = Enter();
            String attribute = "tabs__title";

            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();

            IWebElement button = driver.FindElements(By.ClassName(attribute))[3];
            button.Click();

            IWebElement rus_but = driver.FindElements(By.XPath("//*[ text() = \"Russia\" ]"))[1];
            rus_but.Click();
            Thread.Sleep(5000);

            IWebElement map = driver.FindElements(By.CssSelector("[data-country=\"russia\"] .locations-viewer__office-map"))[6];
            map.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);


            Assert.IsTrue(driver.Title == "EPAM systems – Google Карты", driver.Title);
            driver.Quit();
        }

        [Test()]
        public void ConnectToLinkedin()
        {
            IWebDriver driver = Enter();
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
        public void SearchByJobVacancy()
        {
            IWebDriver driver = Enter();
            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();
            IWebElement search = driver.FindElement(By.CssSelector("button[class='header-search__button header__icon']"));
            search.Click();

            driver.FindElement(By.CssSelector("input[id='new_form_search']")).SendKeys("Java");
            IWebElement button = driver.FindElement(By.CssSelector("button[class='header-search__submit']"));
            button.Click();
            Thread.Sleep(2000);


            
            Assert.IsTrue(driver.Url == "https://www.epam.com/search?q=Java", "Error...");
            driver.Quit();
        }

        [Test()]
        public void ScreenResizing()
        {
            IWebDriver driver = Enter();
            IWebElement cookies = driver.FindElement(By.ClassName("button__content"));
            cookies.Click();


            var full = driver.Manage().Window.Size;

            try
            {
                IWebElement hamburger = driver.FindElement(By.CssSelector("button[class='hamburger-menu__button']"));
                hamburger.Click();
            }
            catch
            {
                Assert.IsTrue(true, "No menu is provided");
                driver.Manage().Window.Size = new Size(driver.Manage().Window.Size.Width / 2, driver.Manage().Window.Size.Height);
            }
            finally
            {
                IWebElement hamburger = driver.FindElement(By.CssSelector("button[class='hamburger-menu__button']"));
                hamburger.Click();
            }

            driver.Quit();
        }

        [Test()]
        public void FindingNewJob()
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

            Thread.Sleep(3000);

            IWebElement job = driver.FindElements(By.ClassName("search-result__item-apply"))[0];
            job.Click();

            Thread.Sleep(2000);
            
            IWebElement more = driver.FindElement(By.CssSelector("span[class='button__content']"));
            more.Click();
            Thread.Sleep(2000);

            Assert.IsTrue(driver.Url == "https://careers.epam.ua/", driver.Url);
            driver.Quit();


        }
    }
}
