using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.PoetryGeneration;

namespace PoetryTests.PoetryGeneration
{
    [TestClass]
    public class NGramTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            string[] args = new string[] { "a", "b" };
            var gramUnderTest = new NGram(args);

            Assert.AreEqual("(a,b)", gramUnderTest.ToString());
        }

        [TestMethod]
        public void CreateNGram_Size2()
        {
            string[] args = new string[] { "a", "b" };
            var gramUnderTest = new NGram(args);

            Assert.AreEqual(2, gramUnderTest.Size);
        }

        [TestMethod]
        public void CreateNGram_Size3()
        {
            string[] args = new string[] { "a", "b", "c" };
            var gramUnderTest = new NGram(args);

            Assert.AreEqual(3, gramUnderTest.Size);
        }

        [TestMethod]
        public void GetConcatenatedValue_Size1()
        {
            string[] args = new string[] { "a" };
            var gramUnderTest = new NGram(args);

            string result = gramUnderTest.ConcatenatedValue;

            Assert.AreEqual("a", result);
        }

        [TestMethod]
        public void GetConcatenatedValue_Size2()
        {
            string[] args = new string[] { "a", "b" };
            var gramUnderTest = new NGram(args);

            string result = gramUnderTest.ConcatenatedValue;

            Assert.AreEqual("a b", result);
        }

        [TestMethod]
        public void GetConcatenatedValue_Size3()
        {
            string[] args = new string[] { "a", "b", "c" };
            var gramUnderTest = new NGram(args);

            string result = gramUnderTest.ConcatenatedValue;

            Assert.AreEqual("a b c", result);
        }

        [TestMethod]
        public void Equals_Size2_Same()
        {
            string[] args = new string[] { "a", "b" };
            var gramUnderTest = new NGram(args);

            string[] args2 = new string[] { "a", "b"};
            var otherGram = new NGram(args2);

            Assert.AreEqual(gramUnderTest, otherGram);
        }

        [TestMethod]
        public void Equals_Size3_Same()
        {
            string[] args = new string[] { "a", "b", "c" };
            var gramUnderTest = new NGram(args);

            string[] args2 = new string[] { "a", "b", "c" };
            var otherGram = new NGram(args2);

            Assert.AreEqual(gramUnderTest, otherGram);
        }

        [TestMethod]
        public void Equals_Size2_NotSame()
        {
            string[] args = new string[] { "a", "b" };
            var gramUnderTest = new NGram(args);

            string[] args2 = new string[] { "b", "a" };
            var otherGram = new NGram(args2);

            Assert.AreNotEqual(gramUnderTest, otherGram);
        }

        [TestMethod]
        public void Equals_Size2_NotSame2()
        {
            string[] args = new string[] { "a", "b" };
            var gramUnderTest = new NGram(args);

            string[] args2 = new string[] { "a", "b", "c" };
            var otherGram = new NGram(args2);

            Assert.AreNotEqual(gramUnderTest, otherGram);
        }
    }
}
