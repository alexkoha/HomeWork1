using System;
using System.Collections.Generic;

namespace Primes
{
    class Program
    {
        public static bool IsPrime(int i)
        {
            for (int j = 2; j <= (int)Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Should return an array
        public static List<int> CalcPrimes(int min, int max)
        {
            var arrayList = new List<int>();

            //check an add primes number
            for (int i = min; i <=max; i++)
            {
                if  (IsPrime(i))
                {
                    arrayList.Add(i);
                }
            }

            return arrayList;
        }

        static void Main()
        {
            Console.WriteLine("Please choose minimum number (numeric number) :");
            int min = int.Parse(Console.ReadLine());

            Console.WriteLine("Please choose maximum number (numeric number) :");
            int max = int.Parse(Console.ReadLine());

            var result = CalcPrimes(min, max);
            Console.WriteLine("Here is all primes number between {0} to {1} :",min,max);
            Console.WriteLine("--------------------------------------------");
            foreach (var prime in result)
            {
                Console.Write(prime + "\t");
            }
            Console.WriteLine();

        }
    }
}
