using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDExercises;

namespace TDDExercises.Tests
{
    [TestClass]
    public class WordsToNumbersTest
    {
        [TestMethod]
        public void WordsToNums()
        {
            WordsToNumbers newObject = new WordsToNumbers();
            Assert.AreEqual(19, newObject.WordsConverter("nineteen"));

            Assert.AreEqual(4, newObject.WordsConverter("four"));

            Assert.AreEqual(97, newObject.WordsConverter("ninety seven"));

            Assert.AreEqual(454, newObject.WordsConverter("four hundred and fifty-four"));

            Assert.AreEqual(435000, newObject.WordsConverter("four hundred and thirty-five thousand"));

            Assert.AreEqual(435528, newObject.WordsConverter("four hundred and thirty-five thousand five hundred twenty-eight"));

            Assert.AreEqual(270000, newObject.WordsConverter("two hundred seventy thousand"));

            Assert.AreEqual(27000, newObject.WordsConverter("twenty-seven thousand"));

            Assert.AreEqual(1555, newObject.WordsConverter("one thousand five hundred and fifty-five"));

            Assert.AreEqual(888888, newObject.WordsConverter("eight hundred eighty-eight thousand eight hundred eighty- eight"));
        }
    }
}
