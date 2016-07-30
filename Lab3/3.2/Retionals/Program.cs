using System;

namespace Retionals
{
    //It might be abeeter idea to extract it to a different class
    //didn't override object.Equals.
    //Where are the numerator and denomirator properties?
    //Where is the double value property?
    //Add and Mul shouldn't be static. 
    struct Rational
    {
        private int _numerator;
        private int _denomirator;
        private double _result;

        public Rational(int numerator, int denomirator)
        {
            _numerator = numerator;
            _denomirator = denomirator;

            //Maybe it was better to throw an exception
            if (_denomirator == 0)
            {
                _result = 1;
            }
            else
            {
                _result = ((double)_numerator / _denomirator);
            }
        }

        public Rational(int numerator)
        {
            _numerator = numerator;
            _result = numerator;
            _denomirator = 1 ;
        }

        public void Reduce()
        {
            if (_denomirator%(_numerator%_denomirator) == 0 && _numerator%(_numerator%_denomirator) == 0)
            {
                _denomirator /= _numerator;
                _numerator = 1;
            }
            else if (_numerator%(_denomirator%_numerator) == 0 && _denomirator%(_denomirator%_numerator) == 0)
            {
                _numerator /= _denomirator;
                _denomirator = 1;
            }

            _result = (_denomirator != 0) ? (double)_numerator / _denomirator : 0;
        }

        //Why a static method? This is wrong.
        public static Rational Add(Rational a, Rational b)
        {
            Rational newRational = new Rational(0, 0)
            {
                _numerator = a._numerator*b._denomirator + b._numerator*a._denomirator,
                _denomirator = a._denomirator*b._denomirator
            };

            newRational._result = (newRational._denomirator != 0) ? (double)newRational._numerator/newRational._denomirator : 0;

            return newRational;
        }

        //Static method? this is wrong.
        public static Rational Mul(Rational a, Rational b)
        {
            Rational newRational = new Rational(0, 0)
            {
                _numerator = a._numerator*b._numerator,
                _denomirator = a._denomirator*b._denomirator
            };

            newRational._result = (newRational._denomirator != 0) ? (double)newRational._numerator / newRational._denomirator : 0;

            return newRational;
        }

        //Not good. This isn't object.Equals.
        public bool Equals(Rational b)
        {
            return (_result == b._result);
        }

        public override string ToString()
        {
            return _result.ToString();
        }

    }

    class Program 
    {
        static void Main()
        {

            Rational num1 = new Rational(1, 2);
            Rational num2 = new Rational(1, 2);

            Rational num3 = Rational.Add(num1, num2);

            Rational num4 = Rational.Mul(num2, num2);

            Rational num6 = new Rational(2, 4);
            Rational num7 = new Rational(2, 4);
            num7.Reduce();


            Console.WriteLine($"{num1} + {num2} = {num3}");
            Console.WriteLine($"{num2} * {num2} = {num4}");
            Console.WriteLine($"{num6} reduced {num7}");
        }
    }
}
