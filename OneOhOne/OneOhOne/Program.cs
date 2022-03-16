using System;
using BankLibrary;
using Humanizer;

namespace OneOhOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Sekardayu Hana Pradiani", 100);
            account.MakeDeposit(1000, "Get my first paycheck");
            account.MakeWithdraw(500, "Buy a new phone");
            foreach (var t in account.Transactions)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
