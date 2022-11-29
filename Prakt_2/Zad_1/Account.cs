using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zad_1
{
    public class Account
    {
        private const string DEFAULT_ID = "0";
        private const decimal DEFAULT_INTERESTRATE = 0;
        private const decimal DEFAULT_BALANCE = 0;
        private decimal anualInterestRate;
        private decimal balance;
        private System.DateTime dateCreated;
        private string? id;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Account()
        {
            AnualInterestRate = DEFAULT_INTERESTRATE;
            Balance = DEFAULT_BALANCE;
            DateCreated = DateTime.Now;
            Id = DEFAULT_ID;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="anualInterestRate">Annual interest rate</param>
        /// <param name="balance">Balance</param>
        /// <param name="id">ID</param>
        public Account(decimal anualInterestRate, decimal balance, string id)
        {
            AnualInterestRate = anualInterestRate;
            Balance = balance;
            DateCreated = DateTime.Now;
            Id = id;
        }

        public decimal AnualInterestRate
        {
            get { return anualInterestRate; }
            set 
            { 
                if(value >= 0) anualInterestRate = value;
                else anualInterestRate = DEFAULT_INTERESTRATE;
            }
        }

        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public System.DateTime DateCreated
        {
            get { return dateCreated; }
            private set { dateCreated = value; }
        }

        public string? Id
        {
            get { return id; }
            private set { id = value; }
        }

        /// <summary>
        /// Adds certain amount to account balance
        /// </summary>
        /// <param name="depositAmount">Amount to deposit</param>
        public void Deposit(decimal depositAmount)
        {
            if (depositAmount > 0) balance += depositAmount;
        }

        /// <summary>
        /// Withdraws certain amount from account balance
        /// </summary>
        /// <param name="withdrawAmount">Amount to withdraw</param>
        public void Withdraw(decimal withdrawAmount)
        {
            if(withdrawAmount > 0) balance -= withdrawAmount;
        }
    }
}