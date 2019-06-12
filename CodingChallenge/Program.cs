using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();
            var productOfPrimes = new List<ProductOfPrimes>();

            var primes = SieveOfEratosthenes.GetAllPrimesLessThan(1000)
                .Where(x => x >= 100);

            var testMatchForward = Task.Run(() => TestForMatch(primes.ToArray(), productOfPrimes, true));
            var testMatchReverse = Task.Run(() => TestForMatch(primes.Reverse().ToArray(), productOfPrimes, true));
            var testMatchShuffle = Task.Run(() => TestForMatch(primes.ToArray().Shuffle(), productOfPrimes, true));

            var result = Task.WhenAny(testMatchForward, testMatchReverse, testMatchShuffle).GetAwaiter().GetResult();
            stopWatch.Stop();

            var taskNames = new[] { "TestMatchForward", "TestMatchReverse", "TestMatchShuffle" };

            foreach (var productOfPrime in productOfPrimes)
            {
                Console.WriteLine($"Tasks ran with IDs - {testMatchForward.Id}, {testMatchReverse.Id}, {testMatchShuffle.Id}");
                Console.WriteLine($"Matched! by task {result.Id} - {taskNames[result.Id - 1]}");
                Console.WriteLine($"{productOfPrime.Product} primes {productOfPrime.Factors[0]}, {productOfPrime.Factors[1]}, {productOfPrime.Factors[2]}, {productOfPrime.Factors[3]}");
            }

            Console.WriteLine($"Elapsed time {stopWatch.Elapsed}");
        }

        public static bool TestForMatch(int[] primes, List<ProductOfPrimes> result, bool exitOnFirstMatch)
        {
            foreach (var i in Combinations.GetCombinations(primes, 4))
            {
                if (ProductOfPrimes.MatchesPattern(i, 12))
                {
                    result.Add(new ProductOfPrimes(i));
                    if (exitOnFirstMatch)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
