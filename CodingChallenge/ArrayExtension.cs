using System;
using System.Linq;

namespace CodingChallenge
{
    public static class ArrayExtension
    {
        public static int[] Shuffle(this int[] array)
        {
            var rnd = new Random();
            return array.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}