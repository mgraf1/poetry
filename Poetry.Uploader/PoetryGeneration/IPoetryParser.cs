using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.PoetryGeneration
{
    public interface IPoetryParser
    {
        MarkovChain ParsePoemFile(string filePath, int gramSize);
    }
}
