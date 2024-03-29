﻿using System;
using System.Collections.Generic;

namespace CodingChallenge
{
    static class Combinations
    {
        // Enumerate all possible m-size combinations of [0, 1, ..., n-1] array
        // in lexicographic order (first [0, 1, 2, ..., m-1]).
        private static IEnumerable<int[]> GetCombinations(int m, int n)
        {
            var result = new int[m];
            var stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    yield return (int[])result.Clone();
                    break;
                }   
            }
        }

        public static IEnumerable<T[]> GetCombinations<T>(T[] array, int m)
        {
            if (array.Length < m)
                throw new ArgumentException("Array length can't be less than number of selected elements");
            if (m < 1)
                throw new ArgumentException("Number of selected elements can't be less than 1");
            var result = new T[m];
            foreach (var j in GetCombinations(m, array.Length))
            {
                for (var i = 0; i < m; i++)
                {
                    result[i] = array[j[i]];
                }
                yield return result;
            }
        }
    }
}