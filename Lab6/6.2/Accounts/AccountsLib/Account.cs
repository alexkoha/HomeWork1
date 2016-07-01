
using System;

namespace AccountsLib
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() {}
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
        protected InsufficientFundsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }



    public class Account
    {
        private readonly int _id;
        private int _money;

        internal Account(int id)
        {
            _id = id;
            _money = 0;
        }

        public int Balance()
        {
            return _money;
        }

        public void Deposit(int addMoney)
        {
            if (addMoney<0) throw new ArgumentOutOfRangeException();
            _money += addMoney;
        }

        public bool Withdraw(int withdrawMoney)
        {
            if (withdrawMoney < 0) throw new ArgumentOutOfRangeException();

            if (_money < withdrawMoney) throw new InsufficientFundsException();

            _money -= withdrawMoney;
            return true;
            //Console.WriteLine($"You will go into overdraft.Maximum thay you can Withdraw is {_money}");
            //return false;
        }

        public void Transfer(ref Account to , int amount)
        {
            try
            {
                Console.WriteLine("Before Transfer :" + Balance());
                if (Withdraw(amount))
                {
                    to._money += amount;
                }
            }
            finally
            {
                Console.WriteLine("Transfer attempt!");
                Console.WriteLine("After Transfer :" + Balance());
            }



        }
    }

    public static class AccountFactory
    {
        public static int LastId;

        public static Account CreateAccount(int initialBalance)
        {
            LastId++;
            var newOneAccount = new Account(LastId);
            newOneAccount.Deposit(initialBalance);

            return newOneAccount;
        }
    }
}
