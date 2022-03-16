using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOhOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Sekardayu Hana Pradiani", 100);
            account.MakeDeposit(1000, "Get my first paycheck");
            Console.WriteLine(account.Balance);
            account.MakeWithdraw(2000, "Buy a nice device");
        }
    }
}
