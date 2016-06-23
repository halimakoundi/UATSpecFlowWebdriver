using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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

        public string GetItemName()
        {
            return _driver.FindElement(By.ClassName("product_title")).Text;
        }

        public void AddItemToBag()
        {
            var size = _driver
                .FindElement(By.ClassName("size-guide"))
                .FindElement(By.TagName("select"));

            var sizeDropdown = new SelectElement(size);

            sizeDropdown.SelectByIndex(1);

            _driver.FindElement(By.ClassName("add-to-bag")).Click();
        }

        public IEnumerable<string> GetBagContents()
        {
            _driver.FindElement(By.ClassName("view-bag")).Click();

            try
            {
                var items = _driver.FindElements(By.ClassName("name"));

                return items
                    .Select(i => i.FindElement(By.TagName("a")).Text);
            }
            catch (Exception)
            {
                return Enumerable.Empty<string>();
            }
        }

        public void ViewFirstItem()
        {
            var firstItem = _driver
                .FindElement(By.Id("items"))
                .FindElements(By.TagName("li"))
                .First();

            firstItem.Click();
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