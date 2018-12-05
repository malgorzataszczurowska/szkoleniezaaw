using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageExample2
{
        internal class NewNotePage
        {
            private IWebDriver _browser;

            public NewNotePage(IWebDriver browser)
            {
                _browser = browser;
                PageFactory.InitElements(_browser, this);
            }

        [FindsBy(How = How.CssSelector, Using = ".comments-link")]
        public IWebElement CommentLink { get; set; }

        [FindsBy(How = How.Id, Using = "comment")]
        public IWebElement Comment { get; set; }

        [FindsBy(How = How.Id, Using = "author")]
        public IWebElement Author { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "submit")]
        public IWebElement Submit { get; set; }

        internal Uri Create(string title, string content)
        {
            CommentLink.Click();
            return new Uri(CommentLink.GetAttribute("href"));
            Comment.SendKeys("lsdkkhfjsdhfudshf");
            Author.SendKeys("melilia");
            Email.SendKeys("lala@pola.pl");

            MoveToElement(_browser, By.CssSelector("nav.navigation"));

            Submit.Click();
        }

        private void MoveToElement(IWebDriver browser, By by)
        {
            var element = browser.FindElement(by);
            var actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }

        private void WaitForClickable(IWebDriver browser, By by, int v)
        {
            double seconds = 0;
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }

}
