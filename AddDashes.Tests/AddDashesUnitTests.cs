using System;
using Xunit;

namespace AddDashes.Tests
{
    public class AddDashesUnitTests
    {
        [Fact]
        public void WhenPassGood10DigitPhoneNumber_ThenReturnPhoneNumberWithDashes()
        {
            // Assign

            // Act
            var sut = AddDashesToPhone.AddDashes("8011234567");
            
            // Assert
            Assert.Equal("801-123-4567", sut);
        }

        [Theory]
        [InlineData("54801123456789")]
        [InlineData("123")]
        public void WhenPassMoreThan10AndLessThan10DigitPhoneNumber_ThenReturnErrorMessage(string phoneNumber) 
        {
            // Assign

            // Act
            // Assert
            var exception = Assert.Throws<ArgumentException>(() => AddDashesToPhone.AddDashes(phoneNumber));
            Assert.Equal("Must be at least 10 digits",exception.Message);
        }

        [Theory]
        [InlineData("asdf011234")]
        [InlineData("!@#$^&asdf")]
        public void WhenPassingAlphaNumericAndSpecialChars_ThenReturnErrorMessage(string phoneNumber)
        {
            // Assign

            // Act
            // Assert
            var exception = Assert.Throws<ArgumentException>(() => AddDashesToPhone.AddDashes(""));
            Assert.Equal("Phone number can only be digits", exception.Message);
        }
    }
}