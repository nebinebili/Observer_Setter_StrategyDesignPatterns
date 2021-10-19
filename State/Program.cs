using System;

namespace State
{
    class Program
    {
        public interface IAccountState
        {
            void WithdrawMoney();
            void PayInterest();
        }

        //Concrete State
        public class GoldAccount : IAccountState
        {
            public void PayInterest()
            {
                Console.WriteLine("Interest paid with Golden Account");
            }

            public void WithdrawMoney()
            {
                Console.WriteLine("Money is taken with Golden Account");
            }
        }

        //Concrete State 
        public class NormalAccount : IAccountState
        {
            public void PayInterest()
            {
                Console.WriteLine("Interest paid with Normal Account");
            }

            public void WithdrawMoney()
            {
                Console.WriteLine("Money is taken with Normal Account");
            }
        }

        //State deyisliklerini yonelden ve statelere göre davranışları deyisen context 
        public class Account
        {
            private IAccountState _accountState;

            public Account()
            {
                _accountState = new NormalAccount();
            }

            public void PayInterest()
            {
                _accountState.PayInterest();
            }

            public void WithdrawMoney()
            {
                _accountState.WithdrawMoney();
            }

            public void ChangeStatus(IAccountState newACcountState)
            {
                _accountState = newACcountState;
            }
        }


        static void Main(string[] args)
        {
            Account account = new Account();
            account.WithdrawMoney();
            account.PayInterest();

            account.ChangeStatus(new GoldAccount());

            account.WithdrawMoney();
            account.PayInterest();


        }
    }
}
