using System;


namespace Calculator
{
    public class CalculatorOperetion
    {
        public double Add(double num1, double num2)
        {
               return num1 + num2;
        }
        public double Sub(double num1, double num2)
        {
             return num1 - num2;
        }
        public double Mul(double num1, double num2)
        {
            return num1 * num2;
        }
        public double Div(double num1, double num2)
        {
            return num1 / num2;
        }


    }

    public class Program
    {
        private static double _a;
        private static double _b;
        private static string _action;

        public static double Result(string action)
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = 0;
            switch (action)
            {
                case "+":
                    result = op.Add(_a , _b);
                    break;
                case "-":
                    result = op.Sub(_a, _b);
                    break;
                case "*":
                    result = op.Mul(_a, _b); 
                    break;
                case "/":
                    result = op.Div(_a, _b);
                    break;
            }
            return result;
        }

        private static void RecieveData()
        {
            bool isIllegalSign;

            Console.WriteLine("Enter first number: ");
            _a = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter secound number: ");
            _b = double.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine("Enter action(+ - * /): ");
                _action = Console.ReadLine();
                isIllegalSign = ( _action != "+" && _action != "-" && _action != "*" && _action != "/");
                if(isIllegalSign) Console.WriteLine("This sign is wrong !");
            } while (isIllegalSign);
        }

        private static void PrintResult()
        {
            Console.WriteLine("Result : ");
            Console.WriteLine(_a + _action + _b + " = " + Result(_action));
            Console.ReadLine();
        }

        static void Main()
        {
            RecieveData();
            PrintResult();
        }
    }
}
