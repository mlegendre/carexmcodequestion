using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTest.PagObjects
{
    public class LandingPageObjects
    {
        private WebDriver _driver;
        public LandingPageObjects(WebDriver driver)
        {
            _driver = driver;
        }

        public List<IWebElement> AvatarImages => _driver.FindElements(By.CssSelector("#content img")).ToList();

        public List<IWebElement> TextElements => _driver.FindElements(By.CssSelector("#content > div.row > div.large-10")).ToList();

        public IWebElement StaticContentLink => _driver.FindElement(By.CssSelector("div.example a"));

        public IWebElement PageHeader => _driver.FindElement(By.CssSelector("h3"));

        public string GetUrl => _driver.Url;
    }
}
