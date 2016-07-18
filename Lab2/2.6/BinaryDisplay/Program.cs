using System;

namespace BinaryDisplay
{
    public class Program
    {
        private static int _input;

        public static int CalcNumberOfOnes(int num)
        {
            int numberOfOnes = 0;
            if (num < 0)
            {

                //Nice trick
                num = Math.Abs(num) - 1;
                numberOfOnes = 32; 
                while (num > 0)
                {
                    numberOfOnes -= num & 1;
                    num = num >> 1;
                }
            }
            else
            {
                while (num > 0)
                {
                    numberOfOnes += num & 1;
                    num = num >> 1;
                }
            }
            return numberOfOnes;
        }

        static void Main()
        {
            Console.WriteLine("Please enter ome number (integer):");
            if (int.TryParse(Console.ReadLine(), out _input))
            {
                //It would be better if you extracted Convert.ToString to other method, because it is an implementation detail
                Console.WriteLine("Inputted number converted to Binary : " + Convert.ToString(_input, 2));
                Console.WriteLine("Number of One's : {0}" , CalcNumberOfOnes(_input));
            }
            else Console.WriteLine("Wrong Input...!");

        }
    }
}
