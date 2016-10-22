using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Poetry.Uploader.PoetryGeneration;

namespace PoetryTests.PoetryGeneration
{
    [TestClass]
    public class PoetryParserTests
    {
        private PoetryParser parserUnderTest;

        [TestInitialize]
        public void MyTestInitialize()
        {
            parserUnderTest = new PoetryParser();
        }


        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ParsePoemFile_InvalidPath()
        {
            parserUnderTest.ParsePoemFile("Invalidfile.txt", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParsePoemFile_GramSize1()
        {
            parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 1);
        }

        [TestMethod]
        public void ParsePoemFile_GramSize2_Simple()
        {
            MarkovChain chain = parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 2);
            NGram firstGram = new NGram("this", "file");

            Assert.AreEqual("file is", chain.GetNextGram(firstGram).ConcatenatedValue);
        }

        [TestMethod]
        public void ParsePoemFile_GramSize3_Simple()
        {
            MarkovChain chain = parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 3);
            NGram firstGram = new NGram("this", "file", "is");

            Assert.AreEqual("file is a", chain.GetNextGram(firstGram).ConcatenatedValue);
        }

        [TestMethod]
        public void ParsePoemFile_GramSize2_GetBeginning()
        {
            MarkovChain chain = parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 2);

            Assert.AreEqual("this file", chain.GetBeginning().ConcatenatedValue);
        }

        [TestMethod]
        public void ParsePoemFile_GramSize3_GetBeginning()
        {
            MarkovChain chain = parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 3);

            Assert.AreEqual("this file is", chain.GetBeginning().ConcatenatedValue);
        }

        [TestMethod]
        public void ParsePoemFile_GramSize2_GetEnding()
        {
            MarkovChain chain = parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 2);

            Assert.AreEqual("a test", chain.GetEnding().ConcatenatedValue);
        }

        [TestMethod]
        public void ParsePoemFile_GramSize3_GetEnding()
        {
            MarkovChain chain = parserUnderTest.ParsePoemFile("PoetryGeneration/TestFiles/TestFile1.txt", 3);

            Assert.AreEqual("is a test", chain.GetEnding().ConcatenatedValue);
        }
    }
}
