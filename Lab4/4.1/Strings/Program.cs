using System;
using System.Linq;


namespace Strings
{
    //Hmm Ok, nice.
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

    //Great job.
    class Program
    {
        static void Main()
        {
            SplitedTools tools = new SplitedTools();
             
            //Consider the use of do-while loop
            bool isEmpty = false;
            while (!isEmpty)
            {
                Console.WriteLine("Enter some sentence : ");
                var some = Console.ReadLine();

                //great.
                isEmpty = string.IsNullOrEmpty(some) || string.IsNullOrWhiteSpace(some);

                if (!isEmpty)
                {
                    string[] strArr = tools.SplitToWords(some);

                    //Consier the use of Environment.NewLIne
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
                        //Consider the use of string.Format, Console.WriteLine overload that accepts a format or string interpolation
                        Console.Write(word + " ");
                    }
                    Console.WriteLine("\n");

                }

            }
        }
    }
}
