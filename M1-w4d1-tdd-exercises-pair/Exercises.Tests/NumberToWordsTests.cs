using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDExercises.Tests
{
    [TestClass]
    public class NumberToWordsTests
    {
        [TestMethod]
        public void Words()
        {
            NumbersToWords testObject = new NumbersToWords();
            Assert.AreEqual("fourteen", testObject.NumberConverter(14));

            Assert.AreEqual("thirty three", testObject.NumberConverter(33));

            Assert.AreEqual("two hundred and fifty three", testObject.NumberConverter(253));

            Assert.AreEqual("four hundred thousand three hundred and forty five", testObject.NumberConverter(400345));

            Assert.AreEqual("one hundred thousand", testObject.NumberConverter(100000));

            Assert.AreEqual("twelve thousand", testObject.NumberConverter(12000));

        }
    }
}
