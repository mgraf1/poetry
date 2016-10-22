using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.PoetryGeneration
{
    /// <summary>
    /// Reads files containing poetry and constructs the MarkovChain data structure.
    /// </summary>
    public class PoetryParser : IPoetryParser
    {
        /// <summary>
        /// Given a path to a file and a gram size, constructs a MarkovChain with grams of the given size.
        /// </summary>
        /// <returns></returns>
        public MarkovChain ParsePoemFile(string filePath, int gramSize)
        {
            if (gramSize <= 1)
            {
                throw new ArgumentException("Gram size must be larger than 1");
            }

            string[] poemLines = File.ReadAllLines(filePath);

            var chainToReturn = new MarkovChain { GramSize = gramSize };

            foreach (string line in poemLines)
            {
                string sanitizedLine = new string(line.Where(c => !char.IsPunctuation(c))
                    .ToArray())
                    .ToLower();
                string[] splitLine = sanitizedLine.Split();

                if (splitLine.Length >= gramSize)
                {
                    string[] firstGramWords = GetLineBeginning(splitLine, gramSize);
                    string[] lastGramWords = GetLineEnding(splitLine, gramSize);

                    chainToReturn.AddBeginning(new NGram(firstGramWords));
                    chainToReturn.AddEnding(new NGram(lastGramWords));

                    if (splitLine.Length > gramSize)
                    {
                        string[] nextGramWords = GetSecondGramInLine(splitLine, gramSize);

                        NGram gram = new NGram(firstGramWords);
                        NGram nextGram = new NGram(nextGramWords);
                        chainToReturn.AddLink(gram, nextGram);

                        for (int lineIndex = gramSize + 1; lineIndex < splitLine.Length; lineIndex++)
                        {                     
                            nextGramWords.CopyTo(firstGramWords, 0);

                            for (int k = 0; k < gramSize - 1; k++)
                            {
                                nextGramWords[k] = nextGramWords[k + 1];
                            }
                            nextGramWords[gramSize - 1] = splitLine[lineIndex];

                            gram = new NGram(firstGramWords);
                            nextGram = new NGram(nextGramWords);
                            chainToReturn.AddLink(gram, nextGram);
                        }
                    }
                }    
            }

            return chainToReturn;
        }

        // Helper to grab the first gram in a line.
        private string[] GetLineBeginning(string[] splitLine, int gramSize)
        {
            string[] gramWords = new string[gramSize];
            for (int i = 0; i < gramSize; i++)
            {
                gramWords[i] = splitLine[i];
            }

            return gramWords;
        }

        // Helper to grab the second gram in a line.
        private string[] GetSecondGramInLine(string[] splitLine, int gramSize)
        {
            string[] gramWords = new string[gramSize];
            for (int i = 0; i < gramSize; i++)
            {
                gramWords[i] = splitLine[i + 1];
            }

            return gramWords;
        }

        // Helper to grab the last gram in a line.
        private string[] GetLineEnding(string[] splitLine, int gramSize)
        {
            string[] gramWords = new string[gramSize];
            for (int i = splitLine.Length - gramSize; i < splitLine.Length; i++)
            {
                gramWords[i - (splitLine.Length - gramSize)] = splitLine[i];
            }

            return gramWords;
        }
    }
}
