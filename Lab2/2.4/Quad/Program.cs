using System;

namespace Quad
{
    public class Equation
    {
        public double[] Resolve(double a, double b, double c)
        {
            
            var check = b* b - 4*a*c;
            if (check < 0)
            {
                return null;
            }
            if (check > 0)
            {
                check = Math.Sqrt(check);
                return new[] {(-b + check)/(2*a), (-b - check)/(2*a)};
            }
            else
            {
                return new[] { -b / (2 * a) };
            }
            
        }

    }

    class Program
    {
        public static double[] Arguments = new double[3];

        static void Main(string[] args)
        {
            var equ = new Equation();
            if (args.Length < 3 || args.Length > 4)
            {
                Console.WriteLine("Please enter three numeric arguments.");
            }
            else 
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!double.TryParse(args[i], out Arguments[i]))
                    {
                        Console.WriteLine("Somthing wrong...");
                    }
                }
                var result = equ.Resolve(Arguments[0], Arguments[1], Arguments[2]);
                if (result != null)
                {
                    Console.WriteLine("Result :");
                    foreach (var x in result)
                    {
                        Console.WriteLine(x);
                    }
                }
                else Console.WriteLine("No results.");
            }

  

        }
    }
}
