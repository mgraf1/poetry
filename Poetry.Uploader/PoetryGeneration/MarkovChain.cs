using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.PoetryGeneration
{
    /// <summary>
    /// Stores a Markov chain of NGrams.
    /// </summary>
    public class MarkovChain
    {
        public int GramSize { get; set; }

        private IDictionary<NGram, IList<NGram>> chain;
        private IList<NGram> lineBeginnings;
        private IList<NGram> lineEndings;

        public MarkovChain()
        {
            chain = new Dictionary<NGram, IList<NGram>>();
            lineBeginnings = new List<NGram>();
            lineEndings = new List<NGram>();
        }

        /// <summary>
        /// Given two successive NGrams, add a link to the current chain.
        /// </summary>
        public void AddLink(NGram firstGram, NGram nextGram)
        {
            if (firstGram.Size != GramSize)
            {
                throw new ArgumentException(string.Format("MarkovChain accepts grams of size {0}, GramSize: {1}",
                    firstGram.Size, GramSize));
            }

            if (firstGram.Size != nextGram.Size)
            {
                throw new ArgumentException("Grams must be same size");
            }

            if (chain.ContainsKey(firstGram))
            {
                chain[firstGram].Add(nextGram);
            }
            else
            {
                chain[firstGram] = new List<NGram> { nextGram };
            }
        }

        /// <summary>
        /// Given an NGram, get a random NGram that could follow it.
        /// </summary>
        public NGram GetNextGram(NGram gram)
        {
            if (!chain.ContainsKey(gram))
            {
                throw new ArgumentException(string.Format("MarkovChain does not contain gram {0}",
                    gram.ToString()));
            }

            IList<NGram> possibleGrams = chain[gram];
            NGram randomGram = possibleGrams.GetRandomElement<NGram>();

            return randomGram;
        }

        /// <summary>
        /// Add an NGram to the group of NGrams that can start a line of poetry.
        /// </summary>
        public void AddBeginning(NGram startingGram)
        {
            lineBeginnings.Add(startingGram);
        }

        /// <summary>
        /// Returns a random NGram that could start a line of poetry.
        /// </summary>
        public NGram GetBeginning()
        {
            return lineBeginnings.GetRandomElement<NGram>();
        }

        /// <summary>
        /// Add an NGram to the group of NGrams that can end a line of poetry.
        /// </summary>
        public void AddEnding(NGram startingGram)
        {
            lineEndings.Add(startingGram);
        }

        /// <summary>
        /// Returns a random NGram that could end a line of poetry.
        /// </summary>
        public NGram GetEnding()
        {
            return lineEndings.GetRandomElement<NGram>();
        }

    }
}
