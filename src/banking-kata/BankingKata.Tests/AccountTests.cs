using NUnit.Framework;
using BankingKata.Entities;
using System;

namespace BankingKata.Tests
{
    internal sealed class AccountTests
    {
        private Account _account;
        [SetUp]
        public void SetUp()
        {
            _account = new Account();
        }

        [Test]
        public void Deposit_GivenAmount_SetsCurrentBalanceToGivenAmount()
        {
            _account.Deposit(100);

            Assert.That(_account.CurrentBalance, Is.EqualTo(100));
        }

        [Test]
        public void Withdraw_GivenAmount_SetsCurrentBalanceToNegativeGivenAmount()
        {
            _account.Withdraw(50);

            Assert.That(_account.CurrentBalance, Is.EqualTo(-50));
        }

        [Test]
        public void Deposit_GivenMultipleAmounts_IncreasesCurrentBalanceEachTime()
        {
            _account.Deposit(100);
            Assert.That(_account.CurrentBalance, Is.EqualTo(100));

            _account.Deposit(50);
            Assert.That(_account.CurrentBalance, Is.EqualTo(150));
        }

        [Test]
        public void Withdraw_GivenMultipleAmounts_DecreasesCurrentBalanceEachTime()
        {
            _account.Withdraw(50);
            Assert.That(_account.CurrentBalance, Is.EqualTo(-50));

            _account.Withdraw(100);
            Assert.That(_account.CurrentBalance, Is.EqualTo(-150));
        }

        [Test]
        public void PrintStatement_GivenNoTransactions_ReturnsTitles()
        {
            var statement = _account.PrintStatement();
            Assert.That(statement, Is.EqualTo($"Date   | Amount | Balance{Environment.NewLine}"));
        }

        [Test]
        public void PrintStatement_GivenTransactions_ReturnsTitlesAndTransactions()
        {
            _account.Deposit(50);
            _account.Deposit(75);
            _account.Withdraw(100);

            var expectedStatement = $"Date   | Amount | Balance{Environment.NewLine}";
            expectedStatement += $"{DateTime.Now.ToShortDateString()} | +50 | 50{Environment.NewLine}";
            expectedStatement += $"{DateTime.Now.ToShortDateString()} | +75 | 125{Environment.NewLine}";
            expectedStatement += $"{DateTime.Now.ToShortDateString()} | -100 | 25{Environment.NewLine}";

            var statement = _account.PrintStatement();
            Assert.That(statement, Is.EqualTo(expectedStatement));
        }
    }
}