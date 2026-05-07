using System.Reflection;

namespace MembersInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BankAccount account = new BankAccount("A123","Mahmoud M.",2000);
            //account.OnNegativeBalance += Account_OnNegativeBalance;
            //account.Withdraw(3000);
            //Console.WriteLine(account);

            Console.WriteLine("MemberInfo");// Member Info
            MemberInfo[] members = typeof(BankAccount).GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (MemberInfo member in members) 
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("Method Info");// Method Info
            MethodInfo[] methods = typeof(BankAccount).GetMethods();
            foreach(MethodInfo method in methods)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine("Field Info");// Field Info
            FieldInfo[] fields = typeof(BankAccount).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field);
            }
            Console.WriteLine("Property Info");// Property Info
            PropertyInfo[] properties = typeof(BankAccount).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.GetGetMethod());
                Console.WriteLine(property);
            }
            Console.WriteLine("Event Info");// Event Info
            EventInfo[] events = typeof(BankAccount).GetEvents();
            foreach (EventInfo eventInfo in events)
            {
                Console.WriteLine(eventInfo);
            }
            Console.WriteLine("Constructor Info");// Constructor Info
            ConstructorInfo[] constructors = typeof(BankAccount).GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
            Console.WriteLine("Get Member By Name");// Get Member By Name
            MemberInfo[] ctors = typeof(BankAccount).GetMember(".ctor");
            foreach (MemberInfo member in ctors)
            {
                Console.WriteLine(member.Name);
            }
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
