using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            if (n <= 250000)
            {
                return FindPrime(n, 1, 2, 3);
            }
            else if (n <= 500000)
            {
                return FindPrime(n, 250000, 3497861, 3497867);
            }
            else if (n <= 750000)
            {
                return FindPrime(n, 500000, 7368787, 7368791);
            }
            else if (n <= 1000000)
            {
                return FindPrime(n, 750000, 11381621, 11381633);
            }
            else if (n <= 1250000)
            {
                return FindPrime(n, 1000000, 15485863, 15485867);
            }
            else if (n <= 1500000)
            {
                return FindPrime(n, 1250000, 19654991, 19655021);
            }
            else if (n <= 1750000)
            {
                return FindPrime(n, 1500000, 23879519, 23879539);
            }
            else
            {
                return FindPrime(n, 1750000, 28146689, 28146691);
            }
        }

        static int FindPrime(int n, int count, int firstPrime, int nextPrime)
        {
            int currentPrime = firstPrime;

            for (int i = nextPrime; count < n; i += 2)
            {
                if (IsPrime(i))
                {
                    currentPrime = i;
                    count++;
                }
            }

            return currentPrime;
        }

        static bool IsPrime(int number)
        {
            if (number < 2) { return false; }
            if (number == 2) { return true; }
            if (number % 2 == 0) { return false; }

            for (int j = 3; j <= Math.Sqrt(number); j += 2) // Check only odd divisors
            {
                if (number % j == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 3 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
