using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal CurrentBalance = 7000; 
       
        public decimal GetBalance()
        {
            return CurrentBalance;  // to get a meaningful error unless it needs a config change
        }

        public void Withdraw(decimal amountToWithdraw)
        {
           if(amountToWithdraw > CurrentBalance)
            {
                throw new OverdraftException();

            } else
            {
                CurrentBalance -= amountToWithdraw;
            }
            
        }

        public void Deposit(decimal amountToDeposit)
        {
            CurrentBalance += amountToDeposit;
        }
    }
}