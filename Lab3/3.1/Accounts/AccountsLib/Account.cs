
namespace AccountsLib
{
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
            _money += addMoney;
        }

        public bool Withdraw(int withdrawMoney)
        {
            if (_money >= withdrawMoney)
            {
                _money -= withdrawMoney;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transfer(ref Account to , int amount)
        {
            if (Withdraw(amount))
            {
                to._money += amount;
                return true;
            }
            else return false;
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
