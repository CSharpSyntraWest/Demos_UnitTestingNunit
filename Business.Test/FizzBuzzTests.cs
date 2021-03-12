using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingCore;

namespace Business.Test
{
    public class FizzBuzzTests
    {
        [Test]
        [TestCase("FizzBuzz", 0)]
        [TestCase("", 11)]
        [TestCase("Fizz", 3)]
        [TestCase("Fizz", 6)]
        [TestCase("Buzz", 5)]
        [TestCase("Buzz", 10)]
        [TestCase("FizzBuzz", 15)]
        [TestCase("FizzBuzz", 30)]
        //...
        public void TestFizzBuzz(string expected, int number)
        {
            Assert.AreEqual(expected, FizzBuzz.Ask(number));
        }
    }
}
