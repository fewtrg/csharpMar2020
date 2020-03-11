using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        BankAccount account;

        public BankAccountTests()
        {
            account = new BankAccount();
        }

       // private decimal amountToDeposit;

        [Fact]
        public void NewAccountHasCorrectBalance()
        {

            decimal currentBalance = account.GetBalance();

            Assert.Equal(7000M, currentBalance);
        }

        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            // Arrange - Given
           // var account = new BankAccount();
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
            //var account = new BankAccount();
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
            //var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (Exception)
            {

               
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {
           // var account = new BankAccount();

            Assert.Throws<OverdraftException>(
                () => account.Withdraw(account.GetBalance() + 1));
        }
    }
}
