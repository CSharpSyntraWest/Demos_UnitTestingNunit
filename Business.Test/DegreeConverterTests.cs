using NUnit.Framework;
using UnitTestingCore;

namespace Business.Test
{
    [TestFixture]
    public class DegreeConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToFahrenheit_ZeroCelsius_Returns32()
        {
            var converter = new DegreeConverter();
            double result = converter.ToFahrenheit(0);
            Assert.That(result, Is.EqualTo(32));
        }

        [Test]
        public void ToCelsius_1Fahrenheit_Returns0()
        {
            var converter = new DegreeConverter();
            double result = converter.ToCelsius(1);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}