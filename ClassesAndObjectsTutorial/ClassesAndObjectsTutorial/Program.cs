using System;

namespace ClassesAndObjectsTutorial
{
    internal class Program
    {
        static void Main()
        {
            var account = new BankAccount("Felicia", 1000);
            Console.WriteLine($"A new account was created for {account.Owner}.  The account number is {account.Number} and the balance is {account.Balance}");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());

        }
    }
}
