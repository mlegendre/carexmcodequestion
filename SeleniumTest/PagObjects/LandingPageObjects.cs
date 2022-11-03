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

        public List<IWebElement> AvatarImages => _driver.FindElements(By.CssSelector("")).ToList();
    }
}
