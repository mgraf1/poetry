using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poetry.Uploader.PoetryGeneration;

namespace PoetryTests.PoetryGeneration
{
    [TestClass]
    public class MarkovChainTests
    {
        private MarkovChain markovChainUnderTest;

        [TestInitialize]
        public void MyTestInitialize()
        {
            markovChainUnderTest = new MarkovChain();
        }

        [TestMethod]
        public void GramSize()
        {
            markovChainUnderTest.GramSize = 4;

            Assert.AreEqual(4, markovChainUnderTest.GramSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "MarkovChain accepts grams of size 2, GramSize: 3")]
        public void AddLink_Size2_WrongSizeGram()
        {
            markovChainUnderTest.GramSize = 2;
            var gramToAdd = new NGram("a", "b", "c");
            var nextGramToAdd = new NGram("b", "c", "d");

            markovChainUnderTest.AddLink(gramToAdd, nextGramToAdd);
        }

        [TestMethod]
        public void AddLink_Size3_RightSizeGram()
        {
            markovChainUnderTest.GramSize = 3;
            var gramToAdd = new NGram("a", "b", "c");
            var nextGramToAdd = new NGram("b", "c", "d");

            markovChainUnderTest.AddLink(gramToAdd, nextGramToAdd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "MarkovChain does not contain gram (a,b)")]
        public void GetNextGram_EmptyChain()
        {
            markovChainUnderTest.GramSize = 2;
            var startingGram = new NGram("a", "b");


            markovChainUnderTest.GetNextGram(startingGram);
        }

        [TestMethod]
        public void GetNextGram_Size2()
        {
            markovChainUnderTest.GramSize = 2;
            var startingGram = new NGram("a", "b");
            var nextGram = new NGram("b", "c");
            markovChainUnderTest.AddLink(startingGram, nextGram);

            NGram followingGram = markovChainUnderTest.GetNextGram(startingGram);

            Assert.AreEqual(followingGram, nextGram);
        }

        [TestMethod]
        public void GetNextGram_Size3()
        {
            markovChainUnderTest.GramSize = 3;
            var startingGram = new NGram("a", "b", "c");
            var nextGram = new NGram("b", "c", "d");
            markovChainUnderTest.AddLink(startingGram, nextGram);

            NGram followingGram = markovChainUnderTest.GetNextGram(startingGram);

            Assert.AreEqual(followingGram, nextGram);
        }

        [TestMethod]
        public void GetBeginning_Size2()
        {
            markovChainUnderTest.GramSize = 2;
            var startingGram = new NGram("a", "b");
            markovChainUnderTest.AddBeginning(startingGram);

            var beginningGram = markovChainUnderTest.GetBeginning();

            Assert.AreEqual(startingGram, beginningGram);
        }

        [TestMethod]
        public void GetBeginning_Size3()
        {
            markovChainUnderTest.GramSize = 3;
            var startingGram = new NGram("a", "b", "c");
            markovChainUnderTest.AddBeginning(startingGram);

            var beginningGram = markovChainUnderTest.GetBeginning();

            Assert.AreEqual(startingGram, beginningGram);
        }

        [TestMethod]
        public void GetEnding_Size2()
        {
            markovChainUnderTest.GramSize = 2;
            var startingGram = new NGram("a", "b");
            markovChainUnderTest.AddEnding(startingGram);

            var endingGram = markovChainUnderTest.GetEnding();

            Assert.AreEqual(startingGram, endingGram);
        }

        [TestMethod]
        public void GetEnding_Size3()
        {
            markovChainUnderTest.GramSize = 3;
            var startingGram = new NGram("a", "b", "c");
            markovChainUnderTest.AddEnding(startingGram);

            var endingGram = markovChainUnderTest.GetEnding();

            Assert.AreEqual(startingGram, endingGram);
        }

        [TestMethod]
        public void AverageLineLength_Size2_1Line()
        {
            markovChainUnderTest.GramSize = 2;
        }
    }
}
