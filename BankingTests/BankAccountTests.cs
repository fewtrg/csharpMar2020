using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        private decimal amountToDeposit;

        [Fact]
        public void NewAccountHasCorrectBalance()
        {
            var account = new BankAccount();

            decimal currentBalance = account.GetBalance();

            Assert.Equal(7000M, currentBalance);
        }

        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1M;
            // Act - When
            account.Withdraw(amountToWithdraw);
            //Assert - then
            Assert.Equal(
                openingBalance - amountToWithdraw,
                account.GetBalance());

        }

        [Fact]
        public void DepositIncreasesBalance()
        {
            // Arrange - Given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 1M;
            // Act - When
            account.Deposit(amountToDeposit);
            //Assert - then
            Assert.Equal(
                openingBalance + amountToDeposit,
                account.GetBalance());
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            account.Withdraw(openingBalance + 1);

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
