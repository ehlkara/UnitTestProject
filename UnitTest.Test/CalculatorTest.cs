using Moq;
using System;
using System.Collections.Generic;
using UnitTest.App;
using Xunit;

namespace UnitTest.Test
{
    public class CalculatorTest
    {
        private readonly Calculator calculator;
        private readonly Mock<ICalculatorService> mymock;
        public CalculatorTest()
        {
            mymock = new Mock<ICalculatorService>();
            this.calculator = new Calculator(mymock.Object);
        }

        [Fact]
        public void AddTest()
        {
            ////Arrange

            //int a = 5;
            //int b = 20;

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

            //Assert.Empty(new List<string>() { "ehlkara" });
            //Assert.NotEmpty(new List<string>() { "ehlkara" });

            //Assert.InRange(10, 2, 20);

            //Assert.NotInRange(10, 2, 20);

            //Assert.Single<int>(new List<int>() { 1, 2, 3 });
            //Assert.Single(new List<string>() { "ehlkara" });

            //Assert.IsType<string>("ehlkara");
            //Assert.IsNotType<int>("ehlkara");

            //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());

            //Assert.IsAssignableFrom<Object>(2);

            //string variable = null;
            //Assert.Null(variable);
            //Assert.NotNull(variable);

            //Assert.Equal<int>(2, 2);
            //Assert.NotEqual<int>(2, 2);
        }

        [Theory]
        [InlineData(2,5,7)]
        [InlineData(2, 10, 12)]
        public void Add_simpleValues_ReturnValue(int a,int b, int expectedTotal)
        {

            mymock.Setup(x => x.add(a, b)).Returns(expectedTotal);

            //Act
            var actualTotal = calculator.add(a, b);

            //Assert
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        public void Add_zeroValues_ReturnZeroValue(int a, int b, int expectedTotal)
        {
            //Act
            var actualTotal = calculator.add(a, b);

            //Assert
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void Multip_simpleValues_ReturnsMultipleValue(int a, int b, int expectedValue)
        {
            mymock.Setup(x => x.multip(a, b)).Returns(expectedValue);

            Assert.Equal(15, calculator.multip(a, b));
        }
    }
}