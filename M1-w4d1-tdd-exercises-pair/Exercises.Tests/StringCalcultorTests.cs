using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDExercises;

namespace TDDExercises.Tests
{
    [TestClass]
    public class StringCalcultorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator testObject = new StringCalculator();

            Assert.AreEqual(0, testObject.Add(""));

            Assert.AreEqual(1, testObject.Add("1"));

            Assert.AreEqual(3, testObject.Add("1,2"));

            Assert.AreEqual(13, testObject.Add("1,5,7"));

            Assert.AreEqual(25, testObject.Add("1,10,11,3"));

            Assert.AreEqual(6, testObject.Add("1\n2,3"));

            Assert.AreEqual(14, testObject.Add("3\n5\n2,4"));

        }
    }
}
