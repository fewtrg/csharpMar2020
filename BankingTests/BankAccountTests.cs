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

        public BankAccount Account { get => account; set => account = value; }

        public BankAccountTests()
        {
            Account = new BankAccount();
        }

       // private decimal amountToDeposit;

        [Fact]
        public void NewAccountHasCorrectBalance()
        {

            decimal currentBalance = Account.GetBalance();

            Assert.Equal(7000M, currentBalance);
        }

        [Fact]
        public void WithdrawalDecreasesBalance()
        {
            // Arrange - Given
           // var account = new BankAccount();
            var openingBalance = Account.GetBalance();
            var amountToWithdraw = 1M;
            // Act - When
            Account.Withdraw(amountToWithdraw);
            //Assert - then
            Assert.Equal(
                openingBalance - amountToWithdraw,
                Account.GetBalance());

        }

        [Fact]
        public void DepositIncreasesBalance()
        {
            // Arrange - Given
            //var account = new BankAccount();
            var openingBalance = Account.GetBalance();
            var amountToDeposit = 1M;
            // Act - When
            Account.Deposit(amountToDeposit);
            //Assert - then
            Assert.Equal(
                openingBalance + amountToDeposit,
                Account.GetBalance());
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            //var account = new BankAccount();
            var openingBalance = Account.GetBalance();

            try
            {
                Account.Withdraw(openingBalance + 1);
            }
            catch (Exception)
            {

               
            }

            Assert.Equal(openingBalance, Account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {
           // var account = new BankAccount();

            Assert.Throws<OverdraftException>(
                () => Account.Withdraw(Account.GetBalance() + 1));
        }
    }
}
