using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class BankAccount
    {
        private double _balance = 0;
        private List<Transaction> _transactions = new List<Transaction>();

        public string Number { get; set; }
        public string Owner { get; set; }
        public double Balance
        {
            get { return _balance; }
        }

        public List<Transaction> Transactions
        { get { return _transactions; } }

        public BankAccount(string owner, double initialBalance)
        {
            Number = owner;
            _balance = initialBalance;
        }

        public void MakeDeposit(double amount, string description)
        {
            this._balance += amount;
            this._transactions.Add(new Transaction(TransactionType.Deposit, amount, description));
        }

        public void MakeWithdraw(double amount, string description)
        {

            if (amount > _balance)
            {
                throw new ArgumentException("Cannot withdraw an empty balance");
            }

            this._balance -= amount;
            this._transactions.Add(new Transaction(TransactionType.Withdraw, amount, description));
        }

    }
}
