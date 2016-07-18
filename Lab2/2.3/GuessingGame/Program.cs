using System;


namespace GuessingGame
{
    //Why did you create a new class and left all of the logic outside?
    public class Game
    {
        private int _guessies;
        private readonly int _randNum = new Random().Next(1, 101);

        //C# 6 features. Awesome!

            //What this property does?
        public int Guessies => _guessies;

        //Where do you update this property?
        public int RandNum => _randNum;

        //Hmm I don't like this hardcoded solution. If you'd go this way, they consider using enums.
        public int MakeGuessies(int guess) // returns : 0-failed ; 1-win ; 2-too small ; 3-too big;
        {
            _guessies++;
            
            if (guess == _randNum)
            {
                return (_guessies < 8) ? 1 : 0;
            }
            else if (guess < _randNum)
            {
                return 2;
            }
            else if (guess > _randNum)
            {
                return 3;
            }
            return 0;
        }
    }

    class Program
    {
        //Consider seperating the code input methods and classes
        static void Main()
        {
            Console.WriteLine("Let's play ! guess the number ... ");

            //Not a good name for a variable
            var newGame = new Game();
            int run = 3;
            int guess = 0;
            while (run > 1)
            {
                var convertInt = false;
                while (!convertInt || guess > 100 || guess < 1)
                {
                    Console.WriteLine("Enter some number (1-100):");
                    var entered = Console.ReadLine();
                    convertInt = int.TryParse(entered, out guess);
                    if (guess > 100 || guess < 1)
                    {
                        Console.WriteLine("You Entered out of range number , Try again !");
                    }
                    if (!convertInt)
                    {
                        Console.WriteLine("You Entered somthing wrong...try again !");
                    }
                }
                run = newGame.MakeGuessies(guess);
                if (run == 2)
                {
                    Console.WriteLine("Too Small ! try again...");
                }
                else if (run == 3)
                {
                    Console.WriteLine("Too Big ! try again...");
                }
                else if(run == 0)
                {
                    Console.WriteLine("You failed!your number of guisses is {0}",newGame.Guessies );
                    Console.WriteLine("Correct number is :  {0}", newGame.RandNum);
                }
                else if(run == 1)
                {
                    Console.WriteLine("Win! your number of guisses is {0}", newGame.Guessies);
                    Console.WriteLine("Correct number is :  {0}", newGame.RandNum);
                }
            }          
        }
    }
}
