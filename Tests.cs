using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NumToWords {
    [TestFixture]
    public class NumToWords_Test
    {
        private NumberConversion _conversionService;

        [SetUp]
        public void SetUp()
        {
            _conversionService = new NumberConversion();
        }

        [Test]
        public void Test_NumToWords()
        {
            var result = _conversionService.NumToWords(1234567);

            Assert.AreEqual("One Million Two Hundred and Thirty Four Thousand and Five Hundred and Sixty Seven ", result);
        }

        [Test]
        public void Test_Zero()
        {
            var result = _conversionService.NumToWords(0);
            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void Test_Negative()
        {
            var result = _conversionService.NumToWords(-1343);
            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void Test_SingleDigit()
        {
            var result = _conversionService.NumToWords(2);
            Assert.AreEqual("Two ", result);
        }

        [Test]
        public void Test_Billion()
        {
            var result = _conversionService.NumToWords(2022345671);
            Assert.AreEqual("Two Billion Twenty Two Million Three Hundred and Forty Five Thousand and Six Hundred and Seventy One ", result);
        }

        [Test]
        public void Test_WordsToNum()
        {
            var result = _conversionService.WordsToNum("Five Thousand and Twelve");
            Assert.AreEqual(5012, result);
        }

        [Test]
        public void Test_IncorrectWords()
        {
            Assert.Throws<ArgumentException>(() => _conversionService.WordsToNum("Five Thousand and Something went wrong"));
        }

    }
}