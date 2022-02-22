using System.Collections.Generic;
using UnitTest.App;
using Xunit;

namespace UnitTest.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void AddTest()
        {
            ////Arrange

            //int a = 5;
            //int b = 20;
            //var calculator = new Calculator();

            ////Act
            //var total = calculator.add(a, b);

            ////Assert
            //Assert.Equal<int>(25, total);

            //Assert.Contains("Ehlullah", "Ehlullah Karakurt");
            //Assert.DoesNotContain("ehlkara", "Ehlullah Karakurt");

            //var names = new List<string>() { "Ehlullah", "ehlkara", "Mustafa" };

            //Assert.Contains(names, x => x == "Ömer");

            //Assert.True(5 > 2);

            //Assert.False(5 < 2);

            //Assert.True("".GetType() == typeof(string));

            //var regEx = "^dog";

            //Assert.Matches(regEx, "ehlkara dog");
            //Assert.DoesNotMatch(regEx, "ehlkara dog");

            //Assert.StartsWith("Unit", "Unit testing");
            //Assert.EndsWith("testing", "Unit testing");

            Assert.Empty(new List<string>() { "ehlkara" });
            Assert.NotEmpty(new List<string>() { "ehlkara" });

        }
    }
}