using System;

namespace DolarStairs
{
    class Program
    {
        static void Main()
        {
            int n ;
            Console.WriteLine("Please enter number : ");
            if(int.TryParse(Console.ReadLine(), out n))
            {
                for (int i = 1; i <= n; ++i)
                {
                    for (int j = 0; j < i; ++j)
                    {
                        Console.Write("$");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("You entered something wrong ....");
        }
    }
}
