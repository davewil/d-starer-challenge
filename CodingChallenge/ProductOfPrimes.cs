using System;

namespace CodingChallenge
{
    public class ProductOfPrimes
    {
        private static long numsChecked = 0;
        public int[] Factors { get; set; }

        public ulong Product { get; }

        public ProductOfPrimes(int[] factors)
        {
            Factors = new int[factors.Length];
            Array.Copy(factors, Factors, factors.Length);
            Product = (ulong)factors[0] * (ulong)factors[1] * (ulong)factors[2] * (ulong)factors[3];
        }

        public static bool MatchesPattern(ulong candidate)
        {
            var nextDigit = candidate % 10;
            while (candidate > 0)
            {
                var currentDigit = candidate % 10;
                if (currentDigit != 0 && (currentDigit == nextDigit || currentDigit + 1 == nextDigit))
                {
                    candidate /= 10;
                    if (candidate == 0)
                    {
                        return true;
                    }

                    nextDigit = currentDigit;
                }
                else break;
            }
            return false;
        }

        public static bool MatchesPattern(int[] primeFactors, int checkLength)
        {
            var candidate = (ulong)primeFactors[0] * (ulong)primeFactors[1] * (ulong)primeFactors[2] * (ulong)primeFactors[3];
            if (CountDigit(candidate) == checkLength)
            {
                return MatchesPattern(candidate);
            }
            return false;
        }

        public static int CountDigit(ulong n)
        {
            return (int)Math.Floor(Math.Log10(n) + 1);
        }
    }
}