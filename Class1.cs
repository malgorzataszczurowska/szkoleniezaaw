using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;
using System.Linq;

namespace PageExample2
{
    public class PopExampleTest2 : IDisposable
    {
        private readonly IWebDriver _browser;
        private double seconds;

        public PopExampleTest2()
        {
            _browser = new ChromeDriver();
        }

        [Fact]
        public void Can_publish_new_comment()
        {
            _browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");
            var element = _browser.FindElement(By.CssSelector(".comments-link"));
            var noteUrl = element.GetAttribute("href");
            element.Click();

            
            var comment = _browser.FindElement(By.Id("comment"));
            comment.Click();
            comment.SendKeys("ksdfigfvdsfsdfsadanfjns");
            

            var author = _browser.FindElement(By.Id("author"));
            //author.Click();
            author.SendKeys("melily");

            WaitForClickable(_browser, By.Id("email"), 5);
            var emailaddress = _browser.FindElement(By.Id("email"));
            //emailaddress.Click();
            emailaddress.SendKeys("fake@fake.pl");

            MoveToElement(_browser, By.CssSelector("nav.navigation"));
            WaitForClickable(_browser, By.Id("submit"), 5);
            _browser.FindElement(By.Id("submit")).Click();

            Assert.True(_browser.FindElements(By.CssSelector(".comment-content")).Any());
        }

        private void WaitForClickable(IWebDriver browser, By by, int v)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private void MoveToElement(IWebDriver browser, By by)
        {
            var element = browser.FindElement(by);
            var actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }

            public void Dispose()
        {
            _browser.Quit();
        }

    }
}

