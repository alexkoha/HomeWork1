using System;

namespace HelloPerson
{
    class Program
    {
        private static string _userName;

        private static int _userNum ;

        private static void RecieveNumber()
        {
            do
            {
                Console.WriteLine("Please enter number (1-10) : ");
                _userNum = int.Parse(Console.ReadLine());
                if (_userNum > 10 || _userNum < 1) Console.WriteLine("Entered number not in range.");
            } while (_userNum > 10 || _userNum < 1);
        }

        private static void PrintName()
        {
            for (int i = 0; i < _userNum; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(_userName);
            }
        }

        static void Main()
        {
            Console.WriteLine("What's your name ? ");
            _userName = Console.ReadLine();
            Console.WriteLine("Hello " + _userName);
            RecieveNumber();
            PrintName();

        }
    }
}
