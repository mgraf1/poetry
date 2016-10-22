using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.PoetryGeneration
{
    public static class ListExtensions
    {
        public static T GetRandomElement<T>(this IList<T> list)
        {
            Random random = new Random();

            return list[random.Next(list.Count - 1)];
        }
    }
}
