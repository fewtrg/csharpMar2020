using System;

namespace BankingDomain
{
    public enum AccountType { Standard, Gold}
    public class BankAccount
    {
        private decimal CurrentBalance = 7000;
        public AccountType TypeOfAccount = AccountType.Standard;
       
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
        // virtual giving permission to override
        public virtual void Deposit(decimal amountToDeposit)
        {
            if(this.TypeOfAccount == AccountType.Gold)
            {
                //amountToDeposit = amountToDeposit * 1.10M;
                amountToDeposit *= 1.10M;
            }
            CurrentBalance += amountToDeposit;
        }
    }
}