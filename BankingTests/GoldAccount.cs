using BankingDomain;

namespace BankingTests
{
    class GoldAccount : BankAccount
    {
        public override void Deposit(decimal amountToDeposit)
        {
            base.Deposit(amountToDeposit * 1.1M); 
            //base class is the union of all the classes you inherit from
        }
    }
}