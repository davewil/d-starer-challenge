using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingChallenge
{
    public class SieveOfEratosthenes
    {
        public static List<int> GetAllPrimesLessThan(int maxPrime)
        {
            var primes = new List<int>();
            var maxSquareRoot = (int)Math.Sqrt(maxPrime);
            var eliminated = new BitArray(maxPrime + 1);

            for (var i = 2; i <= maxPrime; ++i)
            {
                if (!eliminated[i])
                {
                    primes.Add(i);
                    if (i <= maxSquareRoot)
                    {
                        for (var j = i * i; j <= maxPrime; j += i)
                        {
                            eliminated[j] = true;
                        }
                    }
                }
            }
            return primes;
        }
    }
}
