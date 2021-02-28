using BankingKata.Entities;
using System;

namespace BankingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accounts!");

            var account = new Account();

            account.Deposit(500);
            account.Withdraw(50);
            account.Withdraw(425);
            account.Withdraw(100);

            Console.Write(account.PrintStatement());
        }
    }
}
