using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOhOne
{

    public enum TransactionType
    {
        Withdraw,
        Deposit
    }
    public class Transaction
    {
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public Transaction(
            TransactionType type,
            double amount,
            string description
        )
        {
            Type = type;
            Amount = amount;
            Description = description;
        }

        public override string ToString()
        {
            return $"You {Type.ToString().ToLower()} with an amount of {Amount} for {Description}";
        }
    }
}
