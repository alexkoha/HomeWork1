using System;
using System.Linq;


namespace Strings
{
    public class SplitedTools
    {
        public string[] SplitToWords(string str)
        {
            return str.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public int NumOfWords(string[] strArr)
        {
            return strArr.Length;
        }
    }

    class Program
    {
        static void Main()
        {
            SplitedTools tools = new SplitedTools();
             
            bool isEmpty = false;
            while (!isEmpty)
            {
                Console.WriteLine("Enter some sentence : ");
                var some = Console.ReadLine();

                isEmpty = string.IsNullOrEmpty(some) || string.IsNullOrWhiteSpace(some);

                if (!isEmpty)
                {
                    string[] strArr = tools.SplitToWords(some);

                    Console.WriteLine("\nNumber of words :" + strArr.Length);
                    Console.WriteLine("\n\nNot Sorted :");

                    foreach (var s in strArr.Reverse())
                    {
                        Console.Write(s + " ");
                    }

                    Console.WriteLine("\n\nSorted :");

                    Array.Sort(strArr);
                    foreach (var word in strArr)
                    {
                        Console.Write(word + " ");
                    }
                    Console.WriteLine("\n");

                }

            }
        }
    }
}
