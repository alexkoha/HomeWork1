using System;

namespace MulBoard
{
    class Program
    {
        public static void ShowMulBoard()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.Write("|");
                for (int j = 1; j < 11; j++)
                {
                    Console.Write("{0,5}" , i*j);
                }
                Console.WriteLine("|");
            }
        }

        static void Main()
        {
            ShowMulBoard();
        }
    }
}
