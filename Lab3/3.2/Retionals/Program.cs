using System;

namespace Retionals
{
    struct Retionals
    {
        private int _numerator;
        private int _denomirator;
        private double _result;

        public Retionals(int numerator, int denomirator)
        {
            _numerator = numerator;
            _denomirator = denomirator;
            if (_denomirator == 0)
            {
                _result = 1;
            }
            else
            {
                _result = ((double)_numerator / _denomirator);
            }
        }

        public Retionals(int numerator)
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

        public static Retionals Add(Retionals a, Retionals b)
        {
            Retionals newRetional = new Retionals(0, 0)
            {
                _numerator = a._numerator*b._denomirator + b._numerator*a._denomirator,
                _denomirator = a._denomirator*b._denomirator
            };

            newRetional._result = (newRetional._denomirator != 0) ? (double)newRetional._numerator/newRetional._denomirator : 0;

            return newRetional;
        }

        public static Retionals Mul(Retionals a, Retionals b)
        {
            Retionals newRetional = new Retionals(0, 0)
            {
                _numerator = a._numerator*b._numerator,
                _denomirator = a._denomirator*b._denomirator
            };

            newRetional._result = (newRetional._denomirator != 0) ? (double)newRetional._numerator / newRetional._denomirator : 0;

            return newRetional;
        }

        public bool Equals(Retionals b)
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
            Retionals oneRetionls = new Retionals(2,8);
            Retionals twoRetionals = new Retionals(4, 16);

            Console.WriteLine("First Retionl : " + oneRetionls.ToString());
            Console.WriteLine("Second Retionl : " + twoRetionals.ToString());
            
            // add
            Retionals addRetionals = Retionals.Add(oneRetionls, twoRetionals);
            Console.WriteLine("after add : " + addRetionals.ToString());
            //Mul
            Retionals mulRetionals = Retionals.Mul(oneRetionls, twoRetionals);
            Console.WriteLine("after mul : " + mulRetionals.ToString());

            //reduce
            oneRetionls.Reduce();
            twoRetionals.Reduce();

            Console.WriteLine("equal ? : " + oneRetionls.Equals(twoRetionals));
            
        }
    }
}
