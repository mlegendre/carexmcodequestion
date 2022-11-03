using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.PagObjects;
using System;
using System.Linq;
using Xunit;

namespace SeleniumTest
{
    public class GoAppUITests
    {
        private ChromeDriver driver;
        private LandingPageObjects landingPageObjects;

        public GoAppUITests()
        {
            driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_content");
            landingPageObjects = new LandingPageObjects(driver);
        }

        [Fact]
        public void Verify3AvatarsOnPage()
        {
            // Assign

            // Act
            var allImages = landingPageObjects.AvatarImages.Count;

            // Assert
            Assert.True(allImages.Equals(3));
        }

        [Fact]
        public void VerifyStaticContentLinkChangesUrl()
        {
            // Assign

            // Act
            landingPageObjects.StaticContentLink.Click();
            var getCurrentUrl = landingPageObjects.GetUrl;

            // Assert
            Assert.Contains("?with_content=static", getCurrentUrl);
        }

        [Fact]
        public void VerifyAtLeastOneWordGreaterThan10Letters()
        {
            // Assign

            // Act
            var allTextElements = landingPageObjects.TextElements;

            // Assert
            foreach (var element in allTextElements)
            {
                foreach (var word in element.Text)
                {
                    if (word.ToString().Length > 10)
                    { 
                        Assert.True(word.ToString().Length > 10);
                    }
                }
            }
        }
    }
}