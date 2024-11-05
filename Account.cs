using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountMSTest
{
    internal class Account
    {
        public int AccountId { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }

        const double MIN_BALANCE = 500;
        public Account(int accountId,string accountHolderName,string bankName,double balance)
        {
            AccountId = accountId;
            AccountHolderName = accountHolderName;
            BankName = bankName;
            Balance = balance < MIN_BALANCE ? MIN_BALANCE : balance;
        }

        public double Deposit(double amount)
        {
            if (amount <= 0)
                throw new Exception("Deposit amount must be positive");
            Balance += amount;
            return Balance;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public double Withdraw(double amount)
        {
            if (amount <= 0)
                throw new Exception("Withdraw amount must be positive");
            if (amount > Balance)
                throw new Exception("Insufficient balance");
            Balance -= amount;
            return Balance;
        }

        public void Transfer(Account toAccount, double amount)
        {
            if (toAccount is null)
                throw new ArgumentNullException("The destination account cannot be null");
            if (amount <= 0)
                throw new Exception("Transfer amount must be positive");
            if (amount > Balance)
                throw new Exception("Insufficient balance for transfer");

            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }
}
