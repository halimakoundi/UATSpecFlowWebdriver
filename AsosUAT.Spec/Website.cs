using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace AsosUAT.Spec
{
    internal class Website
    {
        private readonly IWebDriver _driver = new FirefoxDriver();
        private readonly string _homeUrl = "http://www.asos.com/";

        public List<string> GetJeans()
        {
            var items = _driver.FindElement(By.Id("items"));
            var jeans = items.FindElements(By.TagName("li"));
            return jeans.Select(jean => jean.FindElement(By.TagName("a")).Text).ToList();
        }

        public void GoToGender(string gender)
        {
            var action = new Actions(_driver);
            var genderCategoryHover = _driver.FindElement(
                By.LinkText(gender.ToUpper()));

            action.MoveToElement(genderCategoryHover).Perform();
        }

        public void ViewJeanCategory()
        {
            var jeansLink = _driver.FindElement(By.LinkText("Jeans"));
            jeansLink.Click();
        }

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl(_homeUrl);
        }

        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}