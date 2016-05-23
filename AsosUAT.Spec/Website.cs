using System.Collections.Generic;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace AsosUAT.Spec
{
    internal class Website
    {
        private string _homeUrl = "http://www.asos.com/";
        private IWebDriver _driver = new FirefoxDriver();

        public Website()
        {
        }

        public List<string> GetJeans()
        {
            var listOfJeans = new List<string>();
            var items =_driver.FindElement(By.Id("items"));
            var jeans = items.FindElements(By.TagName("li"));
            foreach (var jean in jeans)
            {
                var jeanName = jean.FindElement(By.TagName("a")).Text;
                listOfJeans.Add(jeanName);
            }
            return listOfJeans;
        }

        public void ViewJeanCategory()
        {
            var action = new Actions(_driver);
            var menuElement = _driver.FindElement(By.XPath("/html/body/div[11]/div/header/div[4]/nav/ul/li[2]/a"));
            action.MoveToElement(menuElement).Perform();
            var jeansLink = _driver.FindElement(By.LinkText("Jeans"));
            jeansLink.Click();
        }

        public void GoToHomePage()
        {
                _driver.Navigate().GoToUrl(_homeUrl);
        }
    }
}