using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.PagObjects;
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
        public void VerifyAtLeastOneWordGreaterThan10Letters()
        {
            // Assign

            // Act
            var allImages = driver.FindElements(By.CssSelector("#content img"));

            // Assert
            Assert.True(allImages.Count.Equals(3));
        }
    }
}