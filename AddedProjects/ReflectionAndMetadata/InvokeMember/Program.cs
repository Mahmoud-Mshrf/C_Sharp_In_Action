using System.Reflection;

namespace InvokeMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //account.OnNegativeBalance += Account_OnNegativeBalance;
            // Invoke Member means to call a method, access a property, or trigger an event on an object using reflection. This allows you to interact with members of a class dynamically

            var account = new BankAccount("A123", "Mahmoud M.", 2000);
            Type t = typeof(BankAccount);
            Type[] ParametersType = {typeof(decimal)};
            MethodInfo? method = t.GetMethod("Deposit");
            method.Invoke(account, new object[] { 500m });
            Console.WriteLine(account);
            Console.ReadKey();
        }

        private static void Account_OnNegativeBalance(object? sender, EventArgs e)
        {
            var obj = sender as BankAccount;
            Console.WriteLine("NEGATIVE BALANCE !!!");
        }
    }
    public class BankAccount
    {
        private string accountNumber;
        private string accountHolder;
        private decimal balance;

        public BankAccount(string accountNumber, string accountHolder, decimal balance)
        {
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = balance;
        }

        public event EventHandler OnNegativeBalance;

        public string AccountNumber => accountNumber;
        public string AccountHolder => accountHolder;
        public decimal Balance => balance;
        public void Deposit(decimal amount)
        {
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            balance -= amount;
            if (balance < 0)
            {
                OnNegativeBalance?.Invoke(this, null);
            }
        }
        public override string ToString()
        {
            return $"Account Number: {accountNumber}, Account Holder: {accountHolder}, Balance: {balance}";
        }
    }
}
