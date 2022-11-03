using Xunit;

namespace AddDashes
{
    public class AddDashesToPhone
    {
        public static void Main()
        {
            Console.WriteLine(AddDashes("8011234567"));
        }

        public static string AddDashes(string phoneNumber)
        {
            if (!phoneNumber.Length.Equals(10))
            {
                throw new ArgumentException("Must be at least 10 digits");
            }

            var areaCode = phoneNumber.Substring(0, 3);
            var firstThreeDigitsAfterAreaCode = phoneNumber.Substring(areaCode.Length, 3);
            var lastFourDigits = phoneNumber.Substring(areaCode.Length + firstThreeDigitsAfterAreaCode.Length, 4);

            return $"{areaCode}-{firstThreeDigitsAfterAreaCode}-{lastFourDigits}";
        }
    }
}