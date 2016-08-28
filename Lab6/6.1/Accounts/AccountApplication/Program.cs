using System;
using AccountsLib;

namespace AccountApplication
{
    class Program
    {
        static void Main()
        {
            int choose;
            int amount;

            Account firstAccount = AccountFactory.CreateAccount(100);
            Console.WriteLine("Choose what you want to do : \n (1) Deposit \n (2) Withdraw \n (3) Quary");
            
            bool convertedToInt = int.TryParse(Console.ReadLine(), out choose);

            try
            {
                if (convertedToInt)
                {
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("Enter amount to deposit : ");
                            convertedToInt = int.TryParse(Console.ReadLine(), out amount);

                            if (convertedToInt)
                            {
                                firstAccount.Deposit(amount);
                                Console.WriteLine("Deposit finished successful!\n");
                            }
                            else Console.WriteLine("Somthing wrong...! try again.\n");
                            break;

                        case 2:
                            Console.WriteLine("Enter amount to withdraw : ");
                            convertedToInt = int.TryParse(Console.ReadLine(), out amount);

                            if (convertedToInt)
                            {
                                Console.WriteLine(!firstAccount.Withdraw(amount)
                                    ? "You will go into overdraft.this action aborted.\n"
                                    : "Deposit finished successful!\n");
                            }
                            else Console.WriteLine("Somthing wrong...! try again.\n");
                            break;

                        case 3:
                            Console.WriteLine($"Your balance is : {firstAccount.Balance()} \n");
                            break;

                        default:
                            Console.WriteLine("You can choose just (1) (2) or (3).try again. \n ");
                            break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException )
            {
                //You should have used the message from the exception
                Console.WriteLine("\nAmount can't be negativ.\nOperation aborted !\n");
            }

            Account secondAccount = AccountFactory.CreateAccount(300);

            Console.WriteLine("Lets transfer money from your account. \nplease enter amount to transfer :");

            convertedToInt = int.TryParse(Console.ReadLine(), out amount);


            if (convertedToInt)
            {
                firstAccount.Transfer(ref secondAccount, amount);
            }
            else Console.WriteLine("Somthing wrong...! Notice : you can enter just numeric numbers.");

        }
    }
}
