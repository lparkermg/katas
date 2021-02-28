using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingKata.Entities
{
    public sealed class Account
    {
        public int CurrentBalance => _transactions.Sum(t => t.Amount);

        private IList<AccountTransaction> _transactions = new List<AccountTransaction>();

        public void Deposit(int amount) => AddTransaction(amount);

        public void Withdraw(int amount) => AddTransaction(-amount);

        public string PrintStatement() 
        {
            var statement = new StringBuilder();
            var balance = 0;
            statement.AppendLine("Date   | Amount | Balance");
            foreach(var transaction in _transactions)
            {
                balance += transaction.Amount;
                statement.AppendLine($"{transaction.TransactionDate.ToShortDateString()} | {(transaction.Amount > 0 ? "+" : string.Empty)}{transaction.Amount} | {balance}");
            }

            return statement.ToString();
        }

        private void AddTransaction(int amount) => _transactions.Add(new AccountTransaction
        {
            TransactionDate = DateTime.Now,
            Amount = amount,
        });
    }
}
