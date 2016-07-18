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
                    //this is ok, but there are other ways to do so using a single line. Check the MSDN documentation for string.Format (also works using '$' string interpolation) and/or the constructors of the string class
                    for (int j = 0; j < i; ++j)
                    {
                        Console.Write("$");
                    }
                    Console.WriteLine();
                }
            }
            //The convention is C# is to write the else's body in a new line and to always use braces '{', '}'
            else Console.WriteLine("You entered something wrong ....");
        }
    }
}
