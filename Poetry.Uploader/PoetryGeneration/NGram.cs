using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.PoetryGeneration
{
    /// <summary>
    /// Encapsulates a gram that contains N strings.
    /// </summary>
    public class NGram
    {
        /// <summary>
        /// The number of strings in the gram.
        /// </summary>
        public int Size { get { return gramWords.Length; } }

        /// <summary>
        /// The concatenated string value of all the words in the gram.
        /// </summary>
        public string ConcatenatedValue
        {
            get
            {
                return _getStringValue();
            }
        }

        private string[] gramWords;
 
        public NGram(params string[] args)
        {
            gramWords = new string[args.Length];
            args.CopyTo(gramWords, 0);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("(");
            for (int i = 0; i < Size; i++)
            {
                builder.Append(gramWords[i]);

                if (i < gramWords.Length - 1)
                {
                    builder.Append(",");
                }
            }
            builder.Append(")");

            return builder.ToString();
        }

        private string _getStringValue()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                builder.Append(gramWords[i]);

                if (i < gramWords.Length - 1)
                {
                    builder.Append(" ");
                }
            }

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            NGram other = obj as NGram;

            if (other == null)
            {
                return false;
            }

            if (Size != other.Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                if (gramWords[i] != other.gramWords[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            
            for (int i = 0; i < Size; i++)
            {
                hash = (hash * 7) + gramWords[i].GetHashCode();
            }

            return hash;
        }
    }
}
